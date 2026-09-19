using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Embedding.Models.Perplexity;

/// <summary>
/// Contextualized Perplexity embedding models for document chunks that share context.
/// </summary>
public class EmbeddingModelPerplexityContextual : BaseVendorModelProvider
{
    /// <inheritdoc cref="BaseVendorModelProvider.Provider"/>
    public override LLmProviders Provider => LLmProviders.Perplexity;
    
    /// <summary>
    /// Compact contextualized 0.6B model. 1024 dimensions, 32K context per document.
    /// </summary>
    public static readonly ContextualEmbeddingModel ModelV1Small = new ContextualEmbeddingModel("pplx-embed-context-v1-0.6b", LLmProviders.Perplexity, 32_000, 1024, [256, 512, 1024]);

    /// <summary>
    /// <inheritdoc cref="ModelV1Small"/>
    /// </summary>
    public readonly ContextualEmbeddingModel V1Small = ModelV1Small;
    
    /// <summary>
    /// Higher-capacity contextualized 4B model. 2560 dimensions, 32K context per document.
    /// </summary>
    public static readonly ContextualEmbeddingModel ModelV1Large = new ContextualEmbeddingModel("pplx-embed-context-v1-4b", LLmProviders.Perplexity, 32_000, 2560, [256, 512, 1024, 2048, 2560]);

    /// <summary>
    /// <inheritdoc cref="ModelV1Large"/>
    /// </summary>
    public readonly ContextualEmbeddingModel V1Large = ModelV1Large;
    
    /// <inheritdoc />
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
    /// All known contextualized Perplexity embedding models.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelV1Small, ModelV1Large
    ]);
    
    internal EmbeddingModelPerplexityContextual()
    {
        
    }
}
