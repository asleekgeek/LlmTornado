using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;
using LlmTornado.Embedding.Models;

namespace LlmTornado.Embedding.Models.Voyage;

/// <summary>
/// Voyage 2 embedding models from Voyage.
/// </summary>
public class EmbeddingModelVoyageGen2 : BaseVendorModelProvider
{
    /// <inheritdoc cref="BaseVendorModelProvider.Provider"/>
    public override LLmProviders Provider => LLmProviders.Voyage;
    
    /// <summary>
    /// Voyage AI's most powerful generalist embedding model.
    /// </summary>
    public static readonly EmbeddingModel ModelLarge = new EmbeddingModel("voyage-large-2", LLmProviders.Voyage, 16_000, 1_536);

    /// <summary>
    /// <inheritdoc cref="ModelLarge"/>
    /// </summary>
    public readonly EmbeddingModel Large = ModelLarge;
    
    /// <summary>
    /// Optimized for code retrieval (17% better than alternatives), and also SoTA on general-purpose corpora.
    /// </summary>
    public static readonly EmbeddingModel ModelCode = new EmbeddingModel("voyage-code-2", LLmProviders.Voyage, 16_000, 1_536);

    /// <summary>
    /// <inheritdoc cref="ModelCode"/>
    /// </summary>
    public readonly EmbeddingModel Code = ModelCode;
    
    /// <summary>
    /// Base generalist embedding model optimized for both latency and quality.
    /// </summary>
    public static readonly EmbeddingModel ModelDefault = new EmbeddingModel("voyage-2", LLmProviders.Voyage, 4_000, 1_024);

    /// <summary>
    /// <inheritdoc cref="ModelDefault"/>
    /// </summary>
    public readonly EmbeddingModel Default = ModelDefault;
    
    /// <summary>
    /// Instruction-tuned for classification, clustering, and sentence textual similarity tasks, which are the only recommended use cases for this model.
    /// </summary>
    public static readonly EmbeddingModel ModelLiteInstruct = new EmbeddingModel("voyage-lite-02-instruct", LLmProviders.Voyage, 4_000, 1_024);

    /// <summary>
    /// <inheritdoc cref="ModelLiteInstruct"/>
    /// </summary>
    public readonly EmbeddingModel LiteInstruct = ModelLiteInstruct;
    
    /// <summary>
    /// Instruction-tuned general-purpose embedding model optimized for clustering, classification, and retrieval.
    /// </summary>
    public static readonly EmbeddingModel ModelLargeInstruct = new EmbeddingModel("voyage-large-2-instruct", LLmProviders.Voyage, 16_000, 1_024);

    /// <summary>
    /// <inheritdoc cref="ModelLargeInstruct"/>
    /// </summary>
    public readonly EmbeddingModel LargeInstruct = ModelLargeInstruct;
    
    /// <summary>
    /// Optimized for finance retrieval and RAG.
    /// </summary>
    public static readonly EmbeddingModel ModelFinance = new EmbeddingModel("voyage-finance-2", LLmProviders.Voyage, 32_000, 1_024);

    /// <summary>
    /// <inheritdoc cref="ModelFinance"/>
    /// </summary>
    public readonly EmbeddingModel Finance = ModelFinance;
    
    /// <summary>
    /// Optimized for legal retrieval and RAG.
    /// </summary>
    public static readonly EmbeddingModel ModelLaw = new EmbeddingModel("voyage-law-2", LLmProviders.Voyage, 16_000, 1_024);

    /// <summary>
    /// <inheritdoc cref="ModelLaw"/>
    /// </summary>
    public readonly EmbeddingModel Law = ModelLaw;
    
    /// <summary>
    /// Optimized for multilingual retrieval and RAG.
    /// </summary>
    public static readonly EmbeddingModel ModelMultilingual = new EmbeddingModel("voyage-multilingual-2", LLmProviders.Voyage, 32_000, 1_024);

    /// <summary>
    /// <inheritdoc cref="ModelMultilingual"/>
    /// </summary>
    public readonly EmbeddingModel Multilingual = ModelMultilingual;
    
    /// <summary>
    /// All known embedding models from Voyage 2.
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
    /// All known Voyage 2 models.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelLarge,
        ModelCode,
        ModelDefault,
        ModelLiteInstruct,
        ModelLargeInstruct,
        ModelFinance,
        ModelLaw,
        ModelMultilingual
    ]);
    
    internal EmbeddingModelVoyageGen2()
    {
        
    }
}