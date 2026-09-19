using LlmTornado.Audio.Models;
using LlmTornado.Chat;
using LlmTornado.Chat.Models;
using LlmTornado.Chat.Vendors.Cohere;
using LlmTornado.Code;
using LlmTornado.Ocr;
using LlmTornado.Ocr.Models;
using LlmTornado.Rerank;
using LlmTornado.Rerank.Models;
using Newtonsoft.Json.Linq;

namespace LlmTornado.Tests;

/// <summary>
/// Registration and serialization tests for the Cohere 2025–2026 model lineup.
/// </summary>
[TestFixture]
public class CohereModelsTests
{
    private IEndpointProvider _provider = null!;

    [SetUp]
    public void Setup()
    {
        TornadoApi api = new TornadoApi("test-key", LLmProviders.Cohere);
        _provider = api.GetProvider(LLmProviders.Cohere);
    }

    [Test]
    public void CommandAPlus_AndNorth_AndTinyAya_AreRegistered()
    {
        Assert.That(ChatModel.Cohere.Command.APlus.Name, Is.EqualTo("command-a-plus-05-2026"));
        Assert.That(ChatModel.Cohere.Command.APlus2605.ContextTokens, Is.EqualTo(128_000));
        Assert.That(ChatModel.Cohere.North.MiniCode.Name, Is.EqualTo("north-mini-code-1-0"));
        Assert.That(ChatModel.Cohere.North.MiniCode.ContextTokens, Is.EqualTo(256_000));
        Assert.That(ChatModel.Cohere.North.SmallTranslate.Name, Is.EqualTo("north-small-translate-1-0"));
        Assert.That(ChatModel.Cohere.North.SmallTranslate.ContextTokens, Is.EqualTo(16_000));
        Assert.That(ChatModel.Cohere.Aya.TinyGlobal.Name, Is.EqualTo("tiny-aya-global"));
        Assert.That(ChatModel.Cohere.Aya.TinyEarth.Name, Is.EqualTo("tiny-aya-earth"));
        Assert.That(ChatModel.Cohere.Aya.TinyFire.Name, Is.EqualTo("tiny-aya-fire"));
        Assert.That(ChatModel.Cohere.Aya.TinyWater.Name, Is.EqualTo("tiny-aya-water"));
        Assert.That(ChatModel.Cohere.OwnsModel("command-a-plus-05-2026"), Is.True);
        Assert.That(ChatModel.Cohere.OwnsModel("north-mini-code-1-0"), Is.True);
        Assert.That(ChatModel.Cohere.OwnsModel("tiny-aya-global"), Is.True);
        Assert.That(ChatModelCohere.ReasoningModels, Does.Contain(ChatModel.Cohere.Command.APlus));
        Assert.That(ChatModelCohere.ReasoningModels, Does.Contain(ChatModel.Cohere.Command.AReasoning2508));
    }

    [Test]
    public void CommandR082024_HasCorrectContextWindow()
    {
        Assert.That(ChatModel.Cohere.Command.Default2408.ContextTokens, Is.EqualTo(128_000));
    }

    [Test]
    public void Thinking_Disabled_SerializesForReasoningModels()
    {
        ChatRequest request = new ChatRequest
        {
            Model = ChatModel.Cohere.Command.APlus,
            Messages = [new ChatMessage(ChatMessageRoles.User, "Hello")],
            ReasoningEffort = ChatReasoningEfforts.None
        };

        TornadoRequestContent serialized = request.Serialize(_provider);
        JObject body = JObject.Parse(serialized.Body.ToString()!);

        Assert.That(body["thinking"]?["type"]?.ToString(), Is.EqualTo("disabled"));
    }

    [Test]
    public void Thinking_Budget_SerializesForReasoningModels()
    {
        ChatRequest request = new ChatRequest
        {
            Model = ChatModel.Cohere.Command.AReasoning2508,
            Messages = [new ChatMessage(ChatMessageRoles.User, "Hello")],
            ReasoningBudget = 500
        };

        TornadoRequestContent serialized = request.Serialize(_provider);
        JObject body = JObject.Parse(serialized.Body.ToString()!);

        Assert.That(body["thinking"]?["token_budget"]?.Value<int>(), Is.EqualTo(500));
    }

