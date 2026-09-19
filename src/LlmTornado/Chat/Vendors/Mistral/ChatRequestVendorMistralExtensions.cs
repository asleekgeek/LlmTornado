using System.Collections.Generic;
using System.Runtime.Serialization;
using LlmTornado.Caching;
using LlmTornado.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LlmTornado.Chat.Vendors.Mistral;

/// <summary>
/// Chat features supported only by Mistral.
/// </summary>
public class ChatRequestVendorMistralExtensions
{
    /// <summary>
    /// Prompt preset mode. Set to reasoning to enable Mistral reasoning system prompt for supported models; leave unset to use default behavior (no system prompt override).
    /// </summary>
    public MistralPromptMode? PromptMode { get; set; }
    
    /// <summary>
    /// Whether to inject a safety prompt before all conversations.
    /// </summary>
    public bool? SafePrompt { get; set; }
    
    /// <summary>
    /// Enable users to specify expected results, optimizing response times by leveraging known or predictable content. This approach is especially effective for updating text documents or code files with minimal changes, reducing latency while maintaining high-quality results.
    /// </summary>
    public string? Prediction { get; set; }
    
    /// <summary>
    /// Random Seed (integer) or Random Seed (null) (Random Seed)
    /// The seed to use for random sampling. If set, different calls will generate deterministic results.
    /// </summary>
    public int? RandomSeed { get; set; }
    
    /// <summary>
    /// The role of the prefix message is to force the model to start its answer by the content of the message.
    /// Important: the conversation has to end with a user message for the prefix to be applied (at the time of sending the request).
    /// </summary>
    public string? Prefix { get; set; }
    
    /// <summary>
    /// Custom guardrails evaluated on the chat completion request. Violations return HTTP 403.
    /// Added March 2026; use <see cref="MistralGuardrail.ModerationLlmV2"/> (v1 is deprecated).
    /// </summary>
    public List<MistralGuardrail>? Guardrails { get; set; }
}

/// <summary>
/// A single guardrail configuration for Mistral chat completions.
/// </summary>
public class MistralGuardrail
{
    /// <summary>
    /// When true, the request is blocked if the moderation API itself fails.
    /// </summary>
    [JsonProperty("block_on_error")]
    public bool? BlockOnError { get; set; }
    
    /// <summary>
    /// Optional override for the moderation model (defaults to <c>mistral-moderation-2603</c>).
    /// </summary>
    [JsonProperty("model_name")]
    public string? ModelName { get; set; }
    
    /// <summary>
    /// Current moderation guardrail backed by Mistral Moderation 2.
    /// </summary>
    [JsonProperty("moderation_llm_v2")]
    public MistralModerationLlm? ModerationLlmV2 { get; set; }
}

/// <summary>
/// Thresholds and action for a Mistral LLM moderation guardrail.
/// </summary>
public class MistralModerationLlm
{
    /// <summary>
    /// Category name to score threshold (0–1). Categories typically include sexual, hate, violence, selfharm, and others.
    /// </summary>
    [JsonProperty("custom_category_thresholds")]
    public Dictionary<string, double>? CustomCategoryThresholds { get; set; }
    
    /// <summary>
    /// When true, only categories listed in <see cref="CustomCategoryThresholds"/> are evaluated.
    /// </summary>
    [JsonProperty("ignore_other_categories")]
    public bool? IgnoreOtherCategories { get; set; }
    
    /// <summary>
    /// Action on violation. Currently <c>block</c>.
    /// </summary>
    [JsonProperty("action")]
    public string? Action { get; set; }
}

/// <summary>
/// Mistral-specific prompt presets.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum MistralPromptMode
{
    /// <summary>
    /// Use the reasoning system prompt (enables Mistral reasoning prompt mode).
    /// </summary>
    [EnumMember(Value = "reasoning")]
    Reasoning
}