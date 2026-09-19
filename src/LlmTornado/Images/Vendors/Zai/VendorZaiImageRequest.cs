using LlmTornado.Code;
using Newtonsoft.Json;

namespace LlmTornado.Images.Vendors.Zai;

/// <summary>
/// Z.AI image generation request. Maps to POST /paas/v4/images/generations.
/// </summary>
internal class VendorZaiImageRequest
{
    [JsonProperty("model")]
    public string? Model { get; set; }

    [JsonProperty("prompt")]
    public string? Prompt { get; set; }

    [JsonProperty("quality")]
    public string? Quality { get; set; }

    [JsonProperty("size")]
    public string? Size { get; set; }

    [JsonProperty("user_id")]
    public string? UserId { get; set; }

    public VendorZaiImageRequest(ImageGenerationRequest request, IEndpointProvider provider)
    {
        Model = request.Model?.GetApiName;
        Prompt = request.Prompt;
        UserId = request.User;
        Size = ImageGenerationRequest.GetSizeString(request.Size, request.Width, request.Height);

        if (request.Quality.HasValue)
        {
            Quality = request.Quality.Value switch
            {
                TornadoImageQualities.Hd or TornadoImageQualities.High => "hd",
                TornadoImageQualities.Standard or TornadoImageQualities.Medium or TornadoImageQualities.Low => "standard",
                _ => null
            };
        }
    }
}
