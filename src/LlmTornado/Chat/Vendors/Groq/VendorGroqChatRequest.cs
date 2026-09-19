using System.Collections.Generic;
using LlmTornado.Code;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LlmTornado.Chat.Vendors.Groq;

internal class VendorGroqChatRequest
{
    public VendorGroqChatRequestData? ExtendedRequest { get; set; }
    public ChatRequest? NativeRequest { get; set; }

    [JsonIgnore]
    public ChatRequest SourceRequest { get; set; }

    public JObject Serialize(JsonSerializerSettings settings)
    {
        JsonSerializer serializer = JsonSerializer.CreateDefault(settings);
        return JObject.FromObject(ExtendedRequest ?? NativeRequest!, serializer);
    }

    public VendorGroqChatRequest(ChatRequest request, IEndpointProvider _)
    {
        SourceRequest = request;
        ChatRequestVendorGroqExtensions? extensions = request.VendorExtensions?.Groq;

        if (extensions?.SearchSettings is not null || extensions?.CompoundCustom is not null)
        {
            ExtendedRequest = new VendorGroqChatRequestData(request);

            if (extensions.SearchSettings is not null)
            {
                ExtendedRequest.SearchSettings = new VendorGroqChatRequestSearchSettings
                {
                    IncludeDomains = extensions.SearchSettings.IncludeDomains,
                    ExcludeDomains = extensions.SearchSettings.ExcludeDomains,
                    IncludeImages = extensions.SearchSettings.IncludeImages,
                    Country = extensions.SearchSettings.Country
                };
            }

            if (extensions.CompoundCustom is not null)
            {
                ExtendedRequest.CompoundCustom = new VendorGroqChatRequestCompoundCustom
                {
                    Tools = extensions.CompoundCustom.Tools is null
                        ? null
                        : new VendorGroqChatRequestCompoundTools
                        {
                            EnabledTools = extensions.CompoundCustom.Tools.EnabledTools
                        }
                };
            }
        }
        else
        {
            NativeRequest = request;
        }
    }
}

internal class VendorGroqChatRequestData : ChatRequest
{
    [JsonProperty("search_settings")]
    public VendorGroqChatRequestSearchSettings? SearchSettings { get; set; }

    [JsonProperty("compound_custom")]
    public VendorGroqChatRequestCompoundCustom? CompoundCustom { get; set; }

    public VendorGroqChatRequestData(ChatRequest request) : base(request)
    {
    }
}

internal class VendorGroqChatRequestSearchSettings
{
    [JsonProperty("include_domains")]
    public List<string>? IncludeDomains { get; set; }

    [JsonProperty("exclude_domains")]
    public List<string>? ExcludeDomains { get; set; }

    [JsonProperty("include_images")]
    public bool? IncludeImages { get; set; }

    [JsonProperty("country")]
    public string? Country { get; set; }
}

internal class VendorGroqChatRequestCompoundCustom
{
    [JsonProperty("tools")]
    public VendorGroqChatRequestCompoundTools? Tools { get; set; }
}

internal class VendorGroqChatRequestCompoundTools
{
    [JsonProperty("enabled_tools")]
    public List<string>? EnabledTools { get; set; }
}
