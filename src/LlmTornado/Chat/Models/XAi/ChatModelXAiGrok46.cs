using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models.XAi;

/// <summary>
/// Grok 4.6 class models from xAI.
/// </summary>
public class ChatModelXAiGrok46 : IVendorModelClassProvider
{
    /// <summary>
    /// Grok 4.6 is xAI's frontier model for coding, agentic tasks, and knowledge work.
    /// 500K context window, text and image input, no text output limit.
    /// Reasoning effort: low, medium, high (default), or xhigh.
    /// Released August 2026.
    /// </summary>
    public static readonly ChatModel ModelV46 = new ChatModel("grok-4.6", LLmProviders.XAi, 500_000, [ "grok-4.6-latest", "grok-build-latest" ]);

    /// <summary>
    /// <inheritdoc cref="ModelV46"/>
    /// </summary>
    public readonly ChatModel V46 = ModelV46;
    
    /// <summary>
    /// All Grok 4.6 models.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelV46
    ]);
    
    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;
    
    internal ChatModelXAiGrok46()
    {
        
    }
}
