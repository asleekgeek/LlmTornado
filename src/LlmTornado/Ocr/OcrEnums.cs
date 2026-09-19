using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LlmTornado.Ocr;

/// <summary>
/// Table formatting options for OCR output.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum OcrTableFormat
{
    /// <summary>
    /// Return tables as markdown.
    /// </summary>
    [EnumMember(Value = "markdown")]
    Markdown,
    
    /// <summary>
    /// Return tables as HTML.
    /// </summary>
    [EnumMember(Value = "html")]
    Html
}

/// <summary>
/// Document input type for OCR.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum OcrDocumentType
{
    /// <summary>
    /// File uploaded to provider's file storage.
    /// </summary>
    [EnumMember(Value = "file")]
    File,
    
    /// <summary>
    /// Public URL to a document (PDF, DOCX, etc.).
    /// </summary>
    [EnumMember(Value = "document_url")]
    DocumentUrl,
    
    /// <summary>
    /// Public URL or data URL to an image.
    /// </summary>
    [EnumMember(Value = "image_url")]
    ImageUrl
}

/// <summary>
/// Image detail level for OCR processing.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum OcrImageDetail
{
    /// <summary>
    /// Automatically decides the detail level.
    /// </summary>
    [EnumMember(Value = "auto")]
    Auto,
    
    /// <summary>
    /// High detail - images will be tiled for better accuracy.
    /// </summary>
    [EnumMember(Value = "high")]
    High,
    
    /// <summary>
    /// Low detail - images passed as single tile, faster processing.
    /// </summary>
    [EnumMember(Value = "low")]
    Low
}

/// <summary>
/// Granularity of OCR confidence scores. Available on OCR 4 and newer.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum OcrConfidenceScoresGranularity
{
    /// <summary>
    /// Aggregate statistics on each page (<c>average_page_confidence_score</c>, <c>minimum_page_confidence_score</c>).
    /// </summary>
    [EnumMember(Value = "page")]
    Page,
    
    /// <summary>
    /// Page scores plus per-block scores when <c>include_blocks</c> is true.
    /// </summary>
    [EnumMember(Value = "block")]
    Block,
    
    /// <summary>
    /// Page scores plus a <c>word_confidence_scores</c> array on each page and table entry.
    /// </summary>
    [EnumMember(Value = "word")]
    Word
}

/// <summary>
/// Structural label of an OCR content block. Available on OCR 4 and newer.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum OcrBlockType
{
    /// <summary>
    /// A paragraph of body text.
    /// </summary>
    [EnumMember(Value = "text")]
    Text,
    
    /// <summary>
    /// A document title or section heading.
    /// </summary>
    [EnumMember(Value = "title")]
    Title,
    
    /// <summary>
    /// A bulleted or numbered list.
    /// </summary>
    [EnumMember(Value = "list")]
    List,
    
    /// <summary>
    /// A table region. May include <c>table_id</c> referencing <c>tables</c>.
    /// </summary>
    [EnumMember(Value = "table")]
    Table,
    
    /// <summary>
    /// An image region. May include <c>image_id</c> referencing <c>images</c>.
    /// </summary>
    [EnumMember(Value = "image")]
    Image,
    
    /// <summary>
    /// A math equation.
    /// </summary>
    [EnumMember(Value = "equation")]
    Equation,
    
    /// <summary>
    /// A caption associated with a figure or table.
    /// </summary>
    [EnumMember(Value = "caption")]
    Caption,
    
    /// <summary>
    /// A code block.
    /// </summary>
    [EnumMember(Value = "code")]
    Code,
    
    /// <summary>
    /// A bibliography or references section.
    /// </summary>
    [EnumMember(Value = "references")]
    References,
    
    /// <summary>
    /// A sidebar, callout, or other marginal text block.
    /// </summary>
    [EnumMember(Value = "aside_text")]
    AsideText,
    
    /// <summary>
    /// A page header.
    /// </summary>
    [EnumMember(Value = "header")]
    Header,
    
    /// <summary>
    /// A page footer.
    /// </summary>
    [EnumMember(Value = "footer")]
    Footer,
    
    /// <summary>
    /// A signature region.
    /// </summary>
    [EnumMember(Value = "signature")]
    Signature
}
