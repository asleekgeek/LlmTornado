using System.Collections.Generic;
using Newtonsoft.Json;

namespace LlmTornado.Ocr.Vendors.Zai;

/// <summary>
/// Z.AI layout parsing response.
/// </summary>
internal class VendorZaiOcrResult
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("created")]
    public long Created { get; set; }

    [JsonProperty("model")]
    public string? Model { get; set; }

    [JsonProperty("md_results")]
    public string? MdResults { get; set; }

    [JsonProperty("layout_details")]
    public List<List<VendorZaiLayoutDetail>>? LayoutDetails { get; set; }

    [JsonProperty("layout_visualization")]
    public List<string>? LayoutVisualization { get; set; }

    [JsonProperty("data_info")]
    public VendorZaiOcrDataInfo? DataInfo { get; set; }

    [JsonProperty("usage")]
    public VendorZaiOcrUsage? Usage { get; set; }

    [JsonProperty("request_id")]
    public string? RequestId { get; set; }

    public static OcrResult? Deserialize(string json)
    {
        VendorZaiOcrResult? raw = JsonConvert.DeserializeObject<VendorZaiOcrResult>(json);
        return raw?.ToOcrResult();
    }

    public OcrResult ToOcrResult()
    {
        List<OcrPageObject> pages = [];

        if (LayoutDetails is { Count: > 0 })
        {
            for (int i = 0; i < LayoutDetails.Count; i++)
            {
                pages.Add(MapPage(i, LayoutDetails[i]));
            }
        }
        else
        {
            pages.Add(new OcrPageObject
            {
                Index = 0,
                Markdown = MdResults
            });
        }

        if (pages.Count > 0 && string.IsNullOrEmpty(pages[0].Markdown) && !string.IsNullOrEmpty(MdResults))
        {
            pages[0].Markdown = MdResults;
        }

        return new OcrResult
        {
            Model = Model,
            DocumentAnnotation = MdResults,
            Pages = pages,
            UsageInfo = new OcrUsageInfo
            {
                PagesProcessed = DataInfo?.NumPages ?? pages.Count
            }
        };
    }

    private static OcrPageObject MapPage(int index, List<VendorZaiLayoutDetail> details)
    {
        List<OcrImageObject> images = [];
        List<OcrTableObject> tables = [];
        VendorZaiLayoutDetail? first = details.Count > 0 ? details[0] : null;
        int width = first?.Width ?? 0;
        int height = first?.Height ?? 0;

        foreach (VendorZaiLayoutDetail detail in details)
        {
            if (detail.Label == "image")
            {
                images.Add(MapImage(detail, width, height));
            }
            else if (detail.Label == "table")
            {
                tables.Add(new OcrTableObject
                {
                    Id = detail.Index.ToString(),
                    Content = detail.Content,
                    Format = "html"
                });
            }
        }

        return new OcrPageObject
        {
            Index = index,
            Markdown = null,
            Images = images.Count > 0 ? images : null,
            Tables = tables.Count > 0 ? tables : null,
            Dimensions = width > 0 && height > 0
                ? new OcrDimensions { Width = width, Height = height }
                : null
        };
    }

    private static OcrImageObject MapImage(VendorZaiLayoutDetail detail, int width, int height)
    {
        int topLeftX = 0, topLeftY = 0, bottomRightX = 0, bottomRightY = 0;

        if (detail.Bbox2d is { Count: >= 4 } && width > 0 && height > 0)
        {
            topLeftX = (int)(detail.Bbox2d[0] * width);
            topLeftY = (int)(detail.Bbox2d[1] * height);
            bottomRightX = (int)(detail.Bbox2d[2] * width);
            bottomRightY = (int)(detail.Bbox2d[3] * height);
        }

        return new OcrImageObject
        {
            Id = detail.Index.ToString(),
            TopLeftX = topLeftX,
            TopLeftY = topLeftY,
            BottomRightX = bottomRightX,
            BottomRightY = bottomRightY,
            ImageBase64 = detail.Content
        };
    }
}

internal class VendorZaiLayoutDetail
{
    [JsonProperty("index")]
    public int Index { get; set; }

    [JsonProperty("label")]
    public string? Label { get; set; }

    [JsonProperty("bbox_2d")]
    public List<double>? Bbox2d { get; set; }

    [JsonProperty("content")]
    public string? Content { get; set; }

    [JsonProperty("height")]
    public int Height { get; set; }

    [JsonProperty("width")]
    public int Width { get; set; }
}

internal class VendorZaiOcrDataInfo
{
    [JsonProperty("num_pages")]
    public int NumPages { get; set; }
}

internal class VendorZaiOcrUsage
{
    [JsonProperty("total_tokens")]
    public long? TotalTokens { get; set; }
}
