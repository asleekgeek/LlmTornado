using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Embedding.Models.Perplexity;

/// <summary>
/// Standard Perplexity embedding models for independent texts and queries.
/// </summary>
public class EmbeddingModelPerplexityStandard : IVendorModelClassProvider
{
    /// <summary>
    /// Compact 0.6B embedding model. 1024 dimensions, 32K context, Matryoshka (128–1024).
    /// </summary>
    public static readonly EmbeddingModel ModelV1Small = new EmbeddingModel("pplx-embed-v1-0.6b", LLmProviders.Perplexity, 32_000, 1024, [256, 512, 1024]);

    /// <summary>
    /// <inheritdoc cref="ModelV1Small"/>
    /// </summary>
    public readonly EmbeddingModel V1Small = ModelV1Small;
    
    /// <summary>
    /// Higher-capacity 4B embedding model. 2560 dimensions, 32K context, Matryoshka (128–2560).
    /// </summary>
    public static readonly EmbeddingModel ModelV1Large = new EmbeddingModel("pplx-embed-v1-4b", LLmProviders.Perplexity, 32_000, 2560, [256, 512, 1024, 2048, 2560]);

    /// <summary>
    /// <inheritdoc cref="ModelV1Large"/>
    /// </summary>
    public readonly EmbeddingModel V1Large = ModelV1Large;
    
    /// <summary>
    /// All known standard Perplexity embedding models.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelV1Small, ModelV1Large
    ]);
    
    /// <inheritdoc />
    public List<IModel> AllModels => ModelsAll;
    
    internal EmbeddingModelPerplexityStandard()
    {
        
    }
}
