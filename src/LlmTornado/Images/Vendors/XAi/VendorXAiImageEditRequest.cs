using System.Collections.Generic;
using LlmTornado.Code;
using Newtonsoft.Json;

namespace LlmTornado.Images.Vendors.XAi;

/// <summary>
/// xAI-specific image edit request format.
/// </summary>
internal class VendorXAiImageEditRequest
{
    [JsonProperty("model")]
    public string? Model { get; set; }
    
    /// <summary>
    /// One image object or an array of up to 5 source images.
    /// </summary>
    [JsonProperty("image")]
    public object? Image { get; set; }
    
    [JsonProperty("mask")]
    public VendorXAiImageInput? Mask { get; set; }
    
    [JsonProperty("aspect_ratio")]
    public string? AspectRatio { get; set; }
    
    [JsonProperty("prompt")]
    public string? Prompt { get; set; }
    
    [JsonProperty("n")]
    public int? N { get; set; }
    
    [JsonProperty("resolution")]
    public string? Resolution { get; set; }
    
    [JsonProperty("response_format")]
    public string? ResponseFormat { get; set; }
    
    [JsonProperty("quality")]
    public string? Quality { get; set; }
    
    [JsonProperty("user")]
    public string? User { get; set; }

    /// <summary>
    /// Creates a new xAI image edit request from a harmonized ImageEditRequest.
    /// </summary>
    public VendorXAiImageEditRequest(ImageEditRequest request, IEndpointProvider provider)
    {
        Model = request.Model?.GetApiName;
        Prompt = request.Prompt;
        N = request.NumOfImages;
        User = request.User;
        
        // Map response format
        if (request.ResponseFormat.HasValue)
        {
            ResponseFormat = request.ResponseFormat.Value switch
            {
                TornadoImageResponseFormats.Base64 => "b64_json",
                TornadoImageResponseFormats.Url => "url",
                _ => null
            };
        }
        
        if (request.Quality.HasValue)
        {
            Quality = request.Quality.Value switch
            {
                TornadoImageQualities.Low => "low",
                TornadoImageQualities.Medium => "medium",
                TornadoImageQualities.High or TornadoImageQualities.Hd => "high",
                TornadoImageQualities.Auto => "auto",
                _ => null
            };
        }
        
        string? imageDetail = request.VendorExtensions?.XAi?.ImageDetail switch
        {
            ImageDetail.Auto => "auto",
            ImageDetail.High => "high",
            ImageDetail.Low => "low",
            _ => null
        };
        
        if (request.Images is { Count: > 0 })
        {
            List<VendorXAiImageInput> images = [];
            foreach (TornadoInputFile file in request.Images)
            {
                VendorXAiImageInput? input = CreateImageInput(file, imageDetail);
                if (input is not null)
                {
                    images.Add(input);
                }
            }

            Image = images.Count == 1 ? images[0] : images;
        }
        else
        {
            Image = CreateImageInput(request.Image, imageDetail);
        }
        
        // Map mask input
        if (request.Mask?.Base64 is not null)
        {
            string maskUrl = request.Mask.Base64;
            
            // Ensure it has the data URI prefix if it's raw base64
            if (!maskUrl.StartsWith("data:"))
            {
                string mimeType = request.Mask.MimeType ?? "image/png";
                maskUrl = $"data:{mimeType};base64,{maskUrl}";
            }
            
            Mask = new VendorXAiImageInput
            {
                Url = maskUrl,
                Detail = request.VendorExtensions?.XAi?.MaskDetail switch
                {
                    ImageDetail.Auto => "auto",
                    ImageDetail.High => "high",
                    ImageDetail.Low => "low",
                    _ => null
                }
            };
        }
        
        if (request.VendorExtensions?.XAi?.Resolution is not null)
        {
            Resolution = request.VendorExtensions.XAi.Resolution.Value switch
            {
                ImageResolution.Resolution1k => "1k",
                ImageResolution.Resolution2k => "2k",
                _ => null
            };
        }

        if (request.VendorExtensions?.XAi?.AspectRatio is not null)
        {
            AspectRatio = request.VendorExtensions.XAi.AspectRatio.Value switch
            {
                ImageAspectRatio.Square => "1:1",
                ImageAspectRatio.Portrait3x4 => "3:4",
                ImageAspectRatio.Landscape4x3 => "4:3",
                ImageAspectRatio.Portrait9x16 => "9:16",
                ImageAspectRatio.Landscape16x9 => "16:9",
                ImageAspectRatio.Portrait2x3 => "2:3",
                ImageAspectRatio.Landscape3x2 => "3:2",
                ImageAspectRatio.Portrait9x19_5 => "9:19.5",
                ImageAspectRatio.Landscape19_5x9 => "19.5:9",
                ImageAspectRatio.Portrait9x20 => "9:20",
                ImageAspectRatio.Landscape20x9 => "20:9",
                ImageAspectRatio.Portrait1x2 => "1:2",
                ImageAspectRatio.Landscape2x1 => "2:1",
                ImageAspectRatio.Landscape21x9 => "21:9",
                ImageAspectRatio.Landscape5x2 => "5:2",
                ImageAspectRatio.Auto => "auto",
                _ => null
            };
        }
    }

    private static VendorXAiImageInput? CreateImageInput(TornadoInputFile? file, string? detail)
    {
        if (file?.Base64 is null)
        {
            return null;
        }

        string imageUrl = file.Base64;
        if (!imageUrl.StartsWith("data:"))
        {
            string mimeType = file.MimeType ?? "image/png";
            imageUrl = $"data:{mimeType};base64,{imageUrl}";
        }

        return new VendorXAiImageInput
        {
            Url = imageUrl,
            Detail = detail
        };
    }
}

/// <summary>
/// xAI image input structure with URL and optional detail level.
/// </summary>
internal class VendorXAiImageInput
{
    [JsonProperty("url")]
    public string? Url { get; set; }
    
    [JsonProperty("detail")]
    public string? Detail { get; set; }
}
