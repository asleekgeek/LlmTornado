using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models.XAi;

/// <summary>
/// Grok 4.20 class models from xAI.
/// </summary>
public class ChatModelXAiGrok420 : IVendorModelClassProvider
{
    /// <summary>
    /// Grok 4.20 reasoning — high-performance model with agentic tool calling and a 1M context window.
    /// Batch API supported. Snapshot 2026-03-09.
    /// </summary>
    public static readonly ChatModel ModelV420Reasoning = new ChatModel("grok-4.20-0309-reasoning", LLmProviders.XAi, 1_000_000, [
        "grok-4.20",
        "grok-4.20-reasoning",
        "grok-4.20-reasoning-latest",
        "grok-4.20-0309"
    ]);

    /// <summary>
    /// <inheritdoc cref="ModelV420Reasoning"/>
    /// </summary>
    public readonly ChatModel V420Reasoning = ModelV420Reasoning;
    
    /// <summary>
    /// Grok 4.20 non-reasoning — same 1M-context family without a reasoning trace.
    /// Batch API supported. Snapshot 2026-03-09.
    /// </summary>
    public static readonly ChatModel ModelV420NonReasoning = new ChatModel("grok-4.20-0309-non-reasoning", LLmProviders.XAi, 1_000_000, [
        "grok-4.20-non-reasoning",
        "grok-4.20-non-reasoning-latest"
    ]);

    /// <summary>
    /// <inheritdoc cref="ModelV420NonReasoning"/>
    /// </summary>
    public readonly ChatModel V420NonReasoning = ModelV420NonReasoning;
    
    /// <summary>
    /// Grok 4.20 multi-agent — parallel agents for deep research tasks. 1M context window.
    /// Batch API supported. Snapshot 2026-03-09.
    /// </summary>
    public static readonly ChatModel ModelV420MultiAgent = new ChatModel("grok-4.20-multi-agent-0309", LLmProviders.XAi, 1_000_000, [
        "grok-4.20-multi-agent",
        "grok-4.20-multi-agent-latest"
    ]);

    /// <summary>
    /// <inheritdoc cref="ModelV420MultiAgent"/>
    /// </summary>
    public readonly ChatModel V420MultiAgent = ModelV420MultiAgent;
    
    /// <summary>
    /// All Grok 4.20 models.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelV420Reasoning, ModelV420NonReasoning, ModelV420MultiAgent
    ]);
    
    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;
    
    internal ChatModelXAiGrok420()
    {
        
    }
}
