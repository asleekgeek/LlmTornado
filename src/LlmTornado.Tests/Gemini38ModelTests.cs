using LlmTornado.Audio.Models;
using LlmTornado.Chat;
using LlmTornado.Chat.Models;
using LlmTornado.Chat.Vendors.Google;
using LlmTornado.Code;
using LlmTornado.Images.Models;
using LlmTornado.Interactions;
using LlmTornado.Videos.Models;
using Newtonsoft.Json.Linq;

namespace LlmTornado.Tests;

/// <summary>
/// Registration and serialization tests for Gemini models added after the May 2026 catalog sync.
/// </summary>
[TestFixture]
public class Gemini38ModelTests
{
    private TornadoApi _api = null!;
    private IEndpointProvider _provider = null!;

    [SetUp]
    public void Setup()
    {
        _api = new TornadoApi(LLmProviders.Google, "test");
        _provider = _api.GetProvider(LLmProviders.Google);
    }

    [Test]
    public void NewFlashModels_AreRegistered()
    {
        Assert.That(ChatModel.Google.OwnsModel("gemini-3.8-flash"), Is.True);
        Assert.That(ChatModel.Google.OwnsModel("gemini-3.7-flash"), Is.True);
        Assert.That(ChatModel.Google.OwnsModel("gemini-3.6-flash"), Is.True);
        Assert.That(ChatModel.Google.OwnsModel("gemini-3.5-flash-lite"), Is.True);
        Assert.That(ChatModel.Google.Gemini.Gemini38Flash.Name, Is.EqualTo("gemini-3.8-flash"));
        Assert.That(ChatModel.Google.Gemini.Gemini38Flash.ContextTokens, Is.EqualTo(1_048_576));
        Assert.That(ChatModel.Google.Gemini.Gemini35FlashLite.Name, Is.EqualTo("gemini-3.5-flash-lite"));
    }

    [Test]
    public void NewSpecializedModels_AreRegistered()
    {
        Assert.That(ChatModel.Google.OwnsModel("gemini-3.8-live"), Is.True);
        Assert.That(ChatModel.Google.OwnsModel("gemini-3.8-live-extended-thinking"), Is.True);
        Assert.That(ChatModel.Google.OwnsModel("gemini-3.5-transcribe"), Is.True);
        Assert.That(ChatModel.Google.OwnsModel("gemini-3.5-transcribe-live"), Is.True);
        Assert.That(ChatModel.Google.OwnsModel("gemini-3.5-live-translate-preview"), Is.True);
        Assert.That(ChatModel.Google.OwnsModel("gemini-3.1-flash-lite-image"), Is.True);
        Assert.That(ChatModel.Google.OwnsModel("gemini-robotics-er-2-preview"), Is.True);
        Assert.That(ChatModel.Google.OwnsModel("gemini-robotics-er-2-streaming-preview"), Is.True);
        Assert.That(AudioModel.Google.OwnsModel("lyria-3.5"), Is.True);
        Assert.That(AudioModel.Google.OwnsModel("gemini-3.5-transcribe"), Is.True);
        Assert.That(ImageModel.Google.OwnsModel("gemini-3.1-flash-lite-image"), Is.True);
        Assert.That(VideoModel.Google.OwnsModel("gemini-omni-1.1-flash"), Is.True);
    }

    [Test]
    public void CapabilitySets_IncludeNewFlashModels()
    {
        Assert.That(ChatModelGoogle.ReasoningModels, Does.Contain(ChatModel.Google.Gemini.Gemini38Flash));
        Assert.That(ChatModelGoogle.ReasoningModels, Does.Contain(ChatModel.Google.Gemini.Gemini37Flash));
        Assert.That(ChatModelGoogle.ReasoningModels, Does.Contain(ChatModel.Google.Gemini.Gemini36Flash));
        Assert.That(ChatModelGoogle.ReasoningModels, Does.Contain(ChatModel.Google.Gemini.Gemini35FlashLite));
        Assert.That(ChatModelGoogle.Gemini36PlusFlashModels, Does.Contain(ChatModel.Google.Gemini.Gemini38Flash));
        Assert.That(ChatModelGoogle.Gemini35FlashLiteModels, Does.Contain(ChatModel.Google.Gemini.Gemini35FlashLite));
        Assert.That(ChatModelGoogle.AgenticVideoModels, Does.Contain(ChatModel.Google.Gemini.Gemini38Flash));
        Assert.That(ChatModelGoogle.AgenticVideoModels, Does.Contain(ChatModel.Google.Gemini.Gemini35FlashLite));
        Assert.That(ChatModelGoogle.ComputerUseModels, Does.Contain(ChatModel.Google.Gemini.Gemini38Flash));
        Assert.That(ChatModelGoogle.ComputerUseModels, Does.Contain(ChatModel.Google.Gemini.Gemini35Flash));
        Assert.That(ChatModelGoogle.IsGemini3Family(ChatModel.Google.Gemini.Gemini38Flash), Is.True);
        Assert.That(ChatModelGoogle.IsGemini3Family(ChatModel.Google.Gemini.Gemini25Flash), Is.False);
    }

