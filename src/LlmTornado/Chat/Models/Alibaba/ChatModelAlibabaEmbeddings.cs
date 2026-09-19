using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models.Alibaba;

/// <summary>
/// Alibaba embedding models - multilingual text embedding models for semantic analysis.
/// </summary>
public class ChatModelAlibabaEmbeddings : IVendorModelClassProvider
{
    /// <summary>
    /// Qwen3.7-Text-Embedding - Multilingual embedding model with 256–2560 customizable dimensions
    /// </summary>
    public static readonly ChatModel ModelQwen37TextEmbedding = new ChatModel("qwen3.7-text-embedding", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen37TextEmbedding"/>
    /// </summary>
    public readonly ChatModel Qwen37TextEmbedding = ModelQwen37TextEmbedding;

    /// <summary>
    /// Tongyi-Embedding-Vision-Plus - Multimodal embedding model for text and images
    /// </summary>
    public static readonly ChatModel ModelTongyiEmbeddingVisionPlus = new ChatModel("tongyi-embedding-vision-plus", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelTongyiEmbeddingVisionPlus"/>
    /// </summary>
    public readonly ChatModel TongyiEmbeddingVisionPlus = ModelTongyiEmbeddingVisionPlus;

    /// <summary>
    /// Qwen3-Rerank - Reranking model for retrieval pipelines
    /// </summary>
    public static readonly ChatModel ModelQwen3Rerank = new ChatModel("qwen3-rerank", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3Rerank"/>
    /// </summary>
    public readonly ChatModel Qwen3Rerank = ModelQwen3Rerank;

    /// <summary>
    /// Text-Embedding-v4 - General Text Vector V4 version with improved performance
    /// </summary>
    public static readonly ChatModel ModelTextEmbeddingV4 = new ChatModel("text-embedding-v4", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelTextEmbeddingV4"/>
    /// </summary>
    public readonly ChatModel TextEmbeddingV4 = ModelTextEmbeddingV4;

    /// <summary>
    /// Text-Embedding-v3 - General text vectorization model
    /// </summary>
    public static readonly ChatModel ModelTextEmbeddingV3 = new ChatModel("text-embedding-v3", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelTextEmbeddingV3"/>
    /// </summary>
    public readonly ChatModel TextEmbeddingV3 = ModelTextEmbeddingV3;

    /// <summary>
    /// All known embedding models from Alibaba.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelQwen37TextEmbedding, ModelTongyiEmbeddingVisionPlus, ModelQwen3Rerank, ModelTextEmbeddingV4, ModelTextEmbeddingV3
    ]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;

    internal ChatModelAlibabaEmbeddings()
    {
    }
}
