using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using LlmTornado.Audio.Models.Cohere;
using LlmTornado.Code;

namespace LlmTornado.Audio.Vendors.Cohere;

/// <summary>
/// Handles audio transcription for Cohere Transcribe.
/// </summary>
internal static class VendorCohereAudioHandler
{
    public static MultipartFormDataContent SerializeRequest(TranscriptionRequest request)
    {
        MultipartFormDataContent content = new MultipartFormDataContent();

        content.Add(new StringContent(request.Model?.Name ?? AudioModelCohereTranscribe.ModelV0326.Name), "model");

        if (!request.Language.IsNullOrWhiteSpace())
        {
            content.Add(new StringContent(request.Language), "language");
        }

        if (request.Temperature.HasValue)
        {
            content.Add(new StringContent(request.Temperature.Value.ToString(CultureInfo.InvariantCulture)), "temperature");
        }

        if (request.File?.Data is not null)
        {
            MemoryStream ms = new MemoryStream(request.File.Data);
            StreamContent sc = new StreamContent(ms);
            sc.Headers.ContentLength = request.File.Data.Length;
            sc.Headers.ContentType = new MediaTypeHeaderValue(request.File.GetContentType);
            content.Add(sc, "file", GetFileName(request.File.ContentType));
        }
        else if (request.File?.File is not null)
        {
            StreamContent sc = new StreamContent(request.File.File);
            sc.Headers.ContentLength = request.File.File.Length;
            sc.Headers.ContentType = new MediaTypeHeaderValue(request.File.GetContentType);
            content.Add(sc, "file", GetFileName(request.File.ContentType));
        }

        return content;
    }

    public static async Task<TranscriptionResult?> CreateTranscription(
        TranscriptionRequest request,
        IEndpointProvider provider,
        EndpointBase endpoint,
        CancellationToken cancellationToken)
    {
        string url = provider.ApiUrl(CapabilityEndpoints.Audio, "/transcriptions");

        using MultipartFormDataContent content = SerializeRequest(request);

        return await endpoint.HttpPost1<TranscriptionResult>(
            provider,
            CapabilityEndpoints.Audio,
            url,
            content,
            request.Model,
            request,
            cancellationToken
        ).ConfigureAwait(false);
    }

    private static string GetFileName(AudioFileTypes contentType)
    {
        return contentType switch
        {
            AudioFileTypes.Wav => "audio.wav",
            AudioFileTypes.Mp3 => "audio.mp3",
            AudioFileTypes.Flac => "audio.flac",
            AudioFileTypes.Mpeg => "audio.mpeg",
            AudioFileTypes.Mpga => "audio.mpga",
            AudioFileTypes.Ogg => "audio.ogg",
            _ => "audio.wav"
        };
    }
}
