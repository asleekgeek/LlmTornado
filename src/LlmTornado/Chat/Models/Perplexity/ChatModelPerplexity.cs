using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models.Perplexity;

/// <summary>
/// Known chat models from Perplexity, including Sonar, Agent API presets, and third-party Agent API models.
/// </summary>
public class ChatModelPerplexity : BaseVendorModelProvider
{
    /// <inheritdoc cref="BaseVendorModelProvider.Provider"/>
    public override LLmProviders Provider => LLmProviders.Perplexity;
    
    /// <summary>
    /// Agent API presets (fast, low, medium, high, xhigh, wide-research).
    /// </summary>
    public readonly ChatModelPerplexityPresets Presets = new ChatModelPerplexityPresets();
    
    /// <summary>
    /// Sonar models (legacy Chat Completions surface, retiring September 27, 2026).
    /// </summary>
    public readonly ChatModelPerplexitySonar Sonar = new ChatModelPerplexitySonar();
    
    /// <summary>
    /// OpenAI models available through the Agent API.
    /// </summary>
    public readonly ChatModelPerplexityOpenAi OpenAi = new ChatModelPerplexityOpenAi();
    
    /// <summary>
    /// Anthropic models available through the Agent API.
    /// </summary>
    public readonly ChatModelPerplexityAnthropic Anthropic = new ChatModelPerplexityAnthropic();
    
    /// <summary>
    /// Google models available through the Agent API.
    /// </summary>
    public readonly ChatModelPerplexityGoogle Google = new ChatModelPerplexityGoogle();
    
    /// <summary>
    /// xAI models available through the Agent API.
    /// </summary>
    public readonly ChatModelPerplexityXAi XAi = new ChatModelPerplexityXAi();
    
    /// <summary>
    /// Perplexity-hosted open-weight and first-party Agent API models.
    /// </summary>
    public readonly ChatModelPerplexityHosted Hosted = new ChatModelPerplexityHosted();

    /// <summary>
    /// All known chat models from Perplexity.
    /// </summary>
    public override List<IModel> AllModels => ModelsAll;

    /// <summary>
    /// Checks whether the model is owned by the provider.
    /// </summary>
    public override bool OwnsModel(string model)
    {
        return AllModelsMap.Contains(model);
    }

    /// <summary>
    /// Map of models owned by the provider.
    /// </summary>
    public static HashSet<string> AllModelsMap => LazyAllModelsMap.Value;

    private static readonly Lazy<HashSet<string>> LazyAllModelsMap = new Lazy<HashSet<string>>(() =>
    {
        HashSet<string> map = [];

        ModelsAll.ForEach(x => { map.Add(x.Name); });

        return map;
    });

    /// <summary>
    /// <inheritdoc cref="AllModels"/>
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;
    
    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ..ChatModelPerplexityPresets.ModelsAll,
        ..ChatModelPerplexitySonar.ModelsAll,
        ..ChatModelPerplexityOpenAi.ModelsAll,
        ..ChatModelPerplexityAnthropic.ModelsAll,
        ..ChatModelPerplexityGoogle.ModelsAll,
        ..ChatModelPerplexityXAi.ModelsAll,
        ..ChatModelPerplexityHosted.ModelsAll
    ]);

    /// <summary>
    /// Agent API models that must be sent to <c>/v1/responses</c> (or the <c>/v1/agent</c> alias).
    /// </summary>
    public static HashSet<IModel> AgentModelsAll => LazyAgentModelsAll.Value;

    private static readonly Lazy<HashSet<IModel>> LazyAgentModelsAll = new Lazy<HashSet<IModel>>(() => [
        ..ChatModelPerplexityPresets.ModelsAll,
        ..ChatModelPerplexityOpenAi.ModelsAll,
        ..ChatModelPerplexityAnthropic.ModelsAll,
        ..ChatModelPerplexityGoogle.ModelsAll,
        ..ChatModelPerplexityXAi.ModelsAll,
        ..ChatModelPerplexityHosted.ModelsAll
    ]);

    /// <summary>
    /// Names of Agent API models, including presets.
    /// </summary>
    public static HashSet<string> AgentModelNames => LazyAgentModelNames.Value;

    private static readonly Lazy<HashSet<string>> LazyAgentModelNames = new Lazy<HashSet<string>>(() =>
    {
        HashSet<string> map = [];
        foreach (IModel model in AgentModelsAll)
        {
            map.Add(model.Name);
        }

        return map;
    });

    /// <summary>
    /// Agent API presets. These serialize as <c>preset</c> rather than <c>model</c>.
    /// </summary>
    public static HashSet<IModel> PresetModelsAll => LazyPresetModelsAll.Value;

    private static readonly Lazy<HashSet<IModel>> LazyPresetModelsAll = new Lazy<HashSet<IModel>>(() => [..ChatModelPerplexityPresets.ModelsAll]);

    /// <summary>
    /// Names of Agent API presets.
    /// </summary>
    public static HashSet<string> PresetNames => LazyPresetNames.Value;

    private static readonly Lazy<HashSet<string>> LazyPresetNames = new Lazy<HashSet<string>>(() =>
    {
        HashSet<string> map = [];
        foreach (IModel model in PresetModelsAll)
        {
            map.Add(model.Name);
        }

        return map;
    });

    /// <summary>
    /// Anthropic Agent API models. <c>max_output_tokens</c> is required.
    /// </summary>
    public static HashSet<IModel> AnthropicModelsAll => LazyAnthropicModelsAll.Value;

    private static readonly Lazy<HashSet<IModel>> LazyAnthropicModelsAll = new Lazy<HashSet<IModel>>(() => [..ChatModelPerplexityAnthropic.ModelsAll]);

    /// <summary>
    /// Names of Anthropic Agent API models.
    /// </summary>
    public static HashSet<string> AnthropicModelNames => LazyAnthropicModelNames.Value;

    private static readonly Lazy<HashSet<string>> LazyAnthropicModelNames = new Lazy<HashSet<string>>(() =>
    {
        HashSet<string> map = [];
        foreach (IModel model in AnthropicModelsAll)
        {
            map.Add(model.Name);
        }

        return map;
    });

    internal static readonly HashSet<ChatModelEndpointCapabilities> AgentEndpointCapabilities =
    [
        ChatModelEndpointCapabilities.Responses
    ];

    internal static ChatModel CreateAgentModel(string name, int contextTokens, List<string>? aliases = null)
    {
        ChatModel model = aliases is null
            ? new ChatModel(name, LLmProviders.Perplexity, contextTokens)
            : new ChatModel(name, LLmProviders.Perplexity, contextTokens, aliases);

        model.EndpointCapabilities = AgentEndpointCapabilities;
        return model;
    }

    internal ChatModelPerplexity()
    {
        
    }
}
