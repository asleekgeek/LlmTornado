using System.Collections.Generic;
using System.Linq;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Rerank.Models.Voyage;

/// <summary>
/// Voyage Rerank Gen 2 models.
/// </summary>
public class RerankModelVoyageGen2 : BaseVendorModelProvider
{
    /// <inheritdoc cref="BaseVendorModelProvider.Provider"/>
    public override LLmProviders Provider => LLmProviders.Voyage;
    
    /// <summary>
    /// Generalist second-generation reranker optimized for quality with multilingual support.
    /// </summary>
    public static readonly RerankModel ModelRerank2 = new RerankModel("rerank-2", LLmProviders.Voyage);

    /// <summary>
    /// <inheritdoc cref="ModelRerank2"/>
    /// </summary>
    public readonly RerankModel Rerank2 = ModelRerank2;
    
    /// <summary>
    /// <inheritdoc cref="ModelRerank2"/>
    /// </summary>
    public readonly RerankModel Default = ModelRerank2;
    
    /// <summary>
    /// Generalist second-generation reranker optimized for latency and quality with multilingual support.
    /// </summary>
    public static readonly RerankModel ModelRerank2Lite = new RerankModel("rerank-2-lite", LLmProviders.Voyage);
    
    /// <summary>
    /// <inheritdoc cref="ModelRerank2Lite"/>
    /// </summary>
    public readonly RerankModel Rerank2Lite = ModelRerank2Lite;
    
    /// <summary>
    /// All known rerank models.
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
    public static readonly HashSet<string> AllModelsMap;
    
    /// <summary>
    /// All known Voyage Rerank Gen 2 models.
    /// </summary>
    public static readonly List<IModel> ModelsAll =
    [
        ModelRerank2,
        ModelRerank2Lite
    ];

    static RerankModelVoyageGen2()
    {
        AllModelsMap = new HashSet<string>(ModelsAll.Select(x => x.Name));
    }
    
    internal RerankModelVoyageGen2()
    {
        
    }
}
