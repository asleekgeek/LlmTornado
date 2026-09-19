using System;
using System.Collections.Generic;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models.Perplexity;

/// <summary>
/// xAI models available through the Perplexity Agent API.
/// </summary>
public class ChatModelPerplexityXAi : IVendorModelClassProvider
{
    /// <summary>
    /// Grok 4.6 — xAI's latest flagship reasoning and agentic model.
    /// </summary>
    public static readonly ChatModel ModelGrok46 = ChatModelPerplexity.CreateAgentModel("xai/grok-4.6", 500_000);

    /// <summary>
    /// <inheritdoc cref="ModelGrok46"/>
    /// </summary>
    public readonly ChatModel Grok46 = ModelGrok46;
    
    /// <summary>
    /// Grok 4.5 — flagship coding and agentic model.
    /// </summary>
    public static readonly ChatModel ModelGrok45 = ChatModelPerplexity.CreateAgentModel("xai/grok-4.5", 500_000);

    /// <summary>
    /// <inheritdoc cref="ModelGrok45"/>
    /// </summary>
    public readonly ChatModel Grok45 = ModelGrok45;
    
    /// <summary>
    /// Grok 4.3.
    /// </summary>
    public static readonly ChatModel ModelGrok43 = ChatModelPerplexity.CreateAgentModel("xai/grok-4.3", 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelGrok43"/>
    /// </summary>
    public readonly ChatModel Grok43 = ModelGrok43;
    
    /// <summary>
    /// Grok 4.20 Reasoning.
    /// </summary>
    public static readonly ChatModel ModelGrok420Reasoning = ChatModelPerplexity.CreateAgentModel("xai/grok-4.20-reasoning", 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelGrok420Reasoning"/>
    /// </summary>
    public readonly ChatModel Grok420Reasoning = ModelGrok420Reasoning;
    
    /// <summary>
    /// Grok 4.20 Non-Reasoning.
    /// </summary>
    public static readonly ChatModel ModelGrok420NonReasoning = ChatModelPerplexity.CreateAgentModel("xai/grok-4.20-non-reasoning", 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelGrok420NonReasoning"/>
    /// </summary>
    public readonly ChatModel Grok420NonReasoning = ModelGrok420NonReasoning;
    
    /// <summary>
    /// Grok 4.20 Multi-Agent.
    /// </summary>
    public static readonly ChatModel ModelGrok420MultiAgent = ChatModelPerplexity.CreateAgentModel("xai/grok-4.20-multi-agent", 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelGrok420MultiAgent"/>
    /// </summary>
    public readonly ChatModel Grok420MultiAgent = ModelGrok420MultiAgent;
    
    /// <summary>
    /// All known xAI models on the Perplexity Agent API.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelGrok46, ModelGrok45, ModelGrok43, ModelGrok420Reasoning, ModelGrok420NonReasoning, ModelGrok420MultiAgent
    ]);
    
    /// <inheritdoc />
    public List<IModel> AllModels => ModelsAll;
    
    internal ChatModelPerplexityXAi()
    {
        
    }
}
