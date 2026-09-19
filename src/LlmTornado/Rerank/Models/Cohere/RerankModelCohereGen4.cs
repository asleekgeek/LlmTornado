using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Rerank.Models.Cohere;

/// <summary>
/// Rerank 4 models from Cohere.
/// </summary>
public class RerankModelCohereGen4 : IVendorModelClassProvider
{
    /// <summary>
    /// A multilingual reranker for English and non-English documents and semi-structured data (JSON). Best for state-of-the-art quality. 32K context.
    /// </summary>
    public static readonly RerankModel ModelPro = new RerankModel("rerank-v4.0-pro", LLmProviders.Cohere);

    /// <summary>
    /// <inheritdoc cref="ModelPro"/>
    /// </summary>
    public readonly RerankModel Pro = ModelPro;

    /// <summary>
    /// A lighter multilingual reranker for low-latency and high-throughput use cases. 32K context.
    /// </summary>
    public static readonly RerankModel ModelFast = new RerankModel("rerank-v4.0-fast", LLmProviders.Cohere);

    /// <summary>
    /// <inheritdoc cref="ModelFast"/>
    /// </summary>
    public readonly RerankModel Fast = ModelFast;

    /// <summary>
    /// All known Cohere Rerank 4 models.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [ModelPro, ModelFast]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;

    internal RerankModelCohereGen4()
    {
    }
}
