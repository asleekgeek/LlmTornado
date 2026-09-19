using LlmTornado.Code;
using LlmTornado.Images;
using LlmTornado.Images.Models;
using LlmTornado.Ocr;
using LlmTornado.Ocr.Models;

namespace LlmTornado.Tests;

[TestFixture]
public class ZaiCapabilityTests
{
    [Test]
    public void ImageModels_AreRegistered()
    {
        Assert.That(ImageModel.Zai.Glm.Image.Name, Is.EqualTo("glm-image"));
        Assert.That(ImageModel.Zai.Glm.CogView4.Name, Is.EqualTo("cogview-4-250304"));
        Assert.That(ImageModel.Zai.OwnsModel("glm-image"), Is.True);
        Assert.That(ImageModel.Zai.OwnsModel("cogview-4-250304"), Is.True);
    }

    [Test]
    public void ImageGeneration_SerializesUserIdAndSize()
    {
        var api = new TornadoApi("test-key");
        var request = new ImageGenerationRequest
        {
            Prompt = "A cute little kitten sitting on a sunny windowsill",
            Model = ImageModel.Zai.Glm.Image,
            Quality = TornadoImageQualities.Hd,
            Size = TornadoImageSizes.Size1280x1280,
            User = "user-123"
        };

        TornadoRequestContent serialized = request.Serialize(api.GetProvider(LLmProviders.Zai));
        string bodyJson = serialized.Body.ToString()!;

        Assert.That(bodyJson, Does.Contain("\"model\":\"glm-image\""));
        Assert.That(bodyJson, Does.Contain("\"quality\":\"hd\""));
        Assert.That(bodyJson, Does.Contain("\"size\":\"1280x1280\""));
        Assert.That(bodyJson, Does.Contain("\"user_id\":\"user-123\""));
        Assert.That(bodyJson, Does.Not.Contain("\"user\":"));
        Assert.That(serialized.BuildFinalUrl(), Does.Contain("images/generations"));
    }

    [Test]
    public void OcrModel_IsRegistered()
    {
        Assert.That(OcrModel.Zai.GlmOcr.Name, Is.EqualTo("glm-ocr"));
        Assert.That(OcrModel.Zai.OwnsModel("glm-ocr"), Is.True);
        Assert.That(OcrModel.AllModelsMap.Contains("glm-ocr"), Is.True);
    }

    [Test]
    public void OcrRequest_SerializesLayoutParsingPayload()
    {
        var api = new TornadoApi("test-key");
        var request = new OcrRequest(
            OcrModel.Zai.GlmOcr,
            OcrDocumentInput.FromImageUrl("https://cdn.bigmodel.cn/static/logo/introduction.png"))
        {
            IncludeImageBase64 = true,
            Pages = [0, 2]
        };

        TornadoRequestContent serialized = request.Serialize(api.GetProvider(LLmProviders.Zai));
        string bodyJson = serialized.Body.ToString()!;

        Assert.That(bodyJson, Does.Contain("\"model\":\"glm-ocr\""));
        Assert.That(bodyJson, Does.Contain("\"file\":\"https://cdn.bigmodel.cn/static/logo/introduction.png\""));
        Assert.That(bodyJson, Does.Contain("\"return_crop_images\":true"));
        Assert.That(bodyJson, Does.Contain("\"start_page_id\":1"));
        Assert.That(bodyJson, Does.Contain("\"end_page_id\":3"));
        Assert.That(serialized.BuildFinalUrl(), Does.Contain("layout_parsing"));
    }
}
