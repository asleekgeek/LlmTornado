using System;
using System.Collections.Generic;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models.Perplexity;

/// <summary>
/// Agent API presets from Perplexity. Each preset is a pre-configured model, system prompt, tool set, and reasoning budget.
/// Sonar mappings: sonar → fast, sonar-pro → low, sonar-reasoning-pro → medium, sonar-deep-research → high.
/// </summary>
public class ChatModelPerplexityPresets : IVendorModelClassProvider
{
    /// <summary>
    /// Fast grounded answers. Uses GPT-5.6 Luna with minimal reasoning and priority processing.
    /// Replacement for <c>sonar</c>.
    /// </summary>
    public static readonly ChatModel ModelFast = ChatModelPerplexity.CreateAgentModel("fast", 1_050_000);

    /// <summary>
    /// <inheritdoc cref="ModelFast"/>
    /// </summary>
    public readonly ChatModel Fast = ModelFast;
    
    /// <summary>
    /// Lightweight research. Uses GPT-5.6 Luna with minimal reasoning and a 32,768-token output cap.
    /// Replacement for <c>sonar-pro</c>.
    /// </summary>
    public static readonly ChatModel ModelLow = ChatModelPerplexity.CreateAgentModel("low", 1_050_000);

    /// <summary>
    /// <inheritdoc cref="ModelLow"/>
    /// </summary>
    public readonly ChatModel Low = ModelLow;
    
    /// <summary>
    /// Multi-step research with tool use. Replacement for <c>sonar-reasoning-pro</c>.
    /// </summary>
    public static readonly ChatModel ModelMedium = ChatModelPerplexity.CreateAgentModel("medium", 1_050_000);

    /// <summary>
    /// <inheritdoc cref="ModelMedium"/>
    /// </summary>
    public readonly ChatModel Medium = ModelMedium;
    
    /// <summary>
    /// Exhaustive research. Replacement for <c>sonar-deep-research</c>.
    /// </summary>
    public static readonly ChatModel ModelHigh = ChatModelPerplexity.CreateAgentModel("high", 1_050_000);

    /// <summary>
    /// <inheritdoc cref="ModelHigh"/>
    /// </summary>
    public readonly ChatModel High = ModelHigh;
    
    /// <summary>
    /// Open-ended agentic work beyond Deep Research.
    /// </summary>
    public static readonly ChatModel ModelXHigh = ChatModelPerplexity.CreateAgentModel("xhigh", 1_050_000);

    /// <summary>
    /// <inheritdoc cref="ModelXHigh"/>
    /// </summary>
    public readonly ChatModel XHigh = ModelXHigh;
    
    /// <summary>
    /// Wide-and-deep research for large, evidence-backed collections. Typically run in the background.
    /// </summary>
    public static readonly ChatModel ModelWideResearch = ChatModelPerplexity.CreateAgentModel("wide-research", 1_050_000);

    /// <summary>
    /// <inheritdoc cref="ModelWideResearch"/>
    /// </summary>
    public readonly ChatModel WideResearch = ModelWideResearch;
    
    /// <summary>
    /// All known Agent API presets from Perplexity.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelFast, ModelLow, ModelMedium, ModelHigh, ModelXHigh, ModelWideResearch
    ]);
    
    /// <inheritdoc />
    public List<IModel> AllModels => ModelsAll;
    
    internal ChatModelPerplexityPresets()
    {
        
    }
}
