using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Rerank.Models.Cohere;

/// <summary>
/// Rerank 3 models from Cohere.
/// </summary>
public class RerankModelCohereGen3 : IVendorModelClassProvider
{
    /// <summary>
    /// A multilingual reranker for English and non-English documents and semi-structured data (JSON). 4K context.
    /// </summary>
    public static readonly RerankModel ModelV35 = new RerankModel("rerank-v3.5", LLmProviders.Cohere);

    /// <summary>
    /// <inheritdoc cref="ModelV35"/>
    /// </summary>
    public readonly RerankModel V35 = ModelV35;

    /// <summary>
    /// English-only reranker for documents and semi-structured data (JSON). 4K context.
    /// </summary>
    public static readonly RerankModel ModelEnglish = new RerankModel("rerank-english-v3.0", LLmProviders.Cohere);

    /// <summary>
    /// <inheritdoc cref="ModelEnglish"/>
    /// </summary>
    public readonly RerankModel English = ModelEnglish;

    /// <summary>
    /// Multilingual reranker for non-English documents and semi-structured data (JSON). 4K context.
    /// </summary>
    public static readonly RerankModel ModelMultilingual = new RerankModel("rerank-multilingual-v3.0", LLmProviders.Cohere);

    /// <summary>
    /// <inheritdoc cref="ModelMultilingual"/>
    /// </summary>
    public readonly RerankModel Multilingual = ModelMultilingual;

    /// <summary>
    /// All known Cohere Rerank 3 models.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [ModelV35, ModelEnglish, ModelMultilingual]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;

    internal RerankModelCohereGen3()
    {
    }
}
