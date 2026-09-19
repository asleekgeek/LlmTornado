using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Embedding.Models.Voyage;

/// <summary>
/// Voyage Contextual Gen 4 embedding models from Voyage.
/// </summary>
public class EmbeddingModelVoyageContextualGen4 : BaseVendorModelProvider
{
    /// <inheritdoc cref="BaseVendorModelProvider.Provider"/>
    public override LLmProviders Provider => LLmProviders.Voyage;
    
    /// <summary>
    /// Contextualized chunk embeddings with built-in auto-chunking, overlapping chunks, and transparent handling of documents longer than 32K tokens.
    /// The per-chunk context window is 32K tokens. Total tokens across all inputs may reach 120K when auto-chunking is enabled.
    /// </summary>
    public static readonly ContextualEmbeddingModel ModelContext4 = new ContextualEmbeddingModel("voyage-context-4", LLmProviders.Voyage, 120_000, 1024, [ 256, 512, 1024, 2048 ]);

    /// <summary>
    /// <inheritdoc cref="ModelContext4"/>
    /// </summary>
    public readonly ContextualEmbeddingModel Context4 = ModelContext4;
    
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
    /// All known Voyage Contextual Gen 4 models.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelContext4
    ]);
    
    internal EmbeddingModelVoyageContextualGen4()
    {
       
    }
}
