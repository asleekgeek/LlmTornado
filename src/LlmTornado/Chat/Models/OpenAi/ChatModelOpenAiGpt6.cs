using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models;

/// <summary>
/// GPT-6 class models from OpenAI.
/// </summary>
public class ChatModelOpenAiGpt6 : IVendorModelClassProvider
{
    /// <summary>
    /// GPT-6 Astra is OpenAI's most capable model, built for the hardest end-to-end work.
    /// Released September 8, 2026. 1.05M context window, 128k max output.
    /// Supports reasoning.effort: low, medium, high, xhigh, and max. Does not support none.
    /// Does not support custom temperature, top_p, or logprobs.
    /// Tool calling requires the Responses API.
    /// </summary>
    public static readonly ChatModel ModelV6Astra = new ChatModel("gpt-6-astra", LLmProviders.OpenAi, 1_050_000)
    {
        EndpointCapabilities = [ ChatModelEndpointCapabilities.Responses, ChatModelEndpointCapabilities.Chat, ChatModelEndpointCapabilities.Batch ]
    };

    /// <summary>
    /// <inheritdoc cref="ModelV6Astra"/>
    /// </summary>
    public readonly ChatModel V6Astra = ModelV6Astra;

    /// <summary>
    /// All known GPT-6 models from OpenAI.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelV6Astra
    ]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;

    internal ChatModelOpenAiGpt6()
    {

    }
}
