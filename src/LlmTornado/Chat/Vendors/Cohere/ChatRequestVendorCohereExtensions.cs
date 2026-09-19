using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LlmTornado.Chat.Vendors.Cohere;

/// <summary>
///     Chat features supported only by Cohere.
/// </summary>
public class ChatRequestVendorCohereExtensions
{
    /// <summary>
    ///     When specified, the model's reply will be enriched with information found by quering each of the connectors (RAG).
    /// </summary>
    [JsonProperty("connectors")]
    public List<ChatVendorCohereExtensionConnector>? Connectors { get; set; }
    
    /// <summary>
    ///     An alternative to chat_history. Providing a conversation_id creates or resumes a persisted conversation with the specified ID. The ID can be any non empty string.
    /// </summary>
    [JsonProperty("conversation_id")]
    public string? ConversationId { get; set; }
    
    /// <summary>
    ///     Dictates how the prompt will be constructed.
    /// </summary>
    [JsonProperty("prompt_truncation")]
    public ChatVendorCohereExtensionPromptTruncation? PromptTruncation { get; set; }
    
    /// <summary>
    ///     Dictates the approach taken to generating citations as part of the RAG flow by allowing the user to specify whether they want "accurate" results, "fast" results or no results.
    /// </summary>
    [JsonProperty("citation_quality")]
    public ChatVendorCohereExtensionCitationQuality? CitationQuality { get; set; }

    /// <summary>
    ///     Forces the chat to be single step. Defaults to false.
    /// </summary>
    [JsonProperty("force_single_step")]
    public bool? ForceSingleStep { get; set; }
    
    /// <summary>
    ///     Used to select the safety instruction inserted into the prompt. Defaults to CONTEXTUAL. When NONE is specified, the safety instruction will be omitted.
    /// </summary>
    [JsonProperty("safety_mode")]
    public ChatVendorCohereExtensionSafetyMode? SafetyMode { get; set; }
    
    /// <summary>
    ///     Thinking configuration for Command A Reasoning and Command A+. When set, overrides
    ///     <see cref="ChatRequest.ReasoningEffort"/> and <see cref="ChatRequest.ReasoningBudget"/>.
    /// </summary>
    [JsonProperty("thinking")]
    public ChatRequestVendorCohereThinking? Thinking { get; set; }
    
    /// <summary>
    ///     Empty Cohere extensions.
    /// </summary>
    public ChatRequestVendorCohereExtensions()
    {
        
    }

    /// <summary>
    ///     RAG Connectors.
    /// </summary>
    /// <param name="connectors"></param>
    public ChatRequestVendorCohereExtensions(List<ChatVendorCohereExtensionConnector> connectors)
    {
        Connectors = connectors;
    }
}

/// <summary>
/// Controls Cohere hybrid reasoning (thinking) for Command A Reasoning and Command A+.
/// </summary>
public class ChatRequestVendorCohereThinking
{
    /// <summary>
    /// Enable or disable thinking. Reasoning models default to enabled when this is omitted.
    /// </summary>
    [JsonProperty("type")]
    public ChatVendorCohereThinkingType? Type { get; set; }
    
    /// <summary>
    /// Upper limit on thinking tokens. Leave at least 1K tokens for the final response.
    /// </summary>
    [JsonProperty("token_budget")]
    public int? TokenBudget { get; set; }
}

/// <summary>
/// Thinking types for Cohere reasoning models.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum ChatVendorCohereThinkingType
{
    /// <summary>
    /// Enable thinking. This is the default for reasoning models.
    /// </summary>
    [EnumMember(Value = "enabled")]
    Enabled,
    
    /// <summary>
    /// Disable thinking; the model behaves like a standard LLM.
    /// </summary>
    [EnumMember(Value = "disabled")]
    Disabled
}