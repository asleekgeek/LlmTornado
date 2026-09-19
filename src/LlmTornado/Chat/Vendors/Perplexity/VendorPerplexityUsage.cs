using LlmTornado.Code;
using Newtonsoft.Json;

namespace LlmTornado.Chat.Vendors.Perplexity;

/// <summary>
/// Usage reported by Perplexity (Sonar Chat Completions and the Agent API).
/// </summary>
public class VendorPerplexityUsage : Usage, IChatUsage
{
   /// <summary>
   /// Number of tokens in the completion (Sonar).
   /// </summary>
   [JsonProperty("completion_tokens")]
   public int CompletionTokens { get; set; }

   /// <summary>
   /// Number of input tokens (Agent API).
   /// </summary>
   [JsonProperty("input_tokens")]
   public int? InputTokens { get; set; }

   /// <summary>
   /// Number of output tokens (Agent API).
   /// </summary>
   [JsonProperty("output_tokens")]
   public int? OutputTokens { get; set; }
    
   /// <summary>
   /// The search context size for the request.
   /// </summary>
   [JsonProperty("search_context_size")]
   public string? SearchContextSize { get; set; }

   /// <summary>
   /// Cached / input token details when provided by the Agent API.
   /// </summary>
   [JsonProperty("input_tokens_details")]
   public VendorPerplexityInputTokenDetails? InputTokensDetails { get; set; }

   /// <summary>
   /// Output token details when provided by the Agent API.
   /// </summary>
   [JsonProperty("output_tokens_details")]
   public VendorPerplexityOutputTokenDetails? OutputTokensDetails { get; set; }

   /// <summary>
   /// Tool-call usage details when provided by the Agent API.
   /// </summary>
   [JsonProperty("tool_calls_details")]
   public VendorPerplexityToolCallsDetails? ToolCallsDetails { get; set; }

   /// <summary>
   /// Detailed cost information for the request.
   /// </summary>
   [JsonProperty("cost")]
   public VendorPerplexityUsageCost? Cost { get; set; }
}

/// <summary>
/// Agent API input token breakdown.
/// </summary>
public class VendorPerplexityInputTokenDetails
{
   /// <summary>
   /// Tokens written to the prompt cache.
   /// </summary>
   [JsonProperty("cache_creation_input_tokens")]
   public int? CacheCreationInputTokens { get; set; }

   /// <summary>
   /// Tokens read from the prompt cache.
   /// </summary>
   [JsonProperty("cache_read_input_tokens")]
   public int? CacheReadInputTokens { get; set; }

   /// <summary>
   /// Cached tokens.
   /// </summary>
   [JsonProperty("cached_tokens")]
   public int? CachedTokens { get; set; }
}

/// <summary>
/// Agent API output token breakdown.
/// </summary>
public class VendorPerplexityOutputTokenDetails
{
   /// <summary>
   /// Reasoning tokens billed at the output-token rate.
   /// </summary>
   [JsonProperty("reasoning_tokens")]
   public int? ReasoningTokens { get; set; }
}

/// <summary>
/// Agent API tool-call usage.
/// </summary>
public class VendorPerplexityToolCallsDetails
{
   /// <summary>
   /// Web search invocations.
   /// </summary>
   [JsonProperty("search_web")]
   public VendorPerplexityToolInvocation? SearchWeb { get; set; }
}

/// <summary>
/// A single tool invocation count.
/// </summary>
public class VendorPerplexityToolInvocation
{
   /// <summary>
   /// Number of times the tool was invoked.
   /// </summary>
   [JsonProperty("invocation")]
   public int Invocation { get; set; }
}

/// <summary>
/// Detailed cost breakdown for a Perplexity API request.
/// </summary>
public class VendorPerplexityUsageCost
{
   /// <summary>
   /// Cost attributed to input tokens (Sonar).
   /// </summary>
   [JsonProperty("input_tokens_cost")]
   public double? InputTokensCost { get; set; }

   /// <summary>
   /// Cost attributed to output tokens (Sonar).
   /// </summary>
   [JsonProperty("output_tokens_cost")]
   public double? OutputTokensCost { get; set; }

   /// <summary>
   /// Fixed cost per request (Sonar).
   /// </summary>
   [JsonProperty("request_cost")]
   public double? RequestCost { get; set; }

   /// <summary>
   /// Input cost (Agent API).
   /// </summary>
   [JsonProperty("input_cost")]
   public double? InputCost { get; set; }

   /// <summary>
   /// Output cost (Agent API).
   /// </summary>
   [JsonProperty("output_cost")]
   public double? OutputCost { get; set; }

   /// <summary>
   /// Prompt-cache write cost (Agent API).
   /// </summary>
   [JsonProperty("cache_creation_cost")]
   public double? CacheCreationCost { get; set; }

   /// <summary>
   /// Prompt-cache read cost (Agent API).
   /// </summary>
   [JsonProperty("cache_read_cost")]
   public double? CacheReadCost { get; set; }

   /// <summary>
   /// Tool-call cost (Agent API).
   /// </summary>
   [JsonProperty("tool_calls_cost")]
   public double? ToolCallsCost { get; set; }

   /// <summary>
   /// Currency of the cost values.
   /// </summary>
   [JsonProperty("currency")]
   public string? Currency { get; set; }

   /// <summary>
   /// The total cost for this API call.
   /// </summary>
   [JsonProperty("total_cost")]
   public double TotalCost { get; set; }
}
