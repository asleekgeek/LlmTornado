using System.Collections.Generic;
using Newtonsoft.Json;

namespace LlmTornado.Chat.Vendors.Groq;

/// <summary>
/// Inbound Groq-only chat fields.
/// </summary>
public class ChatResponseVendorGroqExtensions
{
    /// <summary>
    /// Per-model usage reported by Compound systems.
    /// </summary>
    public ChatGroqUsageBreakdown? UsageBreakdown { get; set; }
}

/// <summary>
/// Compound <c>usage_breakdown</c> payload.
/// </summary>
public class ChatGroqUsageBreakdown
{
    /// <summary>
    /// Underlying models invoked while answering the request.
    /// </summary>
    [JsonProperty("models")]
    public List<ChatGroqUsageBreakdownModel>? Models { get; set; }
}

/// <summary>
/// One model entry inside Compound <c>usage_breakdown</c>.
/// </summary>
public class ChatGroqUsageBreakdownModel
{
    /// <summary>
    /// Model identifier.
    /// </summary>
    [JsonProperty("model")]
    public string? Model { get; set; }

    /// <summary>
    /// Token and timing usage for this model.
    /// </summary>
    [JsonProperty("usage")]
    public ChatGroqUsageBreakdownUsage? Usage { get; set; }
}

/// <summary>
/// Usage reported for a single Compound underlying model.
/// </summary>
public class ChatGroqUsageBreakdownUsage
{
    /// <summary>
    /// Queue wait time in seconds.
    /// </summary>
    [JsonProperty("queue_time")]
    public double? QueueTime { get; set; }

    /// <summary>
    /// Prompt tokens.
    /// </summary>
    [JsonProperty("prompt_tokens")]
    public int? PromptTokens { get; set; }

    /// <summary>
    /// Prompt processing time in seconds.
    /// </summary>
    [JsonProperty("prompt_time")]
    public double? PromptTime { get; set; }

    /// <summary>
    /// Completion tokens.
    /// </summary>
    [JsonProperty("completion_tokens")]
    public int? CompletionTokens { get; set; }

    /// <summary>
    /// Completion generation time in seconds.
    /// </summary>
    [JsonProperty("completion_time")]
    public double? CompletionTime { get; set; }

    /// <summary>
    /// Total tokens.
    /// </summary>
    [JsonProperty("total_tokens")]
    public int? TotalTokens { get; set; }

    /// <summary>
    /// Total time in seconds.
    /// </summary>
    [JsonProperty("total_time")]
    public double? TotalTime { get; set; }
}

/// <summary>
/// A server-side tool execution recorded on a Compound assistant message.
/// </summary>
public class ChatGroqExecutedTool
{
    /// <summary>
    /// Tool index.
    /// </summary>
    [JsonProperty("index")]
    public int? Index { get; set; }

    /// <summary>
    /// Tool type, for example <c>search</c> or <c>code_interpreter</c>.
    /// </summary>
    [JsonProperty("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Arguments passed to the tool.
    /// </summary>
    [JsonProperty("arguments")]
    public string? Arguments { get; set; }

    /// <summary>
    /// Text output from the tool.
    /// </summary>
    [JsonProperty("output")]
    public string? Output { get; set; }

    /// <summary>
    /// Structured code-execution results (text and optional base64 PNG).
    /// </summary>
    [JsonProperty("code_results")]
    public ChatGroqCodeResults? CodeResults { get; set; }

    /// <summary>
    /// Additional fields returned by Groq.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, object>? ExtensionData { get; set; }
}

/// <summary>
/// Code execution artifacts from Compound.
/// </summary>
public class ChatGroqCodeResults
{
    /// <summary>
    /// Text output of the code execution.
    /// </summary>
    [JsonProperty("text")]
    public string? Text { get; set; }

    /// <summary>
    /// Image produced by the code, encoded as Base64 PNG.
    /// </summary>
    [JsonProperty("png")]
    public string? Png { get; set; }
}
