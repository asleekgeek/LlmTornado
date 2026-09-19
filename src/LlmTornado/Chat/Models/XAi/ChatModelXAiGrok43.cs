using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models.XAi;

/// <summary>
/// Grok 4.3 class models from xAI.
/// </summary>
public class ChatModelXAiGrok43 : IVendorModelClassProvider
{
    /// <summary>
    /// Grok 4.3 is a fast, reliable model with strong tool calling and instruction following.
    /// 1M context window, text and image input. Batch API supported.
    /// Reasoning effort: none, low (default), medium, high, or xhigh.
    /// Retired Grok 4 / 4.1 Fast / 4 Fast / Grok 3 slugs redirect here after May 15, 2026.
    /// </summary>
    public static readonly ChatModel ModelV43 = new ChatModel("grok-4.3", LLmProviders.XAi, 1_000_000, [ "grok-4.3-latest" ]);

    /// <summary>
    /// <inheritdoc cref="ModelV43"/>
    /// </summary>
    public readonly ChatModel V43 = ModelV43;
    
    /// <summary>
    /// All Grok 4.3 models.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelV43
    ]);
    
    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;
    
    internal ChatModelXAiGrok43()
    {
        
    }
}
