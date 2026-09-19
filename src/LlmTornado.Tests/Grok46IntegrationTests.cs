using LlmTornado.Audio.Models;
using LlmTornado.Chat;
using LlmTornado.Chat.Models;
using LlmTornado.Images.Models;
using LlmTornado.Responses;
using LlmTornado.Videos.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LlmTornado.Tests;

/// <summary>
/// Registration and capability tests for xAI models added after the July 9, 2026 (GPT-5.6 / Grok 4.5) sync.
/// </summary>
[TestFixture]
public class Grok46IntegrationTests
{
    [Test]
    public void Grok46_ModelRegistration_Works()
    {
        Assert.That(ChatModel.XAi.Grok46.V46.Name, Is.EqualTo("grok-4.6"));
        Assert.That(ChatModel.XAi.Grok46.V46.ContextTokens, Is.EqualTo(500_000));
        Assert.That(ChatModel.XAi.Grok46.V46.Aliases, Does.Contain("grok-4.6-latest"));
        Assert.That(ChatModel.XAi.Grok46.V46.Aliases, Does.Contain("grok-build-latest"));
        Assert.That(ChatModel.XAi.AllModels, Does.Contain(ChatModel.XAi.Grok46.V46));
        Assert.That(ChatModel.XAi.OwnsModel("grok-4.6"), Is.True);
    }

    [Test]
    public void Grok43_ModelRegistration_Works()
    {
        Assert.That(ChatModel.XAi.Grok43.V43.Name, Is.EqualTo("grok-4.3"));
        Assert.That(ChatModel.XAi.Grok43.V43.ContextTokens, Is.EqualTo(1_000_000));
        Assert.That(ChatModel.XAi.Grok43.V43.Aliases, Does.Contain("grok-4.3-latest"));
        Assert.That(ChatModel.XAi.AllModels, Does.Contain(ChatModel.XAi.Grok43.V43));
        Assert.That(ChatModel.XAi.OwnsModel("grok-4.3"), Is.True);
    }

    [Test]
    public void Grok420_ModelRegistration_Works()
    {
        Assert.That(ChatModel.XAi.Grok420.V420Reasoning.Name, Is.EqualTo("grok-4.20-0309-reasoning"));
        Assert.That(ChatModel.XAi.Grok420.V420Reasoning.ContextTokens, Is.EqualTo(1_000_000));
        Assert.That(ChatModel.XAi.Grok420.V420Reasoning.Aliases, Does.Contain("grok-4.20"));
        Assert.That(ChatModel.XAi.Grok420.V420NonReasoning.Name, Is.EqualTo("grok-4.20-0309-non-reasoning"));
        Assert.That(ChatModel.XAi.Grok420.V420MultiAgent.Name, Is.EqualTo("grok-4.20-multi-agent-0309"));
        Assert.That(ChatModel.XAi.OwnsModel("grok-4.20-0309-reasoning"), Is.True);
        Assert.That(ChatModel.XAi.OwnsModel("grok-4.20-0309-non-reasoning"), Is.True);
        Assert.That(ChatModel.XAi.OwnsModel("grok-4.20-multi-agent-0309"), Is.True);
    }

    [Test]
    public void ImagineImage20_AndQuality_AreRegistered()
    {
        Assert.That(ImageModel.XAi.Grok.Imagine20.Name, Is.EqualTo("grok-imagine-image-2.0"));
        Assert.That(ImageModel.XAi.Grok.ImagineQuality.Name, Is.EqualTo("grok-imagine-image-quality"));
        Assert.That(ImageModel.XAi.OwnsModel("grok-imagine-image-2.0"), Is.True);
        Assert.That(ImageModel.XAi.OwnsModel("grok-imagine-image-quality"), Is.True);
        Assert.That(ImageModel.XAi.OwnsModel("grok-imagine-image"), Is.True);
    }

    [Test]
    public void ImagineVideo15_IsRegistered()
    {
        Assert.That(VideoModel.XAi.Grok.ImagineVideo15.Name, Is.EqualTo("grok-imagine-video-1.5"));
        Assert.That(VideoModel.XAi.Grok.ImagineVideo15.Aliases, Does.Contain("grok-imagine-video-1.5-preview"));
        Assert.That(VideoModel.XAi.Grok.ImagineVideo.Name, Is.EqualTo("grok-imagine-video"));
        Assert.That(VideoModel.XAi.OwnsModel("grok-imagine-video-1.5"), Is.True);
    }

    [Test]
    public void VoiceModels_AreRegistered()
    {
        Assert.That(AudioModel.XAi.Voice.ThinkFast20.Name, Is.EqualTo("grok-voice-think-fast-2.0"));
        Assert.That(AudioModel.XAi.Voice.ThinkFast20.Aliases, Does.Contain("grok-voice-latest"));
        Assert.That(AudioModel.XAi.Voice.Transcribe20.Name, Is.EqualTo("grok-voice-transcribe-2.0"));
        Assert.That(AudioModel.XAi.Voice.Transcribe10.Name, Is.EqualTo("grok-voice-transcribe-1.0"));
        Assert.That(AudioModel.XAi.OwnsModel("grok-voice-think-fast-2.0"), Is.True);
        Assert.That(AudioModel.XAi.OwnsModel("grok-voice-transcribe-2.0"), Is.True);
    }

    [Test]
    public void ChatUsage_DeserializesXAiCostTicks()
    {
        const string json = """
            {
              "prompt_tokens": 10,
              "completion_tokens": 5,
              "total_tokens": 15,
              "cost_in_usd_ticks": 20000000
            }
            """;

        ChatResult? result = JsonConvert.DeserializeObject<ChatResult>("{\"usage\":" + json + "}");

        Assert.That(result?.Usage, Is.Not.Null);
        Assert.That(result!.Usage!.CostInUsdTicks, Is.EqualTo(20_000_000));
        Assert.That(result.Usage.CostUsd, Is.EqualTo(0.002m));
    }

    [Test]
    public void WebSearchTool_SerializesXAiImageSearchFlags()
    {
        ResponseWebSearchTool tool = new ResponseWebSearchTool
        {
            WebSearchToolType = ResponseWebSearchToolType.WebSearch,
            EnableImageSearch = true,
            EnableImageUnderstanding = true
        };

        string json = JsonConvert.SerializeObject(tool);
        JObject body = JObject.Parse(json);

        Assert.That(body["type"]?.ToString(), Is.EqualTo("web_search"));
        Assert.That(body["enable_image_search"]?.Value<bool>(), Is.True);
        Assert.That(body["enable_image_understanding"]?.Value<bool>(), Is.True);
    }
}
