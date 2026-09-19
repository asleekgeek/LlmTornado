using LlmTornado.Audio;
using LlmTornado.Chat;
using LlmTornado.Chat.Models;
using LlmTornado.Chat.Vendors.Groq;
using LlmTornado.ChatFunctions;
using LlmTornado.Code;
using LlmTornado.Common;
using Newtonsoft.Json.Linq;

namespace LlmTornado.Tests;

/// <summary>
/// Catalog and serialization coverage for Groq models added after GPT-OSS 20B/120B (Aug 5, 2025).
/// </summary>
[TestFixture]
public class GroqModelSyncTests
{
    private static IEndpointProvider CreateGroqProvider()
    {
        TornadoApi api = new TornadoApi(LLmProviders.Groq, "test-key");
        return api.GetProvider(LLmProviders.Groq);
    }

    [Test]
    public void OpenAi_Catalog_IncludesSafeguardAfterGptOss()
    {
        Assert.That(ChatModel.Groq.OpenAi.GptOss120B.ApiName, Is.EqualTo("openai/gpt-oss-120b"));
        Assert.That(ChatModel.Groq.OpenAi.GptOss20B.ApiName, Is.EqualTo("openai/gpt-oss-20b"));
        Assert.That(ChatModel.Groq.OpenAi.GptOssSafeguard20B.ApiName, Is.EqualTo("openai/gpt-oss-safeguard-20b"));
        Assert.That(ChatModel.Groq.OpenAi.GptOssSafeguard20B.ContextTokens, Is.EqualTo(131_072));
        Assert.That(ChatModel.Groq.OpenAi.GptOss120B.EndpointCapabilities, Does.Contain(ChatModelEndpointCapabilities.Responses));
        Assert.That(ChatModelGroqOpenAi.ModelsAll, Has.Count.EqualTo(3));
        Assert.That(ChatModelGroq.ReasoningModelsAll, Does.Contain(ChatModelGroqOpenAi.ModelGptOssSafeguard20B));
    }

    [Test]
    public void Catalog_IncludesPostGptOssModels()
    {
        Assert.That(ChatModel.Groq.Groq.Compound.ApiName, Is.EqualTo("groq/compound"));
        Assert.That(ChatModel.Groq.Groq.CompoundMini.ApiName, Is.EqualTo("groq/compound-mini"));
        Assert.That(ChatModel.Groq.MoonshotAi.KimiK2Instruct0905.ApiName, Is.EqualTo("moonshotai/kimi-k2-instruct-0905"));
        Assert.That(ChatModel.Groq.MoonshotAi.KimiK2Instruct0905.ContextTokens, Is.EqualTo(262_144));
        Assert.That(ChatModel.Groq.Alibaba.Qwen3627B.ApiName, Is.EqualTo("qwen/qwen3.6-27b"));
        Assert.That(ChatModel.Groq.Alibaba.Qwen3827B.ApiName, Is.EqualTo("qwen/qwen3.8-27b"));
        Assert.That(ChatModel.Groq.Alibaba.Qwen3Vl32BInstruct.ApiName, Is.EqualTo("qwen/qwen3-vl-32b-instruct"));
        Assert.That(ChatModel.Groq.MiniMax.M27.ApiName, Is.EqualTo("minimaxai/minimax-m2.7"));
        Assert.That(ChatModel.Groq.MiniMax.M27.ContextTokens, Is.EqualTo(196_608));
        Assert.That(ChatModel.Groq.Meta.LlamaPromptGuard222M.ApiName, Is.EqualTo("meta-llama/llama-prompt-guard-2-22m"));
        Assert.That(ChatModel.Groq.Meta.LlamaPromptGuard286M.ApiName, Is.EqualTo("meta-llama/llama-prompt-guard-2-86m"));
        Assert.That(ChatModel.Groq.Meta.LlamaGuard412B.ApiName, Is.EqualTo("meta-llama/Llama-Guard-4-12B"));
        Assert.That(ChatModel.Groq.Meta.Llama3370BVersatile.ContextTokens, Is.EqualTo(131_072));
        Assert.That(ChatModel.Groq.OwnsModel("openai/gpt-oss-safeguard-20b"), Is.True);
        Assert.That(ChatModel.Groq.OwnsModel("groq/compound"), Is.True);
        Assert.That(ChatModelGroq.CompoundSystemsAll, Has.Count.EqualTo(4));
        Assert.That(ChatModelGroq.VisionModelsAll, Does.Contain(ChatModelGroqAlibaba.ModelQwen3827B));
    }

    [Test]
    public void IncludeReasoning_SerializesForGroq()
    {
        ChatRequest request = new ChatRequest
        {
            Model = ChatModel.Groq.OpenAi.GptOss120B,
            Messages = [new ChatMessage(ChatMessageRoles.User, "Hello")],
            IncludeReasoning = false,
            ReasoningEffort = ChatReasoningEfforts.High
        };

        TornadoRequestContent serialized = request.Serialize(CreateGroqProvider());
        JObject body = JObject.Parse(serialized.Body.ToString()!);

        Assert.That(body["include_reasoning"]?.Value<bool>(), Is.False);
        Assert.That(body["reasoning_effort"]?.ToString(), Is.EqualTo("high"));
        Assert.That(body["model"]?.ToString(), Is.EqualTo("openai/gpt-oss-120b"));
    }

