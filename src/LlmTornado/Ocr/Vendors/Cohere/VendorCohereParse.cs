using System.Collections.Generic;
using LlmTornado.Code;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LlmTornado.Ocr.Vendors.Cohere;

internal static class VendorCohereParse
{
    public static string SerializeRequest(OcrRequest request)
    {
        string? imageUrl = request.Document?.ImageUrl?.Url ?? request.Document?.DocumentUrl;

        JObject payload = new JObject
        {
            ["model"] = request.Model?.Name ?? "parse-v5.0",
            ["document"] = new JObject
            {
                ["type"] = "image_url",
                ["image_url"] = imageUrl ?? string.Empty
            },
            ["output_format"] = "markdown"
        };

        return payload.ToString(Formatting.None);
    }

    public static OcrResult? DeserializeResult(string jsonData)
    {
        VendorCohereParseResult? parsed = JsonConvert.DeserializeObject<VendorCohereParseResult>(jsonData);

        if (parsed is null)
        {
            return null;
        }

        List<OcrPageObject> pages = [];

        if (parsed.Pages is not null)
        {
            foreach (VendorCohereParsePage page in parsed.Pages)
            {
                OcrPageObject mapped = new OcrPageObject
                {
                    Index = page.Index,
                    Markdown = page.Markdown?.Content
                };

                if (page.Markdown?.Images is { Count: > 0 })
                {
                    mapped.Images = [];

                    foreach (VendorCohereParseImage image in page.Markdown.Images)
                    {
                        mapped.Images.Add(new OcrImageObject
                        {
                            Id = image.Id,
                            ImageAnnotation = image.Description,
                            TopLeftX = image.BoundingBox?.TopLeftX ?? 0,
                            TopLeftY = image.BoundingBox?.TopLeftY ?? 0,
                            BottomRightX = image.BoundingBox?.BottomRightX ?? 0,
                            BottomRightY = image.BoundingBox?.BottomRightY ?? 0
                        });
                    }
                }

                pages.Add(mapped);
            }
        }

        return new OcrResult
        {
            Pages = pages,
            Model = "parse-v5.0",
            UsageInfo = parsed.Meta?.BilledUnits?.Pages is { } billedPages
                ? new OcrUsageInfo { PagesProcessed = (int)billedPages }
                : null
        };
    }
}

internal class VendorCohereParseResult
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("pages")]
    public List<VendorCohereParsePage>? Pages { get; set; }

    [JsonProperty("meta")]
    public VendorCohereParseMeta? Meta { get; set; }
}

internal class VendorCohereParsePage
{
    [JsonProperty("type")]
    public string? Type { get; set; }

    [JsonProperty("index")]
    public int Index { get; set; }

    [JsonProperty("markdown")]
    public VendorCohereParseMarkdown? Markdown { get; set; }
}

internal class VendorCohereParseMarkdown
{
    [JsonProperty("content")]
    public string? Content { get; set; }

    [JsonProperty("images")]
    public List<VendorCohereParseImage>? Images { get; set; }
}

internal class VendorCohereParseImage
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("description")]
    public string? Description { get; set; }

    [JsonProperty("bounding_box")]
    public VendorCohereParseBoundingBox? BoundingBox { get; set; }
}

internal class VendorCohereParseBoundingBox
{
    [JsonProperty("top_left_x")]
    public int TopLeftX { get; set; }

    [JsonProperty("top_left_y")]
    public int TopLeftY { get; set; }

    [JsonProperty("bottom_right_x")]
    public int BottomRightX { get; set; }

    [JsonProperty("bottom_right_y")]
    public int BottomRightY { get; set; }
}

internal class VendorCohereParseMeta
{
    [JsonProperty("billed_units")]
    public VendorCohereParseBilledUnits? BilledUnits { get; set; }
}

internal class VendorCohereParseBilledUnits
{
    [JsonProperty("pages")]
    public double? Pages { get; set; }
}
