using System.Collections.Generic;
using System.Linq;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Rerank.Models.Voyage;

/// <summary>
/// Voyage Rerank Gen 3 models.
/// </summary>
public class RerankModelVoyageGen3 : BaseVendorModelProvider
{
    /// <inheritdoc cref="BaseVendorModelProvider.Provider"/>
    public override LLmProviders Provider => LLmProviders.Voyage;
    
    /// <summary>
    /// Highest-accuracy reranker. Recommended for most applications.
    /// </summary>
    public static readonly RerankModel ModelRerank3 = new RerankModel("rerank-3", LLmProviders.Voyage);

    /// <summary>
    /// <inheritdoc cref="ModelRerank3"/>
    /// </summary>
    public readonly RerankModel Rerank3 = ModelRerank3;
    
    /// <summary>
    /// Fast and cost-effective reranker optimized for latency-sensitive applications.
    /// </summary>
    public static readonly RerankModel ModelRerank3Lite = new RerankModel("rerank-3-lite", LLmProviders.Voyage);
    
    /// <summary>
    /// <inheritdoc cref="ModelRerank3Lite"/>
    /// </summary>
    public readonly RerankModel Rerank3Lite = ModelRerank3Lite;
    
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
    /// All known Voyage Rerank Gen 3 models.
    /// </summary>
    public static readonly List<IModel> ModelsAll =
    [
        ModelRerank3,
        ModelRerank3Lite
    ];

    static RerankModelVoyageGen3()
    {
        AllModelsMap = new HashSet<string>(ModelsAll.Select(x => x.Name));
    }
    
    internal RerankModelVoyageGen3()
    {
        
    }
}
