namespace LlmTornado.Chat.Vendors.MiniMax;

/// <summary>
/// Chat features supported only by MiniMax.
/// </summary>
public class ChatRequestVendorMiniMaxExtensions
{
    /// <summary>
    /// Thinking control for MiniMax-M3. When omitted, thinking is on by default for M3.
    /// M2.x models always think; disabling is accepted but ignored.
    /// Harmonized <see cref="ChatRequest.ReasoningBudget"/> also maps here: 0 disables thinking, -1 enables adaptive thinking.
    /// </summary>
    public ChatRequestVendorMiniMaxThinking? Thinking { get; set; }
    
    /// <summary>
    /// When true, thinking is returned in <c>reasoning_content</c> / <c>reasoning_details</c> instead of
    /// being inlined into <c>content</c> with think tags. Defaults to true so the library can preserve the reasoning chain.
    /// </summary>
    public bool? ReasoningSplit { get; set; }
    
    /// <summary>
    /// Request admission tier. <c>standard</c> (default) or <c>priority</c> (1.5x price, faster admission).
    /// <see cref="ChatRequest.ServiceTier"/> = <see cref="Code.ChatRequestServiceTiers.Priority"/> also maps to priority.
    /// </summary>
    public ChatRequestVendorMiniMaxServiceTier? ServiceTier { get; set; }
}

/// <summary>
/// MiniMax thinking settings.
/// </summary>
public class ChatRequestVendorMiniMaxThinking
{
    /// <summary>
    /// Thinking mode. <see cref="ChatRequestVendorMiniMaxThinkingTypes.Adaptive"/> keeps thinking on;
    /// <see cref="ChatRequestVendorMiniMaxThinkingTypes.Disabled"/> skips thinking on MiniMax-M3.
    /// </summary>
    public ChatRequestVendorMiniMaxThinkingTypes? Type { get; set; }
    
    /// <summary>
    /// Enable adaptive thinking (default MiniMax-M3 behavior).
    /// </summary>
    public static ChatRequestVendorMiniMaxThinking Adaptive() => new ChatRequestVendorMiniMaxThinking
    {
        Type = ChatRequestVendorMiniMaxThinkingTypes.Adaptive
    };
    
    /// <summary>
    /// Disable thinking and answer directly (MiniMax-M3 only).
    /// </summary>
    public static ChatRequestVendorMiniMaxThinking Disabled() => new ChatRequestVendorMiniMaxThinking
    {
        Type = ChatRequestVendorMiniMaxThinkingTypes.Disabled
    };
}

/// <summary>
/// MiniMax thinking modes.
/// </summary>
public enum ChatRequestVendorMiniMaxThinkingTypes
{
    /// <summary>
    /// Thinking is on. For MiniMax-M3 this is equivalent to the default omitted-parameter behavior.
    /// </summary>
    Adaptive,
    
    /// <summary>
    /// Skip thinking and answer directly. Honored by MiniMax-M3; ignored by M2.x models.
    /// </summary>
    Disabled
}

/// <summary>
/// MiniMax request admission tiers.
/// </summary>
public enum ChatRequestVendorMiniMaxServiceTier
{
    /// <summary>
    /// Default admission.
    /// </summary>
    Standard,
    
    /// <summary>
    /// Priority admission at 1.5x price.
    /// </summary>
    Priority
}