    [Test]
    public void Gemini38Flash_ThinkingLevel_MapsMinimalToLow()
    {
        ChatRequest request = new ChatRequest
        {
            Model = ChatModel.Google.Gemini.Gemini38Flash,
            Messages = [new ChatMessage(ChatMessageRoles.User, "Hello")],
            ReasoningEffort = ChatReasoningEfforts.Minimal
        };

        TornadoRequestContent serialized = request.Serialize(_provider);
        JObject body = JObject.Parse(serialized.Body.ToString()!);

        Assert.That(body["generationConfig"]?["thinkingConfig"]?["thinkingLevel"]?.ToString(), Is.EqualTo("low"));
    }

    [Test]
    public void Gemini38Flash_ThinkingLevel_DefaultsToMedium()
    {
        ChatRequest request = new ChatRequest
        {
            Model = ChatModel.Google.Gemini.Gemini38Flash,
            Messages = [new ChatMessage(ChatMessageRoles.User, "Hello")],
            ReasoningEffort = ChatReasoningEfforts.Default
        };

        TornadoRequestContent serialized = request.Serialize(_provider);
        JObject body = JObject.Parse(serialized.Body.ToString()!);

        Assert.That(body["generationConfig"]?["thinkingConfig"]?["thinkingLevel"]?.ToString(), Is.EqualTo("medium"));
    }

    [Test]
    public void Gemini35FlashLite_ThinkingLevel_DefaultsToMinimal()
    {
        ChatRequest request = new ChatRequest
        {
            Model = ChatModel.Google.Gemini.Gemini35FlashLite,
            Messages = [new ChatMessage(ChatMessageRoles.User, "Hello")],
            ReasoningEffort = ChatReasoningEfforts.Default
        };

        TornadoRequestContent serialized = request.Serialize(_provider);
        JObject body = JObject.Parse(serialized.Body.ToString()!);

        Assert.That(body["generationConfig"]?["thinkingConfig"]?["thinkingLevel"]?.ToString(), Is.EqualTo("minimal"));
    }

    [Test]
    public void FileLink_SerializesAgenticVideoProcessing()
    {
        ChatMessagePartFileLinkData file = new ChatMessagePartFileLinkData("https://example.com/video.mp4", "video/mp4")
        {
            VideoProcessing = ChatVideoProcessingMode.Agentic
        };

        ChatRequest request = new ChatRequest
        {
            Model = ChatModel.Google.Gemini.Gemini38Flash,
            Messages =
            [
                new ChatMessage(ChatMessageRoles.User, [
                    new ChatMessagePart("What happens in this video?"),
                    new ChatMessagePart(file)
                ])
            ]
        };

        TornadoRequestContent serialized = request.Serialize(_provider);
        JObject body = JObject.Parse(serialized.Body.ToString()!);
        JToken? part = body["contents"]?[0]?["parts"]?[1];

        Assert.That(part?["fileData"]?["fileUri"]?.ToString(), Is.EqualTo("https://example.com/video.mp4"));
        Assert.That(part?["videoMetadata"]?["processing"]?.ToString(), Is.EqualTo("agentic"));
    }

    [Test]
    public void ComputerUse_SerializesMobileAndPromptInjection()
    {
        ChatRequest request = new ChatRequest
        {
            Model = ChatModel.Google.Gemini.Gemini38Flash,
            Messages = [new ChatMessage(ChatMessageRoles.User, "Open Settings")],
            VendorExtensions = new ChatRequestVendorExtensions
            {
                Google = new ChatRequestVendorGoogleExtensions
                {
                    ComputerUse = new ChatRequestVendorGoogleComputerUse(ChatRequestVendorGoogleComputerUseEnvironment.Mobile)
                    {
                        EnablePromptInjectionDetection = true
                    }
                }
            }
        };

        TornadoRequestContent serialized = request.Serialize(_provider);
        JObject body = JObject.Parse(serialized.Body.ToString()!);
        JToken? computerUse = body["tools"]?[0]?["computerUse"];

        Assert.That(computerUse?["environment"]?.ToString(), Is.EqualTo("ENVIRONMENT_MOBILE"));
        Assert.That(computerUse?["enablePromptInjectionDetection"]?.Value<bool>(), Is.True);
    }

    [Test]
    public void Antigravity_DefaultsToSeptember2026Agent()
    {
        Assert.That(GoogleManagedAgentIds.AntigravityPreview092026, Is.EqualTo("antigravity-preview-09-2026"));
        InteractionCreateRequest request = InteractionCreateRequest.ForAntigravity("audit this site");
        Assert.That(request.Agent, Is.EqualTo(GoogleManagedAgentIds.AntigravityPreview092026));
    }
}
