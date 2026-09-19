using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Embedding.Models;
using Newtonsoft.Json;

namespace LlmTornado.Embedding;

/// <summary>
/// A request for the contextual embeddings API.
/// </summary>
public class ContextualEmbeddingRequest : ISerializableRequest
{
    /// <summary>
    /// Creates a new request for the contextual embeddings API.
    /// </summary>
    /// <param name="model">The model to use for the embeddings.</param>
    /// <param name="inputs">A list of lists, where each inner list contains a query, a document, or document chunks to be vectorized.</param>
    public ContextualEmbeddingRequest(ContextualEmbeddingModel model, List<List<string>> inputs)
    {
        Model = model;
        Inputs = inputs;
    }

    /// <summary>
    /// Creates a new request with a flat list of documents or queries.
    /// Use this with <see cref="EnableAutoChunking"/> for backend document chunking, or with <see cref="ContextualEmbeddingInputType.Query"/> for queries.
    /// </summary>
    /// <param name="model">The model to use for the embeddings.</param>
    /// <param name="documents">Full documents or queries as a flat list of strings.</param>
    public ContextualEmbeddingRequest(ContextualEmbeddingModel model, List<string> documents)
    {
        Model = model;
        DocumentInputs = documents;
    }

    /// <summary>
    /// The model to use for the embeddings.
    /// </summary>
    [JsonProperty("model")]
    [JsonConverter(typeof(IModelConverter))]
    public ContextualEmbeddingModel Model { get; set; }

    /// <summary>
    /// A list of lists, where each inner list contains a query, a document, or document chunks to be vectorized.
    /// </summary>
    [JsonIgnore]
    public List<List<string>>? Inputs { get; set; }

    /// <summary>
    /// A flat list of full documents or queries. Required when <see cref="EnableAutoChunking"/> is true.
    /// </summary>
    [JsonIgnore]
    public List<string>? DocumentInputs { get; set; }

    [JsonProperty("inputs")]
    public object SerializedInputs => DocumentInputs is not null ? DocumentInputs : Inputs ?? [];

    /// <summary>
    /// Type of the input text.
    /// </summary>
    [JsonProperty("input_type")]
    public ContextualEmbeddingInputType? InputType { get; set; }

    /// <summary>
    /// The number of dimensions for resulting output embeddings.
    /// </summary>
    [JsonProperty("output_dimension")]
    public int? OutputDimension { get; set; }

    /// <summary>
    /// The data type for the embeddings to be returned.
    /// </summary>
    [JsonProperty("output_dtype")]
    public ContextualEmbeddingOutputDataType? OutputDataType { get; set; }

    /// <summary>
    /// Format in which the embeddings are encoded.
    /// </summary>
    [JsonProperty("encoding_format")]
    public ContextualEmbeddingEncodingFormat? EncodingFormat { get; set; }

    /// <summary>
    /// Whether to automatically chunk each input document on the backend.
    /// When true, <see cref="DocumentInputs"/> must be a flat list of full-document strings and <see cref="InputType"/> must be <see cref="ContextualEmbeddingInputType.Document"/>.
    /// </summary>
    [JsonProperty("enable_auto_chunking")]
    public bool? EnableAutoChunking { get; set; }

    /// <summary>
    /// Target chunk size in tokens when <see cref="EnableAutoChunking"/> is true. The server defaults to 512. Must not exceed 32K tokens.
    /// </summary>
    [JsonProperty("chunk_size")]
    public int? ChunkSize { get; set; }

    /// <summary>
    /// Chunk overlap in tokens when <see cref="EnableAutoChunking"/> is true. Must be smaller than <see cref="ChunkSize"/>.
    /// </summary>
    [JsonProperty("chunk_overlap")]
    public int? ChunkOverlap { get; set; }

    [JsonIgnore]
    internal string? UrlOverride { get; set; }
    
    internal void OverrideUrl(string url)
    {
        UrlOverride = url;
    }
    
    /// <summary>
    /// Serializes the request.
    /// </summary>
    public TornadoRequestContent Serialize(IEndpointProvider provider, RequestSerializeOptions options)
    {
        return SerializeInternal(provider, options);
    }
    
    /// <summary>
    /// Serializes the request.
    /// </summary>
    public TornadoRequestContent Serialize(IEndpointProvider provider)
    {
        return SerializeInternal(provider, null);
    }
    
    internal TornadoRequestContent SerializeInternal(IEndpointProvider provider, RequestSerializeOptions? options)
    {
        return new TornadoRequestContent(this.ToJson(options?.Pretty ?? false), Model, UrlOverride ?? EndpointBase.BuildRequestUrl(null, provider, CapabilityEndpoints.ContextualEmbeddings, Model), provider, CapabilityEndpoints.ContextualEmbeddings);
    }
}