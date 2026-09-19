using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models;

/// <summary>
/// MiniMax models hosted by Groq.
/// </summary>
public class ChatModelGroqMiniMax : IVendorModelClassProvider
{
    /// <summary>
    /// minimaxai/minimax-m2.7
    /// MiniMax M2.7 (229B MoE, ~10B active). Enterprise access. Tool use, JSON, reasoning.
    /// 196K context, 131K max output.
    /// </summary>
    public static readonly ChatModel ModelM27 = new ChatModel("grok-minimaxai/minimax-m2.7", LLmProviders.Groq, 196_608)
    {
        ApiName = "minimaxai/minimax-m2.7",
        EndpointCapabilities = ChatModelGroq.ChatResponsesBatch
    };
    
    /// <summary>
    /// <inheritdoc cref="ModelM27"/>
    /// </summary>
    public readonly ChatModel M27 = ModelM27;
    
    /// <summary>
    /// minimaxai/minimax-m2.5
    /// MiniMax M2.5 general-purpose model. Enterprise access. Superseded on GroqCloud by M2.7.
    /// </summary>
    public static readonly ChatModel ModelM25 = new ChatModel("grok-minimaxai/minimax-m2.5", LLmProviders.Groq, 196_608)
    {
        ApiName = "minimaxai/minimax-m2.5",
        EndpointCapabilities = ChatModelGroq.ChatResponsesBatch
    };
    
    /// <summary>
    /// <inheritdoc cref="ModelM25"/>
    /// </summary>
    public readonly ChatModel M25 = ModelM25;
    
    /// <summary>
    /// All known MiniMax models from Groq.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [ModelM27, ModelM25]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;

    internal ChatModelGroqMiniMax()
    {

    }
}
