using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models;

/// <summary>
/// Moonshot AI models hosted by Groq.
/// </summary>
public class ChatModelGroqMoonshotAi : IVendorModelClassProvider
{
    /// <summary>
    /// moonshotai/kimi-k2-instruct
    /// Original Kimi K2 Instruct (131K context). Deprecated Oct 10, 2025 in favor of the 0905 revision.
    /// </summary>
    public static readonly ChatModel ModelKimiK2Instruct = new ChatModel("grok-moonshotai/kimi-k2-instruct", LLmProviders.Groq, 131_072)
    {
        ApiName = "moonshotai/kimi-k2-instruct",
        EndpointCapabilities = ChatModelGroq.ChatResponsesBatch
    };
    
    /// <summary>
    /// <inheritdoc cref="ModelKimiK2Instruct"/>
    /// </summary>
    public readonly ChatModel KimiK2Instruct = ModelKimiK2Instruct;
    
    /// <summary>
    /// moonshotai/kimi-k2-instruct-0905
    /// Kimi K2 Instruct 0905 (Sep 5, 2025). 256K context, improved agentic coding, prompt caching.
    /// Deprecated Apr 15, 2026 for free/developer tiers in favor of openai/gpt-oss-120b.
    /// </summary>
    public static readonly ChatModel ModelKimiK2Instruct0905 = new ChatModel("grok-moonshotai/kimi-k2-instruct-0905", LLmProviders.Groq, 262_144)
    {
        ApiName = "moonshotai/kimi-k2-instruct-0905",
        EndpointCapabilities = ChatModelGroq.ChatResponsesBatch
    };
    
    /// <summary>
    /// <inheritdoc cref="ModelKimiK2Instruct0905"/>
    /// </summary>
    public readonly ChatModel KimiK2Instruct0905 = ModelKimiK2Instruct0905;
    
    /// <summary>
    /// All known Moonshot AI models from Groq.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [ModelKimiK2Instruct, ModelKimiK2Instruct0905]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;

    internal ChatModelGroqMoonshotAi()
    {

    }
}
