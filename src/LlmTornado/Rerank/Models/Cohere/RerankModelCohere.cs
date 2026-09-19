using System.Collections.Generic;
using System.Linq;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Rerank.Models.Cohere;

/// <summary>
/// Known rerank models from Cohere.
/// </summary>
public class RerankModelCohere : BaseVendorModelProvider
{
    /// <inheritdoc cref="BaseVendorModelProvider.Provider"/>
    public override LLmProviders Provider => LLmProviders.Cohere;

    /// <summary>
    /// Rerank 4 models.
    /// </summary>
    public readonly RerankModelCohereGen4 Gen4 = new RerankModelCohereGen4();

    /// <summary>
    /// Rerank 3 models.
    /// </summary>
    public readonly RerankModelCohereGen3 Gen3 = new RerankModelCohereGen3();

    /// <summary>
    /// All known rerank models from Cohere.
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
    /// <inheritdoc cref="AllModels"/>
    /// </summary>
    public static readonly List<IModel> ModelsAll =
    [
        ..RerankModelCohereGen4.ModelsAll,
        ..RerankModelCohereGen3.ModelsAll
    ];

    static RerankModelCohere()
    {
        AllModelsMap = new HashSet<string>(ModelsAll.Select(x => x.Name));
    }

    internal RerankModelCohere()
    {
    }
}
