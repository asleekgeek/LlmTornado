using System;
using LlmTornado.Chat.Models.MoonshotAi;
using LlmTornado.ChatFunctions;
using LlmTornado.Code;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LlmTornado.Chat.Vendors.MoonshotAi;

/// <summary>
/// https://platform.kimi.ai/docs/api/chat
/// </summary>
internal class VendorMoonshotAiChatRequest
{
    public VendorMoonshotAiChatRequestData? ExtendedRequest { get; set; }
    public ChatRequest? NativeRequest { get; set; }
    
    [JsonIgnore]
    public ChatRequest SourceRequest { get; set; }
    
    public JObject Serialize(JsonSerializerSettings settings)
    {
        JsonSerializer serializer = JsonSerializer.CreateDefault(settings);
        return JObject.FromObject(ExtendedRequest ?? NativeRequest, serializer);
    }
    
    public VendorMoonshotAiChatRequest(ChatRequest request, IEndpointProvider provider)
    {
        SourceRequest = request;

        string? modelName = request.Model?.Name;
        bool isK3 = ChatModelMoonshotAiModels.IsK3(modelName);
        bool isK27 = ChatModelMoonshotAiModels.IsK27(modelName);
        bool isK26 = ChatModelMoonshotAiModels.IsK26(modelName);
        bool isK25 = ChatModelMoonshotAiModels.IsK25(modelName);
        bool usesFixedSampling = ChatModelMoonshotAiModels.UsesFixedSampling(modelName);

        ChatReasoningEfforts? originalEffort = request.ReasoningEffort;
        int? originalBudget = request.ReasoningBudget;
        bool thinkingDisabled = originalBudget == 0 || originalEffort is ChatReasoningEfforts.None;

        // tool_choice=required is only accepted by K3
        if (!isK3 && request.ToolChoice == OutboundToolChoice.Required)
        {
            request.ToolChoice = OutboundToolChoice.Auto;
        }

        if (usesFixedSampling)
        {
            // K2.5+ reject any non-default sampling values
            request.Temperature = null;
            request.TopP = null;
            request.NumChoicesPerMessage = null;
            request.PresencePenalty = null;
            request.FrequencyPenalty = null;
        }
        else if (request.Temperature is not null)
        {
            request.Temperature = Math.Clamp(request.Temperature.Value, 0, 1);
        }

        if (isK3)
        {
            request.ReasoningEffort = MapK3ReasoningEffort(originalEffort);
            ExtendedRequest = new VendorMoonshotAiChatRequestData(request);
            return;
        }

        // K2.x does not accept top-level reasoning_effort
        request.ReasoningEffort = null;

        if (isK27)
        {
            // Always-on thinking; omit the thinking object (keep=all is implied)
            NativeRequest = request;
            return;
        }

        if (isK26 || isK25)
        {
            VendorMoonshotAiThinking thinking = new VendorMoonshotAiThinking
            {
                Type = thinkingDisabled ? "disabled" : "enabled"
            };

            if (isK26 && !thinkingDisabled)
            {
                thinking.Keep = "all";
            }

            ExtendedRequest = new VendorMoonshotAiChatRequestData(request)
            {
                Thinking = thinking
            };
            return;
        }

        NativeRequest = request;
    }

    internal static ChatReasoningEfforts? MapK3ReasoningEffort(ChatReasoningEfforts? effort)
    {
        return effort switch
        {
            null or ChatReasoningEfforts.Default => null,
            ChatReasoningEfforts.None or ChatReasoningEfforts.Minimal or ChatReasoningEfforts.Low => ChatReasoningEfforts.Low,
            ChatReasoningEfforts.Medium or ChatReasoningEfforts.High => ChatReasoningEfforts.High,
            ChatReasoningEfforts.XHigh or ChatReasoningEfforts.Max => ChatReasoningEfforts.Max,
            _ => ChatReasoningEfforts.Low
        };
    }
}

/// <summary>
/// Extended chat request data for MoonshotAi with vendor-specific fields.
/// </summary>
internal class VendorMoonshotAiChatRequestData : ChatRequest
{
    /// <summary>
    /// Controls thinking mode for Kimi K2.x models that accept the <c>thinking</c> parameter.
    /// </summary>
    [JsonProperty("thinking")]
    public VendorMoonshotAiThinking? Thinking { get; set; }
    
    public VendorMoonshotAiChatRequestData(ChatRequest request) : base(request)
    {
    }
}

/// <summary>
/// Thinking parameter for Kimi K2.5 / K2.6 models.
/// </summary>
internal class VendorMoonshotAiThinking
{
    /// <summary>
    /// "enabled" or "disabled"
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; } = "enabled";

    /// <summary>
    /// When set to "all", K2.6 preserves reasoning content across turns (Preserved Thinking).
    /// </summary>
    [JsonProperty("keep")]
    public string? Keep { get; set; }
}
