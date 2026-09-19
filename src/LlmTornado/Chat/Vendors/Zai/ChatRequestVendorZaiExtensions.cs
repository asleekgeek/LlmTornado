using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LlmTornado.Chat.Vendors.Zai;

/// <summary>
/// Chat features supported only by ZAI.
/// </summary>
public class ChatRequestVendorZaiExtensions
{
    /// <summary>
    /// Whether to enable sampling strategy.
    /// </summary>
    public bool? DoSample { get; set; }
    
    /// <summary>
    /// Unique request ID for tracking.
    /// </summary>
    public string? RequestId { get; set; }
    
    /// <summary>
    /// Whether to enable streaming response for Function Calls.
    /// Supported since GLM-4.6; recommended for GLM-5.3-Flash streaming tool use.
    /// </summary>
    public bool? ToolStream { get; set; }
    
    /// <summary>
    /// Built-in tools supported by ZAI.
    /// </summary>
    public List<IVendorZaiChatRequestBuiltInTool>? BuiltInTools { get; set; }
    
    /// <summary>
    /// Thinking configuration. When set, overrides the thinking settings derived from <see cref="ChatRequest.ReasoningEffort"/>
    /// and <see cref="ChatRequest.ReasoningBudget"/>. Use this to control advanced features such as Preserved Thinking
    /// (<see cref="ChatRequestVendorZaiThinking.ClearThinking"/> set to false).
    /// </summary>
    public ChatRequestVendorZaiThinking? Thinking { get; set; }
}

