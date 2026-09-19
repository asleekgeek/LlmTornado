using Newtonsoft.Json;

namespace LlmTornado.Chat.Vendors.Alibaba;

/// <summary>
/// Chat features supported only by Alibaba Cloud Model Studio (DashScope).
/// </summary>
public class ChatRequestVendorAlibabaExtensions
{
    /// <summary>
    /// Overrides thinking mode. When unset, thinking is derived from <see cref="ChatRequest.ReasoningEffort"/>
    /// and <see cref="ChatRequest.ReasoningBudget"/>.
    /// </summary>
    public bool? EnableThinking { get; set; }

    /// <summary>
    /// Caps reasoning tokens. When unset, <see cref="ChatRequest.ReasoningBudget"/> is used if greater than zero.
    /// </summary>
    public int? ThinkingBudget { get; set; }

    /// <summary>
    /// Enables the built-in web search tool on supported Qwen models.
    /// </summary>
    public bool? EnableSearch { get; set; }

    /// <summary>
    /// Web search strategy. <c>agent</c> lets the model decide when to search.
    /// <c>agent_max</c> allows multiple searches and page extraction on supported models.
    /// </summary>
    public string? SearchStrategy { get; set; }

    /// <summary>
    /// When true, the model must search before answering.
    /// </summary>
    public bool? ForcedSearch { get; set; }
}

/// <summary>
/// DashScope <c>search_options</c> payload.
/// </summary>
public class VendorAlibabaSearchOptions
{
    /// <summary>
    /// Search strategy. Typically <c>agent</c> or <c>agent_max</c>.
    /// </summary>
    [JsonProperty("search_strategy")]
    public string? SearchStrategy { get; set; }

    /// <summary>
    /// When true, the model must search before answering.
    /// </summary>
    [JsonProperty("forced_search")]
    public bool? ForcedSearch { get; set; }
}
