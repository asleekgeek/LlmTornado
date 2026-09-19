using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LlmTornado.Code;
using LlmTornado.Common;
using LlmTornado.Videos.Models;
using LlmTornado.Videos.Models.MiniMax;
using Newtonsoft.Json;

namespace LlmTornado.Videos.Vendors.MiniMax;

/// <summary>
/// Handles all video operations for MiniMax.
/// </summary>
internal static class VendorMiniMaxVideoHandler
{
    private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
    {
        NullValueHandling = NullValueHandling.Ignore
    };
    
    /// <summary>
    /// Creates a new video generation job.
    /// </summary>
    public static async Task<HttpCallResult<VideoJob>> Create(
        VideoGenerationRequest request, 
        IEndpointProvider provider, 
        EndpointBase endpoint, 
        CancellationToken cancellationToken)
    {
        bool h3 = VideoModelMiniMaxH3.IsH3Model(request.Model?.Name);
        string json = h3
            ? JsonConvert.SerializeObject(VendorMiniMaxVideoGenerationV2Request.FromRequest(request), SerializerSettings)
            : JsonConvert.SerializeObject(VendorMiniMaxVideoGenerationRequest.FromRequest(request), SerializerSettings);
        
        string url = provider.ApiUrl(CapabilityEndpoints.Videos, null);
        if (h3)
        {
            url = ToV2Url(url);
        }
        
        HttpCallResult<VendorMiniMaxVideoCreateResponse> result = await endpoint.HttpPost<VendorMiniMaxVideoCreateResponse>(
            provider, 
            CapabilityEndpoints.Videos, 
            url,
            postData: json,
            ct: cancellationToken
        ).ConfigureAwait(false);
        
        if (!result.Ok || result.Data is null)
        {
            return new HttpCallResult<VideoJob>(result.Code, result.Response, null, false, result.Request)
            {
                Exception = result.Exception
            };
        }
        
        if (result.Data.BaseResp is { StatusCode: not 0 })
        {
            return new HttpCallResult<VideoJob>(result.Code, result.Response, null, false, result.Request)
            {
                Exception = new Exception($"MiniMax error {result.Data.BaseResp.StatusCode}: {result.Data.BaseResp.StatusMsg}")
            };
        }
        
        VideoJob job = new VideoJob
        {
            Id = result.Data.TaskId,
            Status = VideoJobStatus.Queued,
            Model = request.Model?.Name,
            Prompt = request.Prompt,
            SourceProvider = LLmProviders.MiniMax
        };
        
        return new HttpCallResult<VideoJob>(result.Code, result.Response, job, true, result.Request);
    }
    
    /// <summary>
    /// Retrieves the status of a video job.
    /// </summary>
    public static async Task<HttpCallResult<VideoJob>> Get(
        string taskId, 
        IEndpointProvider provider, 
        EndpointBase endpoint, 
        CancellationToken cancellationToken,
        VideoModel? model = null)
    {
        if (VideoModelMiniMaxH3.IsH3Model(model?.Name))
        {
            return await GetV2(taskId, provider, endpoint, cancellationToken).ConfigureAwait(false);
        }

        if (model is null)
        {
            HttpCallResult<VideoJob> v2 = await GetV2(taskId, provider, endpoint, cancellationToken).ConfigureAwait(false);
            if (v2.Ok && v2.Data is not null && v2.Data.Status is not VideoJobStatus.Unknown)
            {
                return v2;
            }
        }
        
        return await GetV1(taskId, provider, endpoint, cancellationToken).ConfigureAwait(false);
    }
    
    /// <summary>
    /// Downloads video content. H3 jobs store a direct CDN URL; Hailuo jobs store a file_id
    /// that must be resolved through GET /v1/files/retrieve.
    /// </summary>
    public static async Task<StreamResponse?> GetContent(
        string fileIdOrUrl,
        IEndpointProvider provider, 
        EndpointBase endpoint, 
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(fileIdOrUrl))
        {
            return null;
        }

        if (fileIdOrUrl.StartsWith("http://", StringComparison.OrdinalIgnoreCase)
            || fileIdOrUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
        {
            return await endpoint.HttpGetRawStream(provider, fileIdOrUrl, ct: cancellationToken).ConfigureAwait(false);
        }
        
        string baseUrl = provider.ApiUrl(CapabilityEndpoints.Videos, null);
        string fileUrl = baseUrl.Replace("/video_generation", "/files/retrieve");
        
        HttpCallResult<VendorMiniMaxFileRetrieveResponse> result = await endpoint.HttpGet<VendorMiniMaxFileRetrieveResponse>(
            provider,
            CapabilityEndpoints.None,
            fileUrl,
            queryParams: new Dictionary<string, object> { { "file_id", fileIdOrUrl } },
            ct: cancellationToken
        ).ConfigureAwait(false);
        
        if (!result.Ok || result.Data?.File?.DownloadUrl is null)
        {
            return null;
        }
        
        return await endpoint.HttpGetRawStream(provider, result.Data.File.DownloadUrl, ct: cancellationToken).ConfigureAwait(false);
    }

