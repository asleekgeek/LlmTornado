using System;

namespace LlmTornado.Embedding.Vendors.Voyage;

/// <summary>
/// Embedding features supported only by Voyage.
/// </summary>
public class EmbeddingRequestVendorVoyageExtensions
{
    /// <summary>
    /// Type of the input text. Defaults to null. Other options: query, document.
    /// </summary>
    public EmbeddingVendorVoyageInputTypes? InputType { get; set; }
    
    /// <summary>
    /// Whether to truncate the input texts to fit within the context length. Defaults to true.
    /// </summary>
    public bool? Truncation { get; set; }

    /// <summary>
    /// Format in which the embeddings are encoded. Defaults to a numeric array. Other option: base64.
    /// </summary>
    public EmbeddingVendorVoyageEncodingFormats? EncodingFormat { get; set; }
}

/// <summary>
/// The data type for the embeddings to be returned. Defaults to float.
/// </summary>
public enum EmbeddingOutputDtypes
{
    /// <summary>
    /// <see cref="float"/>
    /// </summary>
    Float,
    
    /// <summary>
    /// <see cref="sbyte"/>
    /// </summary>
    Int8,
    
    /// <summary>
    /// <see cref="byte"/>
    /// </summary>
    Uint8,
    
    /// <summary>
    /// List<sbyte/>
    /// </summary>
    Binary,
    
    /// <summary>
    /// List<byte/>
    /// </summary>
    Ubinary
}

/// <summary>
/// Format in which Voyage embeddings are encoded.
/// </summary>
public enum EmbeddingVendorVoyageEncodingFormats
{
    /// <summary>
    /// The embeddings are represented as a Base64-encoded NumPy array.
    /// </summary>
    Base64
}

/// <summary>
/// Type of the input text. Defaults to null. Other options: query, document.
/// </summary>
public enum EmbeddingVendorVoyageInputTypes
{
    /// <summary>
    /// Represent the query for retrieving supporting documents:
    /// </summary>
    Query,
    
    /// <summary>
    /// Represent the document for retrieval:
    /// </summary>
    Document
}