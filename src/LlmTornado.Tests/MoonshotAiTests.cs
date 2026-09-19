using LlmTornado.Chat;
using LlmTornado.Chat.Models;
using LlmTornado.Chat.Models.MoonshotAi;
using LlmTornado.Chat.Vendors.MoonshotAi;
using LlmTornado.ChatFunctions;
using LlmTornado.Code;
using LlmTornado.Common;
using Newtonsoft.Json.Linq;

namespace LlmTornado.Tests;

[TestFixture]
public class MoonshotAiTests
{
    private TornadoApi api = null!;
    private IEndpointProvider provider = null!;

    [SetUp]
    public void Setup()
    {
        api = new TornadoApi("test-key");
        provider = api.GetProvider(LLmProviders.MoonshotAi);
    }

    [Test]
    public void ModelRegistration_IncludesCurrentAndLegacyModels()
    {
        Assert.That(ChatModel.MoonshotAi.Models.KimiK3.Name, Is.EqualTo("kimi-k3"));
        Assert.That(ChatModel.MoonshotAi.Models.KimiK3.ContextTokens, Is.EqualTo(1_048_576));
        Assert.That(ChatModel.MoonshotAi.Models.KimiK27Code.Name, Is.EqualTo("kimi-k2.7-code"));
        Assert.That(ChatModel.MoonshotAi.Models.KimiK27CodeHighspeed.Name, Is.EqualTo("kimi-k2.7-code-highspeed"));
        Assert.That(ChatModel.MoonshotAi.Models.KimiK26.Name, Is.EqualTo("kimi-k2.6"));
        Assert.That(ChatModel.MoonshotAi.Models.KimiK26.ContextTokens, Is.EqualTo(262_144));
        Assert.That(ChatModel.MoonshotAi.Models.KimiK25.Name, Is.EqualTo("kimi-k2.5"));
        Assert.That(ChatModel.MoonshotAi.OwnsModel("kimi-k3"), Is.True);
        Assert.That(ChatModel.MoonshotAi.OwnsModel("kimi-k2.7-code-highspeed"), Is.True);
        Assert.That(ChatModelMoonshotAiModels.ModelsAll, Has.Count.EqualTo(22));
    }

    [Test]
    public void CurrentModels_DeclareChatResponsesAndBatch()
    {
        foreach (ChatModel model in new[]
                 {
                     ChatModel.MoonshotAi.Models.KimiK3,
                     ChatModel.MoonshotAi.Models.KimiK27Code,
                     ChatModel.MoonshotAi.Models.KimiK27CodeHighspeed,
                     ChatModel.MoonshotAi.Models.KimiK26
                 })
        {
            Assert.That(model.EndpointCapabilities, Does.Contain(ChatModelEndpointCapabilities.Chat));
            Assert.That(model.EndpointCapabilities, Does.Contain(ChatModelEndpointCapabilities.Responses));
            Assert.That(model.EndpointCapabilities, Does.Contain(ChatModelEndpointCapabilities.Batch));
        }
    }

    [Test]
    public void K3_MapsReasoningEffortAndClearsFixedSampling()
    {
        ChatRequest request = new ChatRequest
        {
            Model = ChatModel.MoonshotAi.Models.KimiK3,
            Messages = [new ChatMessage(ChatMessageRoles.User, "Hello")],
            Temperature = 0.7,
            TopP = 0.9,
            NumChoicesPerMessage = 2,
            PresencePenalty = 0.5,
            FrequencyPenalty = 0.5,
            ReasoningEffort = ChatReasoningEfforts.Medium
        };

        TornadoRequestContent serialized = request.Serialize(provider);
        JObject body = JObject.Parse(serialized.Body.ToString()!);

        Assert.That(body["model"]?.ToString(), Is.EqualTo("kimi-k3"));
        Assert.That(body["temperature"], Is.Null);
        Assert.That(body["top_p"], Is.Null);
        Assert.That(body["n"], Is.Null);
        Assert.That(body["presence_penalty"], Is.Null);
        Assert.That(body["frequency_penalty"], Is.Null);
        Assert.That(body["thinking"], Is.Null);
        Assert.That(body["reasoning_effort"]?.ToString(), Is.EqualTo("high"));
    }

    [TestCase(ChatReasoningEfforts.None, "low")]
    [TestCase(ChatReasoningEfforts.Minimal, "low")]
    [TestCase(ChatReasoningEfforts.Low, "low")]
    [TestCase(ChatReasoningEfforts.High, "high")]
    [TestCase(ChatReasoningEfforts.XHigh, "max")]
    [TestCase(ChatReasoningEfforts.Max, "max")]
    public void K3_ReasoningEffortMapping(ChatReasoningEfforts effort, string expected)
    {
        ChatReasoningEfforts? mapped = VendorMoonshotAiChatRequest.MapK3ReasoningEffort(effort);
        Assert.That(mapped, Is.Not.Null);
        Assert.That(mapped!.ToString(), Is.EqualTo(expected).IgnoreCase);
    }

    [Test]
    public void K3_OmitsDefaultReasoningEffort()
    {
        ChatRequest request = new ChatRequest
        {
            Model = ChatModel.MoonshotAi.Models.KimiK3,
            Messages = [new ChatMessage(ChatMessageRoles.User, "Hello")]
        };

        TornadoRequestContent serialized = request.Serialize(provider);
        JObject body = JObject.Parse(serialized.Body.ToString()!);

        Assert.That(body["reasoning_effort"], Is.Null);
    }