    [Test]
    public void Thinking_VendorExtension_OverridesReasoningBudget()
    {
        ChatRequest request = new ChatRequest
        {
            Model = ChatModel.Cohere.Command.APlus,
            Messages = [new ChatMessage(ChatMessageRoles.User, "Hello")],
            ReasoningBudget = 500,
            VendorExtensions = new ChatRequestVendorExtensions(new ChatRequestVendorCohereExtensions
            {
                Thinking = new ChatRequestVendorCohereThinking
                {
                    Type = ChatVendorCohereThinkingType.Disabled
                }
            })
        };

        TornadoRequestContent serialized = request.Serialize(_provider);
        JObject body = JObject.Parse(serialized.Body.ToString()!);

        Assert.That(body["thinking"]?["type"]?.ToString(), Is.EqualTo("disabled"));
        Assert.That(body["thinking"]?["token_budget"], Is.Null);
    }

    [Test]
    public void Thinking_NotSent_ForNonReasoningModels()
    {
        ChatRequest request = new ChatRequest
        {
            Model = ChatModel.Cohere.Command.A0325,
            Messages = [new ChatMessage(ChatMessageRoles.User, "Hello")],
            ReasoningEffort = ChatReasoningEfforts.High
        };

        TornadoRequestContent serialized = request.Serialize(_provider);
        JObject body = JObject.Parse(serialized.Body.ToString()!);

        Assert.That(body["thinking"], Is.Null);
    }

    [Test]
    public void Rerank_Models_AreRegistered()
    {
        Assert.That(RerankModel.Cohere.Gen4.Pro.Name, Is.EqualTo("rerank-v4.0-pro"));
        Assert.That(RerankModel.Cohere.Gen4.Fast.Name, Is.EqualTo("rerank-v4.0-fast"));
        Assert.That(RerankModel.Cohere.Gen3.V35.Name, Is.EqualTo("rerank-v3.5"));
        Assert.That(RerankModel.Cohere.Gen3.English.Name, Is.EqualTo("rerank-english-v3.0"));
        Assert.That(RerankModel.Cohere.Gen3.Multilingual.Name, Is.EqualTo("rerank-multilingual-v3.0"));
        Assert.That(RerankModel.GetProvider("rerank-v4.0-pro"), Is.EqualTo(LLmProviders.Cohere));
    }

    [Test]
    public void Rerank_SerializesTopN_ForCohere()
    {
        RerankRequest request = new RerankRequest(RerankModel.Cohere.Gen4.Pro, "capital", ["Washington, D.C.", "Carson City"])
        {
            TopK = 3
        };

        TornadoRequestContent serialized = request.Serialize(_provider);
        JObject body = JObject.Parse(serialized.Body.ToString()!);

        Assert.That(body["model"]?.ToString(), Is.EqualTo("rerank-v4.0-pro"));
        Assert.That(body["top_n"]?.Value<int>(), Is.EqualTo(3));
        Assert.That(body["top_k"], Is.Null);
        Assert.That(serialized.Url, Does.Contain("/v2/rerank"));
    }

    [Test]
    public void Transcribe_AndParse_Models_AreRegistered()
    {
        Assert.That(AudioModel.Cohere.Transcribe.V0326.Name, Is.EqualTo("cohere-transcribe-03-2026"));
        Assert.That(AudioModel.Cohere.Transcribe.Arabic0726.Name, Is.EqualTo("cohere-transcribe-arabic-07-2026"));
        Assert.That(OcrModel.Cohere.ParseV5.Name, Is.EqualTo("parse-v5.0"));
        Assert.That(AudioModel.GetProvider("cohere-transcribe-03-2026"), Is.EqualTo(LLmProviders.Cohere));
    }

    [Test]
    public void Parse_SerializesImageUrlDocument()
    {
        OcrRequest request = new OcrRequest(OcrModel.Cohere.ParseV5, OcrDocumentInput.FromImageUrl("https://example.com/doc.png"));

        TornadoRequestContent serialized = request.Serialize(_provider);
        JObject body = JObject.Parse(serialized.Body.ToString()!);

        Assert.That(body["model"]?.ToString(), Is.EqualTo("parse-v5.0"));
        Assert.That(body["document"]?["type"]?.ToString(), Is.EqualTo("image_url"));
        Assert.That(body["document"]?["image_url"]?.ToString(), Is.EqualTo("https://example.com/doc.png"));
        Assert.That(body["output_format"]?.ToString(), Is.EqualTo("markdown"));
        Assert.That(serialized.Url, Does.Contain("/v2/parse"));
    }
}
