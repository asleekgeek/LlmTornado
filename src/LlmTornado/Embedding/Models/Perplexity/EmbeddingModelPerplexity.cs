using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Embedding.Models.Perplexity;

/// <summary>
/// Known embedding models from Perplexity.
/// </summary>
public class EmbeddingModelPerplexity : BaseVendorModelProvider
{
    /// <inheritdoc cref="BaseVendorModelProvider.Provider"/>
    public override LLmProviders Provider => LLmProviders.Perplexity;
    
    /// <summary>
    /// Standard embeddings for independent texts, search queries, and single sentences.
    /// </summary>
    public readonly EmbeddingModelPerplexityStandard Standard = new EmbeddingModelPerplexityStandard();
    
    /// <summary>
    /// All known embedding models from Perplexity.
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
        ..EmbeddingModelPerplexityStandard.ModelsAll
    ]);
    
    internal EmbeddingModelPerplexity()
    {
        
    }
}