    [Test]
    public void K3_KeepsRequiredToolChoice()
    {
        ChatRequest request = new ChatRequest
        {
            Model = ChatModel.MoonshotAi.Models.KimiK3,
            Messages = [new ChatMessage(ChatMessageRoles.User, "Hello")],
            Tools = [new Tool(new ToolFunction("get_weather", "Get weather", new { type = "object" }))],
            ToolChoice = OutboundToolChoice.Required
        };

        TornadoRequestContent serialized = request.Serialize(provider);
        JObject body = JObject.Parse(serialized.Body.ToString()!);

        Assert.That(body["tool_choice"]?.ToString(), Is.EqualTo("required"));
    }

    [Test]
    public void K26_SendsThinkingEnabledWithKeepAll()
    {
        ChatRequest request = new ChatRequest
        {
            Model = ChatModel.MoonshotAi.Models.KimiK26,
            Messages = [new ChatMessage(ChatMessageRoles.User, "Hello")],
            Temperature = 0.4,
            ReasoningEffort = ChatReasoningEfforts.High
        };

        TornadoRequestContent serialized = request.Serialize(provider);
        JObject body = JObject.Parse(serialized.Body.ToString()!);

        Assert.That(body["temperature"], Is.Null);
        Assert.That(body["reasoning_effort"], Is.Null);
        Assert.That(body["thinking"]?["type"]?.ToString(), Is.EqualTo("enabled"));
        Assert.That(body["thinking"]?["keep"]?.ToString(), Is.EqualTo("all"));
    }

    [Test]
    public void K26_DisablesThinkingWhenBudgetIsZero()
    {
        ChatRequest request = new ChatRequest
        {
            Model = ChatModel.MoonshotAi.Models.KimiK26,
            Messages = [new ChatMessage(ChatMessageRoles.User, "Hello")],
            ReasoningBudget = 0
        };

        TornadoRequestContent serialized = request.Serialize(provider);
        JObject body = JObject.Parse(serialized.Body.ToString()!);

        Assert.That(body["thinking"]?["type"]?.ToString(), Is.EqualTo("disabled"));
        Assert.That(body["thinking"]?["keep"], Is.Null);
    }

    [Test]
    public void K25_SendsThinkingWithoutKeep()
    {
        ChatRequest request = new ChatRequest
        {
            Model = ChatModel.MoonshotAi.Models.KimiK25,
            Messages = [new ChatMessage(ChatMessageRoles.User, "Hello")]
        };

        TornadoRequestContent serialized = request.Serialize(provider);
        JObject body = JObject.Parse(serialized.Body.ToString()!);

        Assert.That(body["thinking"]?["type"]?.ToString(), Is.EqualTo("enabled"));
        Assert.That(body["thinking"]?["keep"], Is.Null);
        Assert.That(body["reasoning_effort"], Is.Null);
    }

    [Test]
    public void K27_OmitsThinkingAndReasoningEffort()
    {
        ChatRequest request = new ChatRequest
        {
            Model = ChatModel.MoonshotAi.Models.KimiK27Code,
            Messages = [new ChatMessage(ChatMessageRoles.User, "Hello")],
            Temperature = 0.2,
            ReasoningEffort = ChatReasoningEfforts.High
        };

        TornadoRequestContent serialized = request.Serialize(provider);
        JObject body = JObject.Parse(serialized.Body.ToString()!);

        Assert.That(body["temperature"], Is.Null);
        Assert.That(body["thinking"], Is.Null);
        Assert.That(body["reasoning_effort"], Is.Null);
    }

    [Test]
    public void K26_RemapsRequiredToolChoiceToAuto()
    {
        ChatRequest request = new ChatRequest
        {
            Model = ChatModel.MoonshotAi.Models.KimiK26,
            Messages = [new ChatMessage(ChatMessageRoles.User, "Hello")],
            Tools = [new Tool(new ToolFunction("get_weather", "Get weather", new { type = "object" }))],
            ToolChoice = OutboundToolChoice.Required
        };

        TornadoRequestContent serialized = request.Serialize(provider);
        JObject body = JObject.Parse(serialized.Body.ToString()!);

        Assert.That(body["tool_choice"]?.ToString(), Is.EqualTo("auto"));
    }

    [Test]
    public void K3_PreservesReasoningContentAndPartial()
    {
        ChatMessage assistant = new ChatMessage(ChatMessageRoles.Assistant, "Conclusion: ")
        {
            ReasoningContent = "step by step",
            Partial = true
        };

        ChatRequest request = new ChatRequest
        {
            Model = ChatModel.MoonshotAi.Models.KimiK3,
            Messages =
            [
                new ChatMessage(ChatMessageRoles.User, "Explain compatibility."),
                assistant
            ]
        };

        TornadoRequestContent serialized = request.Serialize(provider);
        JObject body = JObject.Parse(serialized.Body.ToString()!);
        JToken? lastMessage = body["messages"]?.Last;

        Assert.That(lastMessage?["reasoning_content"]?.ToString(), Is.EqualTo("step by step"));
        Assert.That(lastMessage?["partial"]?.Value<bool>(), Is.True);
    }
}
