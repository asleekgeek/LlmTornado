using LlmTornado.Code;
using Newtonsoft.Json;

namespace LlmTornado.Images.Vendors.XAi;

/// <summary>
/// xAI-specific image generation request format.
/// </summary>
internal class VendorXAiImageRequest
{
    [JsonProperty("model")]
    public string? Model { get; set; }
    
    [JsonProperty("prompt")]
    public string? Prompt { get; set; }
    
    [JsonProperty("n")]
    public int? N { get; set; }
    
    [JsonProperty("response_format")]
    public string? ResponseFormat { get; set; }
    
    [JsonProperty("aspect_ratio")]
    public string? AspectRatio { get; set; }
    
    [JsonProperty("resolution")]
    public string? Resolution { get; set; }
    
    [JsonProperty("quality")]
    public string? Quality { get; set; }
    
    [JsonProperty("user")]
    public string? User { get; set; }

    /// <summary>
    /// Creates a new xAI image request from a harmonized ImageGenerationRequest.
    /// </summary>
    public VendorXAiImageRequest(ImageGenerationRequest request, IEndpointProvider provider)
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
        
        // Map aspect ratio from xAI extension if set
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
        else if (request.Size.HasValue)
        {
            // Fallback: map standard sizes to aspect ratios
            AspectRatio = request.Size.Value switch
            {
                TornadoImageSizes.Size256x256 or TornadoImageSizes.Size512x512 or TornadoImageSizes.Size1024x1024 => "1:1",
                TornadoImageSizes.Size896x1280 => "3:4",
                TornadoImageSizes.Size1280x896 => "4:3",
                TornadoImageSizes.Size768x1408 or TornadoImageSizes.Size1024x1792 => "9:16",
                TornadoImageSizes.Size1408x768 or TornadoImageSizes.Size1792x1024 => "16:9",
                TornadoImageSizes.Size1024x1536 => "2:3",
                TornadoImageSizes.Size1536x1024 => "3:2",
                TornadoImageSizes.Auto => "auto",
                _ => null
            };
        }
        
        // Map resolution from xAI extension
        if (request.VendorExtensions?.XAi?.Resolution is not null)
        {
            Resolution = request.VendorExtensions.XAi.Resolution.Value switch
            {
                ImageResolution.Resolution1k => "1k",
                ImageResolution.Resolution2k => "2k",
                _ => null
            };
        }
    }
}