    [Test]
    public void CompoundExtensions_SerializeSearchSettingsAndTools()
    {
        ChatRequest request = new ChatRequest
        {
            Model = ChatModel.Groq.Groq.Compound,
            Messages = [new ChatMessage(ChatMessageRoles.User, "What happened this week?")],
            VendorExtensions = new ChatRequestVendorExtensions(new ChatRequestVendorGroqExtensions
            {
                SearchSettings = new ChatRequestVendorGroqSearchSettings
                {
                    ExcludeDomains = ["wikipedia.org"],
                    IncludeImages = true,
                    Country = "US"
                },
                CompoundCustom = new ChatRequestVendorGroqCompoundCustom
                {
                    Tools = new ChatRequestVendorGroqCompoundTools
                    {
                        EnabledTools =
                        [
                            ChatRequestVendorGroqCompoundToolIds.WebSearch,
                            ChatRequestVendorGroqCompoundToolIds.VisitWebsite
                        ]
                    }
                },
                ModelVersion = "latest"
            })
        };

        TornadoRequestContent serialized = request.Serialize(CreateGroqProvider());
        JObject body = JObject.Parse(serialized.Body.ToString()!);

        Assert.That(body["model"]?.ToString(), Is.EqualTo("groq/compound"));
        Assert.That(body["search_settings"]?["exclude_domains"]?[0]?.ToString(), Is.EqualTo("wikipedia.org"));
        Assert.That(body["search_settings"]?["include_images"]?.Value<bool>(), Is.True);
        Assert.That(body["search_settings"]?["country"]?.ToString(), Is.EqualTo("US"));
        Assert.That(body["compound_custom"]?["tools"]?["enabled_tools"]?[0]?.ToString(), Is.EqualTo("web_search"));
        Assert.That(body["compound_custom"]?["tools"]?["enabled_tools"]?[1]?.ToString(), Is.EqualTo("visit_website"));
    }

    [Test]
    public void ResponsesEndpoint_IsSelectedWhenRequested()
    {
        ChatRequest request = new ChatRequest
        {
            Model = ChatModel.Groq.OpenAi.GptOss20B,
            Messages = [new ChatMessage(ChatMessageRoles.User, "Hello")],
            UseResponseEndpoint = true
        };

        Assert.That(request.GetCapabilityEndpoint(), Is.EqualTo(CapabilityEndpoints.Responses));
    }

    [Test]
    public void HostedGroqTools_HaveExpectedTypes()
    {
        Assert.That(Tool.GroqBrowserSearch.Type, Is.EqualTo("browser_search"));
        Assert.That(Tool.GroqCodeInterpreter.Type, Is.EqualTo("code_interpreter"));
        Assert.That(HostedToolTypes.BrowserSearch.ToString(), Is.EqualTo("BrowserSearch"));
    }

    [Test]
    public void ExecutedToolsAndUsageBreakdown_Deserialize()
    {
        const string json = """
        {
          "id": "chatcmpl-test",
          "choices": [
            {
              "index": 0,
              "message": {
                "role": "assistant",
                "content": "Tokyo is currently 18C.",
                "executed_tools": [
                  {
                    "index": 0,
                    "type": "search",
                    "arguments": "{\"query\":\"Tokyo weather\"}",
                    "output": "18C sunny"
                  }
                ]
              },
              "finish_reason": "stop"
            }
          ],
          "usage": { "prompt_tokens": 10, "completion_tokens": 8, "total_tokens": 18 },
          "usage_breakdown": {
            "models": [
              {
                "model": "openai/gpt-oss-120b",
                "usage": { "prompt_tokens": 10, "completion_tokens": 8, "total_tokens": 18 }
              }
            ]
          }
        }
        """;

        ChatResult? result = ChatResult.Deserialize(LLmProviders.Groq, json, null, null);

        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Choices![0].Message!.ExecutedTools, Has.Count.EqualTo(1));
        Assert.That(result.Choices[0].Message!.ExecutedTools![0].Type, Is.EqualTo("search"));
        Assert.That(result.UsageBreakdown, Is.Not.Null);
        Assert.That(result.UsageBreakdown!.Models![0].Model, Is.EqualTo("openai/gpt-oss-120b"));
        Assert.That(result.VendorExtensions?.Groq?.UsageBreakdown?.Models?[0].Model, Is.EqualTo("openai/gpt-oss-120b"));
    }

    [Test]
    public void OrpheusArabicVoices_AreRegistered()
    {
        Assert.That((string)SpeechVoice.AbdullahOrpheus, Is.EqualTo("abdullah"));
        Assert.That((string)SpeechVoice.AishaOrpheus, Is.EqualTo("aisha"));
        Assert.That((string)SpeechVoice.FahadOrpheus, Is.EqualTo("fahad"));
    }
}
