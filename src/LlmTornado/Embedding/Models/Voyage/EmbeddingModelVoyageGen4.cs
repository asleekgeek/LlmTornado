using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;
using LlmTornado.Embedding.Models;

namespace LlmTornado.Embedding.Models.Voyage;

/// <summary>
/// Voyage 4 embedding models from Voyage. All embeddings in this series share one embedding space.
/// </summary>
public class EmbeddingModelVoyageGen4 : BaseVendorModelProvider
{
    /// <inheritdoc cref="BaseVendorModelProvider.Provider"/>
    public override LLmProviders Provider => LLmProviders.Voyage;
    
    /// <summary>
    /// The best general-purpose and multilingual retrieval quality.
    /// </summary>
    public static readonly EmbeddingModel ModelLarge = new EmbeddingModel("voyage-4-large", LLmProviders.Voyage, 32_000, 1_024, [ 2048, 1024, 512, 256 ]);

    /// <summary>
    /// <inheritdoc cref="ModelLarge"/>
    /// </summary>
    public readonly EmbeddingModel Large = ModelLarge;
    
    /// <summary>
    /// Optimized for general-purpose and multilingual retrieval quality.
    /// </summary>
    public static readonly EmbeddingModel ModelStandard = new EmbeddingModel("voyage-4", LLmProviders.Voyage, 32_000, 1_024, [ 2048, 1024, 512, 256 ]);

    /// <summary>
    /// <inheritdoc cref="ModelStandard"/>
    /// </summary>
    public readonly EmbeddingModel Standard = ModelStandard;
    
    /// <summary>
    /// Optimized for latency and cost. Shares the Voyage 4 embedding space.
    /// </summary>
    public static readonly EmbeddingModel ModelLite = new EmbeddingModel("voyage-4-lite", LLmProviders.Voyage, 32_000, 1_024, [ 2048, 1024, 512, 256 ]);

    /// <summary>
    /// <inheritdoc cref="ModelLite"/>
    /// </summary>
    public readonly EmbeddingModel Lite = ModelLite;
    
    /// <summary>
    /// Open-weight model for local development and prototyping. Shares the Voyage 4 embedding space.
    /// </summary>
    public static readonly EmbeddingModel ModelNano = new EmbeddingModel("voyage-4-nano", LLmProviders.Voyage, 32_000, 1_024, [ 2048, 1024, 512, 256 ]);
    
    /// <summary>
    /// <inheritdoc cref="ModelNano"/>
    /// </summary>
    public readonly EmbeddingModel Nano = ModelNano;
    
    /// <summary>
    /// Optimized for code retrieval and coding-agent use cases.
    /// </summary>
    public static readonly EmbeddingModel ModelCode = new EmbeddingModel("voyage-code-4", LLmProviders.Voyage, 32_000, 1_024, [ 2048, 1024, 512, 256 ]);

    /// <summary>
    /// <inheritdoc cref="ModelCode"/>
    /// </summary>
    public readonly EmbeddingModel Code = ModelCode;
    
    /// <summary>
    /// All known embedding models.
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
    /// All known Voyage 4 models.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelLarge,
        ModelStandard,
        ModelLite,
        ModelNano,
        ModelCode
    ]);
    
    internal EmbeddingModelVoyageGen4()
    {
        
    }
}
