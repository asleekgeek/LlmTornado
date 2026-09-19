using LlmTornado.Code;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LlmTornado.Chat.Vendors.Alibaba;

internal class VendorAlibabaChatRequest
{
    public VendorAlibabaChatRequestData? ExtendedRequest { get; set; }
    public ChatRequest? NativeRequest { get; set; }
    
    [JsonIgnore]
    public ChatRequest SourceRequest { get; set; }
    
    public JObject Serialize(JsonSerializerSettings settings)
    {
        JsonSerializer serializer = JsonSerializer.CreateDefault(settings);
        JObject jsonPayload = JObject.FromObject(ExtendedRequest ?? NativeRequest ?? SourceRequest, serializer);
        
        return jsonPayload;
    }
    
    public VendorAlibabaChatRequest(ChatRequest request, IEndpointProvider provider)
    {
        SourceRequest = request;
        ExtendedRequest = new VendorAlibabaChatRequestData(request);
    }
}

internal class VendorAlibabaChatRequestData : ChatRequest
{
    /// <summary>
    /// Enables hybrid thinking on Qwen3+ models. Not a standard OpenAI field.
    /// </summary>
    [JsonProperty("enable_thinking")]
    public bool? EnableThinking { get; set; }

    /// <summary>
    /// Caps the number of reasoning tokens.
    /// </summary>
    [JsonProperty("thinking_budget")]
    public int? ThinkingBudget { get; set; }

    /// <summary>
    /// Enables the built-in web search tool.
    /// </summary>
    [JsonProperty("enable_search")]
    public bool? EnableSearch { get; set; }

    /// <summary>
    /// Optional search strategy and force-search flags.
    /// </summary>
    [JsonProperty("search_options")]
    public VendorAlibabaSearchOptions? SearchOptions { get; set; }

    public VendorAlibabaChatRequestData(ChatRequest request) : base(request)
    {
        ChatRequestVendorAlibabaExtensions? extensions = request.VendorExtensions?.Alibaba;

        if (extensions?.EnableThinking is not null)
        {
            EnableThinking = extensions.EnableThinking;
        }
        else if (request.ReasoningEffort is ChatReasoningEfforts.None)
        {
            EnableThinking = false;
        }
        else if (request.ReasoningEffort is not null)
        {
            EnableThinking = true;
        }
        else if (request.ReasoningBudget == 0)
        {
            EnableThinking = false;
        }
        else if (request.ReasoningBudget is > 0 or -1)
        {
            EnableThinking = true;
        }

        if (extensions?.ThinkingBudget is not null)
        {
            ThinkingBudget = extensions.ThinkingBudget;
        }
        else if (request.ReasoningBudget is > 0)
        {
            ThinkingBudget = request.ReasoningBudget;
        }

        EnableSearch = extensions?.EnableSearch;

        if (extensions?.SearchStrategy is not null || extensions?.ForcedSearch is not null)
        {
            SearchOptions = new VendorAlibabaSearchOptions
            {
                SearchStrategy = extensions.SearchStrategy,
                ForcedSearch = extensions.ForcedSearch
            };
        }
    }
}
