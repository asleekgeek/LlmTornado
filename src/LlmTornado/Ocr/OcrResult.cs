using System.Collections.Generic;
using Newtonsoft.Json;

namespace LlmTornado.Ocr;

/// <summary>
/// Represents a response from the OCR API.
/// </summary>
public class OcrResult : ApiResultBase
{
    /// <summary>
    /// List of OCR info for pages.
    /// </summary>
    [JsonProperty("pages")]
    public List<OcrPageObject>? Pages { get; set; }

    /// <summary>
    /// The model used to generate the OCR.
    /// </summary>
    [JsonProperty("model")]
    public string? Model { get; set; }

    /// <summary>
    /// Usage information.
    /// </summary>
    [JsonProperty("usage_info")]
    public OcrUsageInfo? UsageInfo { get; set; }

    /// <summary>
    /// Formatted response in the request_format if provided in json str.
    /// </summary>
    [JsonProperty("document_annotation")]
    public string? DocumentAnnotation { get; set; }
    
    /// <summary>
    /// Raw response from the API.
    /// </summary>
    [JsonIgnore]
    public string? RawResponse { get; set; }
}

/// <summary>
/// Represents OCR information for a single page.
/// </summary>
public class OcrPageObject
{
    /// <summary>
    /// The zero-based index of the page.
    /// </summary>
    [JsonProperty("index")]
    public int Index { get; set; }

    /// <summary>
    /// The markdown representation of the page content.
    /// </summary>
    [JsonProperty("markdown")]
    public string? Markdown { get; set; }

    /// <summary>
    /// Images extracted from the page.
    /// </summary>
    [JsonProperty("images")]
    public List<OcrImageObject>? Images { get; set; }
    
    /// <summary>
    /// Tables extracted from the page. Only present when table_format is set.
    /// </summary>
    [JsonProperty("tables")]
    public List<OcrTableObject>? Tables { get; set; }
    
    /// <summary>
    /// Hyperlinks detected in the page.
    /// </summary>
    [JsonProperty("hyperlinks")]
    public List<string>? Hyperlinks { get; set; }

    /// <summary>
    /// Header content when extract_header is true.
    /// </summary>
    [JsonProperty("header")]
    public string? Header { get; set; }

    /// <summary>
    /// Footer content when extract_footer is true.
    /// </summary>
    [JsonProperty("footer")]
    public string? Footer { get; set; }

    /// <summary>
    /// The dimensions of the page.
    /// </summary>
    [JsonProperty("dimensions")]
    public OcrDimensions? Dimensions { get; set; }

    /// <summary>
    /// Page-level confidence scores when <c>confidence_scores_granularity</c> is set.
    /// </summary>
    [JsonProperty("confidence_scores")]
    public OcrConfidenceScores? ConfidenceScores { get; set; }

    /// <summary>
    /// Per-word confidence values when granularity is <c>word</c>.
    /// </summary>
    [JsonProperty("word_confidence_scores")]
    public List<OcrWordConfidenceScore>? WordConfidenceScores { get; set; }

    /// <summary>
    /// Paragraph-level content blocks in reading order when <c>include_blocks</c> is true. OCR 4+.
    /// </summary>
    [JsonProperty("blocks")]
    public List<OcrBlock>? Blocks { get; set; }
}

/// <summary>
/// A structural content block extracted by OCR 4+.
/// </summary>
public class OcrBlock
{
    /// <summary>
    /// Structural label of the block.
    /// </summary>
    [JsonProperty("type")]
    public OcrBlockType Type { get; set; }

    /// <summary>
    /// Extracted content. May be empty for image or signature blocks.
    /// </summary>
    [JsonProperty("content")]
    public string? Content { get; set; }

    /// <summary>
    /// Top-left X coordinate.
    /// </summary>
    [JsonProperty("top_left_x")]
    public int TopLeftX { get; set; }

    /// <summary>
    /// Top-left Y coordinate.
    /// </summary>
    [JsonProperty("top_left_y")]
    public int TopLeftY { get; set; }

    /// <summary>
    /// Bottom-right X coordinate.
    /// </summary>
    [JsonProperty("bottom_right_x")]
    public int BottomRightX { get; set; }

    /// <summary>
    /// Bottom-right Y coordinate.
    /// </summary>
    [JsonProperty("bottom_right_y")]
    public int BottomRightY { get; set; }

    /// <summary>
    /// Reference to the matching entry in <see cref="OcrPageObject.Images"/> for image blocks.
    /// </summary>
    [JsonProperty("image_id")]
    public string? ImageId { get; set; }

    /// <summary>
    /// Reference to the matching entry in <see cref="OcrPageObject.Tables"/> for table blocks.
    /// </summary>
    [JsonProperty("table_id")]
    public string? TableId { get; set; }

