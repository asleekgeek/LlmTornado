using System;
using System.Collections.Generic;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models.Perplexity;

/// <summary>
/// Anthropic models available through the Perplexity Agent API.
/// Requests that use an <c>anthropic/*</c> model must include <c>max_output_tokens</c>.
/// </summary>
public class ChatModelPerplexityAnthropic : IVendorModelClassProvider
{
    /// <summary>
    /// Claude Fable 5 — Anthropic's most capable widely released model.
    /// </summary>
    public static readonly ChatModel ModelFable5 = ChatModelPerplexity.CreateAgentModel("anthropic/claude-fable-5", 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelFable5"/>
    /// </summary>
    public readonly ChatModel Fable5 = ModelFable5;
    
    /// <summary>
    /// Claude Opus 5 — Anthropic's flagship Opus model.
    /// </summary>
    public static readonly ChatModel ModelOpus5 = ChatModelPerplexity.CreateAgentModel("anthropic/claude-opus-5", 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelOpus5"/>
    /// </summary>
    public readonly ChatModel Opus5 = ModelOpus5;
    
    /// <summary>
    /// Claude Opus 4.8.
    /// </summary>
    public static readonly ChatModel ModelOpus48 = ChatModelPerplexity.CreateAgentModel("anthropic/claude-opus-4-8", 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelOpus48"/>
    /// </summary>
    public readonly ChatModel Opus48 = ModelOpus48;
    
    /// <summary>
    /// Claude Opus 4.7.
    /// </summary>
    public static readonly ChatModel ModelOpus47 = ChatModelPerplexity.CreateAgentModel("anthropic/claude-opus-4-7", 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelOpus47"/>
    /// </summary>
    public readonly ChatModel Opus47 = ModelOpus47;
    
    /// <summary>
    /// Claude Opus 4.6.
    /// </summary>
    public static readonly ChatModel ModelOpus46 = ChatModelPerplexity.CreateAgentModel("anthropic/claude-opus-4-6", 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelOpus46"/>
    /// </summary>
    public readonly ChatModel Opus46 = ModelOpus46;
    
    /// <summary>
    /// Claude Opus 4.5.
    /// </summary>
    public static readonly ChatModel ModelOpus45 = ChatModelPerplexity.CreateAgentModel("anthropic/claude-opus-4-5", 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelOpus45"/>
    /// </summary>
    public readonly ChatModel Opus45 = ModelOpus45;
    
    /// <summary>
    /// Claude Sonnet 5 — Anthropic's latest Sonnet model.
    /// </summary>
    public static readonly ChatModel ModelSonnet5 = ChatModelPerplexity.CreateAgentModel("anthropic/claude-sonnet-5", 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelSonnet5"/>
    /// </summary>
    public readonly ChatModel Sonnet5 = ModelSonnet5;
    
    /// <summary>
    /// Claude Sonnet 4.6.
    /// </summary>
    public static readonly ChatModel ModelSonnet46 = ChatModelPerplexity.CreateAgentModel("anthropic/claude-sonnet-4-6", 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelSonnet46"/>
    /// </summary>
    public readonly ChatModel Sonnet46 = ModelSonnet46;
    
    /// <summary>
    /// Claude Sonnet 4.5.
    /// </summary>
    public static readonly ChatModel ModelSonnet45 = ChatModelPerplexity.CreateAgentModel("anthropic/claude-sonnet-4-5", 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelSonnet45"/>
    /// </summary>
    public readonly ChatModel Sonnet45 = ModelSonnet45;
    
    /// <summary>
    /// Claude Haiku 4.5 — fastest, cheapest Claude on the Agent API.
    /// </summary>
    public static readonly ChatModel ModelHaiku45 = ChatModelPerplexity.CreateAgentModel("anthropic/claude-haiku-4-5", 200_000);

    /// <summary>
    /// <inheritdoc cref="ModelHaiku45"/>
    /// </summary>
    public readonly ChatModel Haiku45 = ModelHaiku45;
    
    /// <summary>
    /// All known Anthropic models on the Perplexity Agent API.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelFable5, ModelOpus5, ModelOpus48, ModelOpus47, ModelOpus46, ModelOpus45,
        ModelSonnet5, ModelSonnet46, ModelSonnet45, ModelHaiku45
    ]);
    
    /// <inheritdoc />
    public List<IModel> AllModels => ModelsAll;
    
    internal ChatModelPerplexityAnthropic()
    {
        
    }
}
