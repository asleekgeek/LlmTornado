using System.Linq;
using Newtonsoft.Json;

namespace LlmTornado.Ocr.Vendors.Zai;

/// <summary>
/// Z.AI layout parsing request. Maps to POST /paas/v4/layout_parsing.
/// </summary>
internal class VendorZaiOcrRequest
{
    [JsonProperty("model")]
    public string? Model { get; set; }

    [JsonProperty("file")]
    public string? File { get; set; }

    [JsonProperty("return_crop_images")]
    public bool? ReturnCropImages { get; set; }

    [JsonProperty("need_layout_visualization")]
    public bool? NeedLayoutVisualization { get; set; }

    [JsonProperty("start_page_id")]
    public int? StartPageId { get; set; }

    [JsonProperty("end_page_id")]
    public int? EndPageId { get; set; }

    [JsonProperty("request_id")]
    public string? RequestId { get; set; }

    public VendorZaiOcrRequest(OcrRequest request)
    {
        Model = request.Model?.Name ?? "glm-ocr";
        File = ResolveFile(request.Document);
        ReturnCropImages = request.IncludeImageBase64;
        RequestId = request.Id;

        if (request.Pages is { Count: > 0 })
        {
            // Z.AI pages are 1-indexed; the harmonized OCR API uses 0-indexed pages.
            StartPageId = request.Pages.Min() + 1;
            EndPageId = request.Pages.Max() + 1;
        }
    }

    internal static string? ResolveFile(OcrDocumentInput? document)
    {
        if (document is null)
        {
            return null;
        }

        return document.Type switch
        {
            OcrDocumentType.DocumentUrl => document.DocumentUrl,
            OcrDocumentType.ImageUrl => document.ImageUrl?.Url,
            OcrDocumentType.File => document.FileId,
            _ => document.DocumentUrl ?? document.ImageUrl?.Url ?? document.FileId
        };
    }
}
