using System.Collections.Generic;
using LlmTornado.Chat;
using LlmTornado.Code;
using LlmTornado.Ocr.Models;
using LlmTornado.Ocr.Vendors.Cohere;
using LlmTornado.Ocr.Vendors.Zai;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LlmTornado.Ocr;

/// <summary>
/// A request for the OCR API.
/// </summary>
public class OcrRequest : ISerializableRequest
{
    /// <summary>
    /// Creates a new, empty <see cref="OcrRequest"/>
    /// </summary>
    public OcrRequest()
    {
    }

    /// <summary>
    /// Creates a new request for the OCR API.
    /// </summary>
    /// <param name="model">The model to use for OCR.</param>
    /// <param name="document">The document to run OCR on.</param>
    public OcrRequest(OcrModel model, OcrDocumentInput document)
    {
        Model = model;
        Document = document;
    }

    /// <summary>
    /// Create a new OCR request using the data from the input request.
    /// </summary>
    /// <param name="basedOn"></param>
    public OcrRequest(OcrRequest? basedOn)
    {
        if (basedOn is null)
        {
            return;
        }

        CopyData(basedOn);
    }

    private void CopyData(OcrRequest basedOn)
    {
        Model = basedOn.Model;
        Document = basedOn.Document;
        Id = basedOn.Id;
        Pages = basedOn.Pages;
        IncludeImageBase64 = basedOn.IncludeImageBase64;
        ImageLimit = basedOn.ImageLimit;
        ImageMinSize = basedOn.ImageMinSize;
        ExtractHeader = basedOn.ExtractHeader;
        ExtractFooter = basedOn.ExtractFooter;
        TableFormat = basedOn.TableFormat;
        BboxAnnotationFormat = basedOn.BboxAnnotationFormat;
        DocumentAnnotationFormat = basedOn.DocumentAnnotationFormat;
        IncludeBlocks = basedOn.IncludeBlocks;
        ConfidenceScoresGranularity = basedOn.ConfidenceScoresGranularity;
        PagesRange = basedOn.PagesRange;
    }

    /// <summary>
    /// The model to use for OCR (e.g., "mistral-ocr-latest").
    /// </summary>
    [JsonProperty("model")]
    [JsonConverter(typeof(IModelConverter))]
    public OcrModel Model { get; set; }

    /// <summary>
    /// The document to run OCR on.
    /// </summary>
    [JsonProperty("document")]
    public OcrDocumentInput Document { get; set; }

    /// <summary>
    /// Optional client-side ID for the request.
    /// </summary>
    [JsonProperty("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Specific pages to process as a list of 0-indexed page numbers.
    /// For comma-separated digits and ranges (e.g. <c>"0,2-4"</c>), use <see cref="PagesRange"/> instead.
    /// </summary>
    [JsonProperty("pages")]
    public List<int>? Pages { get; set; }

    /// <summary>
    /// Specific pages to process as a string of comma-separated digits and ranges
    /// (e.g. <c>"0,1,2"</c>, <c>"0-5"</c>, or <c>"0,2-4"</c>). Takes precedence over <see cref="Pages"/> when set.
    /// </summary>
    [JsonIgnore]
    public string? PagesRange { get; set; }

    /// <summary>
    /// Include image base64 strings in the response.
    /// </summary>
    [JsonProperty("include_image_base64")]
    public bool? IncludeImageBase64 { get; set; }

    /// <summary>
    /// Max images to extract.
    /// </summary>
    [JsonProperty("image_limit")]
    public int? ImageLimit { get; set; }

    /// <summary>
    /// Minimum height and width of image to extract.
    /// </summary>
    [JsonProperty("image_min_size")]
    public int? ImageMinSize { get; set; }

    /// <summary>
    /// Whether to extract headers.
    /// </summary>
    [JsonProperty("extract_header")]
    public bool? ExtractHeader { get; set; }

    /// <summary>
    /// Whether to extract footers.
    /// </summary>
    [JsonProperty("extract_footer")]
    public bool? ExtractFooter { get; set; }

    /// <summary>
    /// Format for tables.
    /// </summary>
    [JsonProperty("table_format")]
    public OcrTableFormat? TableFormat { get; set; }

    /// <summary>
    /// Specify the format that the model must output for bounding box annotations.
    /// </summary>
    [JsonProperty("bbox_annotation_format")]
    public ChatRequestResponseFormats? BboxAnnotationFormat { get; set; }

    /// <summary>
    /// Specify the format that the model must output for document annotations.
    /// </summary>
    [JsonProperty("document_annotation_format")]
    public ChatRequestResponseFormats? DocumentAnnotationFormat { get; set; }

    /// <summary>
    /// When true, each page includes a <c>blocks</c> array with paragraph-level bounding boxes and structural labels.
    /// Available on OCR 4 and newer.
    /// </summary>
    [JsonProperty("include_blocks")]
    public bool? IncludeBlocks { get; set; }

    /// <summary>
    /// Granularity of confidence scores: page, block, or word. Defaults to unset (no scores, smaller payload).
    /// Available on OCR 4 and newer. Block scores require <see cref="IncludeBlocks"/>.
    /// </summary>
    [JsonProperty("confidence_scores_granularity")]
    public OcrConfidenceScoresGranularity? ConfidenceScoresGranularity { get; set; }

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

    /// <summary>
    /// Serializes the request.
    /// </summary>
    internal TornadoRequestContent SerializeInternal(IEndpointProvider provider, RequestSerializeOptions? options)
    {
        string body = provider.Provider switch
        {
            LLmProviders.Cohere => VendorCohereParse.SerializeRequest(this),
            LLmProviders.Zai => JsonConvert.SerializeObject(new VendorZaiOcrRequest(this), EndpointBase.NullSettings),
            _ => SerializeJson(options?.Pretty ?? false)
        };

        return new TornadoRequestContent(body, Model, UrlOverride ?? EndpointBase.BuildRequestUrl(null, provider, CapabilityEndpoints.Ocr, Model), provider, CapabilityEndpoints.Ocr);
    }

    private string SerializeJson(bool pretty)
    {
        if (PagesRange.IsNullOrWhiteSpace())
        {
            return this.ToJson(pretty);
        }

        JObject json = JObject.FromObject(this);
        json["pages"] = PagesRange;
        return json.ToString(pretty ? Formatting.Indented : Formatting.None);
    }
}
