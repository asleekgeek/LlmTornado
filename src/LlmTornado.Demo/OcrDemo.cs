using System.Linq;
using LlmTornado.Code;
using LlmTornado.Common;
using LlmTornado.Ocr;
using LlmTornado.Files;
using LlmTornado.Ocr.Models;

namespace LlmTornado.Demo;

public class OcrDemo : DemoBase
{
    [TornadoTest]
    public static async Task OcrDocumentUrl()
    {
        OcrResult? result = await Program.ConnectMulti().Ocr.Process(new OcrRequest(
            OcrModel.Mistral.Ocr41,
            OcrDocumentInput.FromDocumentUrl("https://arxiv.org/pdf/2201.04234"))
        {
            IncludeImageBase64 = false,
            TableFormat = OcrTableFormat.Markdown
        });
        
        Console.WriteLine($"Pages: {result?.Pages?.Count ?? 0}");
        Console.WriteLine($"Model: {result?.Model}");
        Console.WriteLine($"Pages processed: {result?.UsageInfo?.PagesProcessed ?? 0}");
        
        if (result?.Pages is { Count: > 0 })
        {
            string markdown = result.Pages[0].Markdown ?? string.Empty;
            Console.WriteLine($"First page markdown preview (200 chars): {markdown.Substring(0, Math.Min(200, markdown.Length))}...");
        }
    }
    
    [TornadoTest]
    public static async Task OcrImageUrl()
    {
        OcrResult? result = await Program.ConnectMulti().Ocr.Process(new OcrRequest(
            OcrModel.Mistral.Ocr3,
            OcrDocumentInput.FromImageUrl("https://raw.githubusercontent.com/mistralai/cookbook/refs/heads/main/mistral/ocr/receipt.png")));
        
        Console.WriteLine($"Pages: {result?.Pages?.Count ?? 0}");
        Console.WriteLine($"Model: {result?.Model}");
        
        if (result?.Pages is { Count: > 0 })
        {
            Console.WriteLine($"Markdown:\n{result.Pages[0].Markdown}");
        }
    }
    
    [TornadoTest]
    public static async Task OcrWithExtractHeaderFooter()
    {
        OcrResult? result = await Program.ConnectMulti().Ocr.Process(new OcrRequest(
            OcrModel.Mistral.Latest,
            OcrDocumentInput.FromDocumentUrl("https://arxiv.org/pdf/2201.04234"))
        {
            ExtractHeader = true,
            ExtractFooter = true,
            Pages = [0, 1] // Only process first two pages
        });
        
        Console.WriteLine($"Pages: {result?.Pages?.Count ?? 0}");
        
        if (result?.Pages is { Count: > 0 })
        {
            foreach (var page in result.Pages)
            {
                Console.WriteLine($"Page {page.Index}:");
                Console.WriteLine($"  Header: {page.Header ?? "(none)"}");
                Console.WriteLine($"  Footer: {page.Footer ?? "(none)"}");
                Console.WriteLine($"  Images: {page.Images?.Count ?? 0}");
                Console.WriteLine($"  Hyperlinks: {page.Hyperlinks?.Count ?? 0}");
            }
        }
    }
    
    [TornadoTest]
    public static async Task OcrHandwriting()
    {
        byte[] bytes = await File.ReadAllBytesAsync("Static/Images/low_quality_handwriting_cs.jpg");
        
        OcrResult? result = await Program.ConnectMulti().Ocr.Process(new OcrRequest(
            OcrModel.Mistral.Ocr3,
            OcrDocumentInput.FromImageBytes(bytes, "image/jpeg")));
        
        Console.WriteLine($"Pages: {result?.Pages?.Count ?? 0}");
        Console.WriteLine($"Model: {result?.Model}");
        Console.WriteLine($"Pages processed: {result?.UsageInfo?.PagesProcessed ?? 0}");
        
        if (result?.Pages is { Count: > 0 })
        {
            Console.WriteLine($"Extracted text:\n{result.Pages[0].Markdown}");
        }
    }
    [TornadoTest]
    public static async Task OcrWithFile()
    {
        Console.WriteLine("OcrWithFile demo");
        
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Static", "Images", "low_quality_handwriting_cs.jpg");
        HttpCallResult<TornadoFile> file = await Program.ConnectMulti().Files.Upload(new FileUploadRequest
        {
            Bytes = await File.ReadAllBytesAsync(path),
            Name = Path.GetFileName(path),
            Purpose = FilePurpose.Ocr
        }, LLmProviders.Mistral);

        if (file.Data is null)
        {
            Console.WriteLine("Failed to upload file");
            return;
        }

        Console.WriteLine($"File uploaded: {file.Data.Id}, Source: {file.Data.Source}, SampleType: {file.Data.SampleType}");
        
        OcrResult? result = await Program.ConnectMulti().Ocr.Process(new OcrRequest(
            OcrModel.Mistral.Ocr3,
            OcrDocumentInput.FromFile(file.Data))
        {
            IncludeImageBase64 = false
        });
        
        Console.WriteLine($"Pages: {result?.Pages?.Count ?? 0}");
        Console.WriteLine($"Model: {result?.Model}");
        
        if (result?.Pages is not null)
        {
            foreach (OcrPageObject page in result.Pages)
            {
                Console.WriteLine($"Page {page.Index}");
                Console.WriteLine(page.Markdown);
            }
        }
    }

    [TornadoTest]
    public static async Task OcrWithBlocksAndConfidence()
    {
        OcrResult? result = await Program.ConnectMulti().Ocr.Process(new OcrRequest(
            OcrModel.Mistral.Ocr41,
            OcrDocumentInput.FromDocumentUrl("https://arxiv.org/pdf/2201.04234"))
        {
            IncludeBlocks = true,
            ConfidenceScoresGranularity = OcrConfidenceScoresGranularity.Block,
            PagesRange = "0-1"
        });

        Console.WriteLine($"Pages: {result?.Pages?.Count ?? 0}");
        Console.WriteLine($"Model: {result?.Model}");

        if (result?.Pages is { Count: > 0 })
        {
            OcrPageObject page = result.Pages[0];
            Console.WriteLine($"Page confidence avg: {page.ConfidenceScores?.AveragePageConfidenceScore}");
            Console.WriteLine($"Blocks: {page.Blocks?.Count ?? 0}");

            if (page.Blocks is { Count: > 0 })
            {
                foreach (OcrBlock block in page.Blocks.Take(8))
                {
                    string preview = block.Content ?? string.Empty;
                    if (preview.Length > 80)
                    {
                        preview = preview[..80];
                    }

                    Console.WriteLine($"  [{block.Type}] {preview}");
                }
            }
        }
    }

    [TornadoTest]
    public static async Task OcrZaiGlm()
    {
        OcrResult? result = await Program.ConnectMulti().Ocr.Process(new OcrRequest(
            OcrModel.Zai.GlmOcr,
            OcrDocumentInput.FromImageUrl("https://cdn.bigmodel.cn/static/logo/introduction.png")));

        Console.WriteLine($"Pages: {result?.Pages?.Count ?? 0}");
        Console.WriteLine($"Model: {result?.Model}");
        Console.WriteLine(result?.DocumentAnnotation ?? result?.Pages?.FirstOrDefault()?.Markdown);
    }
}
