using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models.Perplexity;

/// <summary>
/// Sonar class models from Perplexity. The Sonar Chat Completions surface retires September 27, 2026.
/// Prefer Agent API presets: sonar → fast, sonar-pro → low, sonar-reasoning-pro → medium, sonar-deep-research → high.
/// </summary>
public class ChatModelPerplexitySonar : IVendorModelClassProvider
{
    /// <summary>
    /// Advanced search offering with grounding, supporting complex queries and follow-ups.
    /// Maps to the Agent API <c>low</c> preset.
    /// </summary>
    public static readonly ChatModel ModelPro = new ChatModel("sonar-pro", LLmProviders.Perplexity, 200_000);

    /// <summary>
    /// <inheritdoc cref="ModelPro"/>
    /// </summary>
    public readonly ChatModel Pro = ModelPro;
    
    /// <summary>
    /// Fast grounded search model. Maps to the Agent API <c>fast</c> preset.
    /// </summary>
    public static readonly ChatModel ModelDefault = new ChatModel("sonar", LLmProviders.Perplexity, 128_000);
    
    /// <summary>
    /// <inheritdoc cref="ModelDefault"/>
    /// </summary>
    public readonly ChatModel Default = ModelDefault;
    
    /// <summary>
    /// Expert-level research model conducting exhaustive searches and generating comprehensive reports.
    /// Maps to the Agent API <c>high</c> preset.
    /// </summary>
    public static readonly ChatModel ModelDeepResearch = new ChatModel("sonar-deep-research", LLmProviders.Perplexity, 128_000);
    
    /// <summary>
    /// <inheritdoc cref="ModelDeepResearch"/>
    /// </summary>
    public readonly ChatModel DeepResearch = ModelDeepResearch;
    
    /// <summary>
    /// Premier reasoning offering with Chain of Thought (CoT). Maps to the Agent API <c>medium</c> preset.
    /// </summary>
    public static readonly ChatModel ModelReasoningPro = new ChatModel("sonar-reasoning-pro", LLmProviders.Perplexity, 128_000);
    
    /// <summary>
    /// <inheritdoc cref="ModelReasoningPro"/>
    /// </summary>
    public readonly ChatModel ReasoningPro = ModelReasoningPro;
    
    /// <summary>
    /// Deprecated as of December 15, 2025. Use <see cref="ModelReasoningPro"/> or the Agent API <c>medium</c> preset.
    /// </summary>
    public static readonly ChatModel ModelReasoning = new ChatModel("sonar-reasoning", LLmProviders.Perplexity, 128_000);
    
    /// <summary>
    /// <inheritdoc cref="ModelReasoning"/>
    /// </summary>
    public readonly ChatModel Reasoning = ModelReasoning;
    
    /// <summary>
    /// All known Sonar models from Perplexity.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [ModelPro, ModelDefault, ModelDeepResearch, ModelReasoningPro, ModelReasoning]);
    
    /// <inheritdoc />
    public List<IModel> AllModels => ModelsAll;
    
    internal ChatModelPerplexitySonar()
    {
        
    }
}
