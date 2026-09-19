using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models;

/// <summary>
/// Known chat models provided by Groq.
/// </summary>
public class ChatModelGroq : BaseVendorModelProvider
{
    /// <inheritdoc cref="BaseVendorModelProvider.Provider"/>
    public override LLmProviders Provider => LLmProviders.Groq;
    
    /// <summary>
    /// Models by Meta.
    /// </summary>
    public readonly ChatModelGroqMeta Meta = new ChatModelGroqMeta();
    
    /// <summary>
    /// Systems by Groq (Compound).
    /// </summary>
    public readonly ChatModelGroqGroq Groq = new ChatModelGroqGroq();
    
    /// <summary>
    /// Models by Mistral.
    /// </summary>
    public readonly ChatModelGroqMistral Mistral = new ChatModelGroqMistral();
    
    /// <summary>
    /// Models by Google.
    /// </summary>
    public readonly ChatModelGroqGoogle Google = new ChatModelGroqGoogle();
    
    /// <summary>
    /// Models by Alibaba (Qwen).
    /// </summary>
    public readonly ChatModelGroqAlibaba Alibaba = new ChatModelGroqAlibaba();
    
    /// <summary>
    /// Models by Moonshot AI.
    /// </summary>
    public readonly ChatModelGroqMoonshotAi MoonshotAi = new ChatModelGroqMoonshotAi();
    
    /// <summary>
    /// Models by OpenAI.
    /// </summary>
    public readonly ChatModelGroqOpenAi OpenAi = new ChatModelGroqOpenAi();
    
    /// <summary>
    /// Models by MiniMax.
    /// </summary>
    public readonly ChatModelGroqMiniMax MiniMax = new ChatModelGroqMiniMax();

    /// <summary>
    /// Chat, Responses, and Batch endpoints.
    /// </summary>
    internal static readonly HashSet<ChatModelEndpointCapabilities> ChatResponsesBatch =
    [
        ChatModelEndpointCapabilities.Chat,
        ChatModelEndpointCapabilities.Responses,
        ChatModelEndpointCapabilities.Batch
    ];

    /// <summary>
    /// Chat and Responses endpoints.
    /// </summary>
    internal static readonly HashSet<ChatModelEndpointCapabilities> ChatResponses =
    [
        ChatModelEndpointCapabilities.Chat,
        ChatModelEndpointCapabilities.Responses
    ];

    /// <summary>
    /// Chat completions only.
    /// </summary>
    internal static readonly HashSet<ChatModelEndpointCapabilities> ChatOnly =
    [
        ChatModelEndpointCapabilities.Chat
    ];

    /// <summary>
    /// All known chat models hosted by Groq.
    /// </summary>
    public override List<IModel> AllModels => ModelsAll;

    /// <summary>
    /// Checks whether the model is owned by the provider.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public override bool OwnsModel(string model)
    {
        return AllModelsMap.Contains(model);
    }

    /// <summary>
    /// Map of models owned by the provider (internal names and API names).
    /// </summary>
    public static HashSet<string> AllModelsMap => LazyAllModelsMap.Value;

    private static readonly Lazy<HashSet<string>> LazyAllModelsMap = new Lazy<HashSet<string>>(() =>
    {
        HashSet<string> map = [];

        foreach (IModel model in ModelsAll)
        {
            map.Add(model.Name);

            if (!string.IsNullOrWhiteSpace(model.ApiName))
            {
                map.Add(model.ApiName);
            }
        }

        return map;
    });
    
    /// <summary>
    /// <inheritdoc cref="AllModels"/>
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ..ChatModelGroqMeta.ModelsAll,
        ..ChatModelGroqGoogle.ModelsAll,
        ..ChatModelGroqGroq.ModelsAll,
        ..ChatModelGroqMistral.ModelsAll,
        ..ChatModelGroqAlibaba.ModelsAll,
        ..ChatModelGroqMoonshotAi.ModelsAll,
        ..ChatModelGroqOpenAi.ModelsAll,
        ..ChatModelGroqMiniMax.ModelsAll
    ]);

    /// <summary>
    /// Models that support reasoning_effort / reasoning_format / include_reasoning.
    /// </summary>
    public static List<IModel> ReasoningModelsAll => LazyReasoningModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyReasoningModelsAll = new Lazy<List<IModel>>(() => [
        ChatModelGroqOpenAi.ModelGptOss120B,
        ChatModelGroqOpenAi.ModelGptOss20B,
        ChatModelGroqOpenAi.ModelGptOssSafeguard20B,
        ChatModelGroqAlibaba.ModelQwen332B,
        ChatModelGroqAlibaba.ModelQwen3627B,
        ChatModelGroqAlibaba.ModelQwen3827B,
        ChatModelGroqMiniMax.ModelM27,
        ChatModelGroqMiniMax.ModelM25
    ]);

    /// <summary>
    /// HashSet version of <see cref="ReasoningModelsAll"/>.
    /// </summary>
    internal static HashSet<IModel> ReasoningModelsAllSet => LazyReasoningModelsAllSet.Value;

    private static readonly Lazy<HashSet<IModel>> LazyReasoningModelsAllSet = new Lazy<HashSet<IModel>>(() => [..ReasoningModelsAll]);

    /// <summary>
    /// Models that accept image inputs.
    /// </summary>
    public static List<IModel> VisionModelsAll => LazyVisionModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyVisionModelsAll = new Lazy<List<IModel>>(() => [
        ChatModelGroqMeta.ModelLlama4Scout,
        ChatModelGroqMeta.ModelLlama4Maverick,
        ChatModelGroqAlibaba.ModelQwen3627B,
        ChatModelGroqAlibaba.ModelQwen3827B,
        ChatModelGroqAlibaba.ModelQwen3Vl32BInstruct,
        ChatModelGroqMeta.ModelLlamaGuard412B
    ]);

    /// <summary>
    /// Compound agentic systems with built-in server-side tools.
    /// </summary>
    public static List<IModel> CompoundSystemsAll => LazyCompoundSystemsAll.Value;

    private static readonly Lazy<List<IModel>> LazyCompoundSystemsAll = new Lazy<List<IModel>>(() => [
        ChatModelGroqGroq.ModelCompound,
        ChatModelGroqGroq.ModelCompoundMini,
        ChatModelGroqGroq.ModelCompoundBeta,
        ChatModelGroqGroq.ModelCompoundBetaMini
    ]);

    /// <summary>
    /// HashSet version of <see cref="CompoundSystemsAll"/>.
    /// </summary>
    internal static HashSet<IModel> CompoundSystemsAllSet => LazyCompoundSystemsAllSet.Value;

    private static readonly Lazy<HashSet<IModel>> LazyCompoundSystemsAllSet = new Lazy<HashSet<IModel>>(() => [..CompoundSystemsAll]);
    
    internal ChatModelGroq()
    {
      
    }
}