    private static async Task<HttpCallResult<VideoJob>> GetV1(
        string taskId,
        IEndpointProvider provider,
        EndpointBase endpoint,
        CancellationToken cancellationToken)
    {
        string baseUrl = provider.ApiUrl(CapabilityEndpoints.Videos, null);
        string queryUrl = baseUrl.Replace("/video_generation", "/query/video_generation");
        
        HttpCallResult<VendorMiniMaxVideoQueryResponse> result = await endpoint.HttpGet<VendorMiniMaxVideoQueryResponse>(
            provider, 
            CapabilityEndpoints.None,
            queryUrl,
            queryParams: new Dictionary<string, object> { { "task_id", taskId } },
            ct: cancellationToken
        ).ConfigureAwait(false);
        
        if (!result.Ok || result.Data is null)
        {
            return new HttpCallResult<VideoJob>(result.Code, result.Response, null, false, result.Request)
            {
                Exception = result.Exception
            };
        }
        
        VideoJob job = new VideoJob
        {
            Id = taskId,
            SourceProvider = LLmProviders.MiniMax,
            Status = MapTaskStatus(result.Data.Status)
        };
        
        if (!string.IsNullOrEmpty(result.Data.FileId))
        {
            job.VideoUri = result.Data.FileId;
        }
        
        if (result.Data.VideoWidth.HasValue && result.Data.VideoHeight.HasValue)
        {
            job.Size = $"{result.Data.VideoWidth}x{result.Data.VideoHeight}";
        }
        
        return new HttpCallResult<VideoJob>(result.Code, result.Response, job, true, result.Request);
    }

    private static async Task<HttpCallResult<VideoJob>> GetV2(
        string taskId,
        IEndpointProvider provider,
        EndpointBase endpoint,
        CancellationToken cancellationToken)
    {
        string baseUrl = provider.ApiUrl(CapabilityEndpoints.Videos, null);
        string queryUrl = $"{ToV2Url(baseUrl.Replace("/video_generation", "/query/video_generation"))}/{taskId}";
        
        HttpCallResult<VendorMiniMaxVideoV2QueryResponse> result = await endpoint.HttpGet<VendorMiniMaxVideoV2QueryResponse>(
            provider, 
            CapabilityEndpoints.None,
            queryUrl,
            ct: cancellationToken
        ).ConfigureAwait(false);
        
        if (!result.Ok || result.Data?.Task is null)
        {
            return new HttpCallResult<VideoJob>(result.Code, result.Response, null, false, result.Request)
            {
                Exception = result.Exception ?? (result.Data?.Error is not null
                    ? new Exception($"MiniMax error {result.Data.Error.Code}: {result.Data.Error.Message}")
                    : null)
            };
        }

        VendorMiniMaxVideoV2Task task = result.Data.Task;
        VideoJob job = new VideoJob
        {
            Id = task.Id ?? taskId,
            Model = task.Model,
            SourceProvider = LLmProviders.MiniMax,
            Status = MapTaskStatus(task.Status),
            VideoUri = task.Content?.Url,
            Size = task.Resolution,
            Seconds = task.Duration?.ToString(),
            Prompt = task.Content?.Prompt
        };

        if (task.Error is not null)
        {
            job.Error = new VideoJobError
            {
                Code = task.Error.Code,
                Message = task.Error.Message
            };
        }
        
        return new HttpCallResult<VideoJob>(result.Code, result.Response, job, true, result.Request);
    }

    private static string ToV2Url(string url)
    {
        return url.Replace("/v1/", "/v2/");
    }
    
    private static VideoJobStatus MapTaskStatus(string? status)
    {
        if (string.IsNullOrEmpty(status))
        {
            return VideoJobStatus.Unknown;
        }
        
        return status switch
        {
            "Preparing" => VideoJobStatus.Queued,
            "Queueing" => VideoJobStatus.Queued,
            "queued" => VideoJobStatus.Queued,
            "Processing" => VideoJobStatus.InProgress,
            "running" => VideoJobStatus.InProgress,
            "Success" => VideoJobStatus.Completed,
            "succeeded" => VideoJobStatus.Completed,
            "Fail" => VideoJobStatus.Failed,
            "failed" => VideoJobStatus.Failed,
            "cancelled" => VideoJobStatus.Failed,
            _ => VideoJobStatus.Unknown
        };
    }
}
