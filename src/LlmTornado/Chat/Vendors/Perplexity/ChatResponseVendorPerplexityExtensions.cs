using System.Collections.Generic;
using Newtonsoft.Json;

namespace LlmTornado.Chat.Vendors.Perplexity;

/// <summary>
/// Inbound Perplexity features with no shared equivalent.
/// </summary>
public class ChatResponseVendorPerplexityExtensions
{
    /// <summary>
    /// Search results used to ground the response. Replaces the deprecated <c>citations</c> field.
    /// </summary>
    public List<VendorPerplexitySearchResult>? SearchResults { get; set; }
    
    /// <summary>
    /// Related questions suggested by the model.
    /// </summary>
    public List<string>? RelatedQuestions { get; set; }
    
    /// <summary>
    /// Images returned when image results are enabled.
    /// </summary>
    public List<VendorPerplexityImageResult>? Images { get; set; }
}

/// <summary>
/// A search result used by a Perplexity model.
/// </summary>
public class VendorPerplexitySearchResult
{
    /// <summary>
    /// Result identifier used in inline citations such as <c>[1]</c> or <c>[web:1]</c>.
    /// </summary>
    [JsonProperty("id")]
    public int? Id { get; set; }
    
    /// <summary>
    /// Page title.
    /// </summary>
    [JsonProperty("title")]
    public string? Title { get; set; }
    
    /// <summary>
    /// Page URL.
    /// </summary>
    [JsonProperty("url")]
    public string? Url { get; set; }
    
    /// <summary>
    /// Original publication date.
    /// </summary>
    [JsonProperty("date")]
    public string? Date { get; set; }
    
    /// <summary>
    /// Last-updated date when provided.
    /// </summary>
    [JsonProperty("last_updated")]
    public string? LastUpdated { get; set; }
    
    /// <summary>
    /// Snippet of the source content.
    /// </summary>
    [JsonProperty("snippet")]
    public string? Snippet { get; set; }
    
    /// <summary>
    /// Source type (for example <c>web</c>).
    /// </summary>
    [JsonProperty("source")]
    public string? Source { get; set; }
}

/// <summary>
/// An image returned by Perplexity.
/// </summary>
public class VendorPerplexityImageResult
{
    /// <summary>
    /// Image URL.
    /// </summary>
    [JsonProperty("image_url")]
    public string? ImageUrl { get; set; }
    
    /// <summary>
    /// Origin page URL.
    /// </summary>
    [JsonProperty("origin_url")]
    public string? OriginUrl { get; set; }
    
    /// <summary>
    /// Image height in pixels.
    /// </summary>
    [JsonProperty("height")]
    public int? Height { get; set; }
    
    /// <summary>
    /// Image width in pixels.
    /// </summary>
    [JsonProperty("width")]
    public int? Width { get; set; }
}