    /// <summary>
    /// Block-level confidence scores when granularity is <c>block</c>.
    /// </summary>
    [JsonProperty("confidence_scores")]
    public OcrBlockConfidenceScores? ConfidenceScores { get; set; }
}

/// <summary>
/// Aggregate OCR confidence statistics for a page.
/// </summary>
public class OcrConfidenceScores
{
    /// <summary>
    /// Average confidence across the page.
    /// </summary>
    [JsonProperty("average_page_confidence_score")]
    public double? AveragePageConfidenceScore { get; set; }

    /// <summary>
    /// Lowest confidence on the page.
    /// </summary>
    [JsonProperty("minimum_page_confidence_score")]
    public double? MinimumPageConfidenceScore { get; set; }
}

/// <summary>
/// Confidence statistics for a single OCR block.
/// </summary>
public class OcrBlockConfidenceScores
{
    /// <summary>
    /// Average confidence for the extracted block content. Null for blocks without text.
    /// </summary>
    [JsonProperty("average_content_confidence_score")]
    public double? AverageContentConfidenceScore { get; set; }

    /// <summary>
    /// Lowest content confidence in the block. Null for blocks without text.
    /// </summary>
    [JsonProperty("minimum_content_confidence_score")]
    public double? MinimumContentConfidenceScore { get; set; }

    /// <summary>
    /// Confidence that the detected block type is correct.
    /// </summary>
    [JsonProperty("block_type_confidence_score")]
    public double? BlockTypeConfidenceScore { get; set; }
}

/// <summary>
/// Per-word OCR confidence.
/// </summary>
public class OcrWordConfidenceScore
{
    /// <summary>
    /// Recognized word.
    /// </summary>
    [JsonProperty("word")]
    public string? Word { get; set; }

    /// <summary>
    /// Confidence in the range 0–1.
    /// </summary>
    [JsonProperty("confidence")]
    public double? Confidence { get; set; }
}

/// <summary>
/// Represents an extracted image from OCR.
/// </summary>
public class OcrImageObject
{
    /// <summary>
    /// Image identifier.
    /// </summary>
    [JsonProperty("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Top-left X coordinate.
    /// </summary>
    [JsonProperty("top_left_x")]
    public int TopLeftX { get; set; }

    /// <summary>
    /// Top-left Y coordinate.
    /// </summary>
    [JsonProperty("top_left_y")]
    public int TopLeftY { get; set; }

    /// <summary>
    /// Bottom-right X coordinate.
    /// </summary>
    [JsonProperty("bottom_right_x")]
    public int BottomRightX { get; set; }

    /// <summary>
    /// Bottom-right Y coordinate.
    /// </summary>
    [JsonProperty("bottom_right_y")]
    public int BottomRightY { get; set; }

    /// <summary>
    /// Base64 encoded image data if include_image_base64 was requested.
    /// </summary>
    [JsonProperty("image_base64")]
    public string? ImageBase64 { get; set; }
    
    /// <summary>
    /// Image annotation if bbox_annotation_format was provided.
    /// </summary>
    [JsonProperty("image_annotation")]
    public string? ImageAnnotation { get; set; }
}

/// <summary>
/// Represents an extracted table from OCR.
/// </summary>
public class OcrTableObject
{
    /// <summary>
    /// Table identifier.
    /// </summary>
    [JsonProperty("id")]
    public string? Id { get; set; }
    
    /// <summary>
    /// Table content in the requested format (markdown or html).
    /// </summary>
    [JsonProperty("content")]
    public string? Content { get; set; }
    
    /// <summary>
    /// Format of the table content.
    /// </summary>
    [JsonProperty("format")]
    public string? Format { get; set; }
}

/// <summary>
/// Represents page dimensions.
/// </summary>
public class OcrDimensions
{
    /// <summary>
    /// DPI of the page.
    /// </summary>
    [JsonProperty("dpi")]
    public int Dpi { get; set; }

    /// <summary>
    /// Height in pixels.
    /// </summary>
    [JsonProperty("height")]
    public int Height { get; set; }

    /// <summary>
    /// Width in pixels.
    /// </summary>
    [JsonProperty("width")]
    public int Width { get; set; }
}

/// <summary>
/// Represents OCR usage information.
/// </summary>
public class OcrUsageInfo
{
    /// <summary>
    /// Number of pages processed.
    /// </summary>
    [JsonProperty("pages_processed")]
    public int PagesProcessed { get; set; }

    /// <summary>
    /// Size of the document in bytes.
    /// </summary>
    [JsonProperty("doc_size_bytes")]
    public long? DocSizeBytes { get; set; }
}
