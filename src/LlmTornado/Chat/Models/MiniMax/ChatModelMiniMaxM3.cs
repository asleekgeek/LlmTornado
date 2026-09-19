using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models.MiniMax;

/// <summary>
/// M3 series models from MiniMax.
/// </summary>
public class ChatModelMiniMaxM3 : IVendorModelClassProvider
{
    /// <summary>
    /// Latest M-series language model for agentic reasoning, tool use, coding, multimodal chat input, and long-context tasks.
    /// 1,000,000 token context window. Supports text, image, and video input. Thinking is on by default and can be disabled.
    /// Output speed approximately 100+ tps. Released June 1, 2026.
    /// </summary>
    public static readonly ChatModel ModelM3 = new ChatModel("MiniMax-M3", LLmProviders.MiniMax, 1_000_000);
    
    /// <summary>
    /// <inheritdoc cref="ModelM3"/>
    /// </summary>
    public readonly ChatModel M3 = ModelM3;
    
    /// <summary>
    /// All known M3 series models from MiniMax.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [ModelM3]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;

    internal ChatModelMiniMaxM3()
    {

    }
}
