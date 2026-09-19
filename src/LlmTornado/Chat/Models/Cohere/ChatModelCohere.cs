using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models;

/// <summary>
/// Known chat models from Cohere.
/// </summary>
public class ChatModelCohere: BaseVendorModelProvider
{
    /// <inheritdoc cref="BaseVendorModelProvider.Provider"/>
    public override LLmProviders Provider => LLmProviders.Cohere;
    
    /// <summary>
    /// Command models.
    /// </summary>
    public readonly ChatModelCohereCommand Command = new ChatModelCohereCommand();
    
    /// <summary>
    /// Aya models.
    /// </summary>
    public readonly ChatModelCohereAya Aya = new ChatModelCohereAya();
    
    /// <summary>
    /// North purpose-built models.
    /// </summary>
    public readonly ChatModelCohereNorth North = new ChatModelCohereNorth();

    /// <summary>
    /// All known chat models from Cohere.
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

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [..ChatModelCohereCommand.ModelsAll, ..ChatModelCohereAya.ModelsAll, ..ChatModelCohereNorth.ModelsAll]);
    
    /// <summary>
    /// Models that support Cohere's hybrid thinking / reasoning parameter.
    /// </summary>
    public static HashSet<IModel> ReasoningModels => LazyReasoningModels.Value;

    private static readonly Lazy<HashSet<IModel>> LazyReasoningModels = new Lazy<HashSet<IModel>>(() =>
    [
        ChatModelCohereCommand.ModelAPlus2605,
        ChatModelCohereCommand.ModelAReasoning2508
    ]);
    
    internal ChatModelCohere()
    {
       
    }
}