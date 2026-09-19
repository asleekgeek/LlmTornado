using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Embedding.Models.Voyage;

/// <summary>
/// Known contextual embedding models from Voyage.
/// </summary>
public class EmbeddingModelVoyageContextual : BaseVendorModelProvider
{
    /// <inheritdoc cref="BaseVendorModelProvider.Provider"/>
    public override LLmProviders Provider => LLmProviders.Voyage;
    
    /// <summary>
    /// Voyage Contextual Gen 3 models.
    /// </summary>
    public readonly EmbeddingModelVoyageContextualGen3 Gen3 = new EmbeddingModelVoyageContextualGen3();

    /// <summary>
    /// Voyage Contextual Gen 4 models.
    /// </summary>
    public readonly EmbeddingModelVoyageContextualGen4 Gen4 = new EmbeddingModelVoyageContextualGen4();
    
    /// <summary>
    /// All known embedding models from Voyage.
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

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ..EmbeddingModelVoyageContextualGen3.ModelsAll,
        ..EmbeddingModelVoyageContextualGen4.ModelsAll
    ]);
    
    internal EmbeddingModelVoyageContextual()
    {
        
    }
}