using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models;

/// <summary>
/// OpenAI models hosted by Groq.
/// </summary>
public class ChatModelGroqOpenAi : IVendorModelClassProvider
{
    /// <summary>
    /// openai/gpt-oss-120b
    /// OpenAI's flagship open-weight MoE model with reasoning, browser search, and code execution.
    /// 131K context, 65K max output. Supports reasoning_effort: low, medium, high.
    /// </summary>
    public static readonly ChatModel ModelGptOss120B = new ChatModel("grok-openai/gpt-oss-120b", LLmProviders.Groq, 131_072)
    {
        ApiName = "openai/gpt-oss-120b",
        EndpointCapabilities = ChatModelGroq.ChatResponsesBatch
    };
    
    /// <summary>
    /// <inheritdoc cref="ModelGptOss120B"/>
    /// </summary>
    public readonly ChatModel GptOss120B = ModelGptOss120B;
    
    /// <summary>
    /// openai/gpt-oss-20b
    /// OpenAI's smaller open-weight MoE model with reasoning, browser search, and code execution.
    /// 131K context, 65K max output. Supports reasoning_effort: low, medium, high.
    /// </summary>
    public static readonly ChatModel ModelGptOss20B = new ChatModel("grok-openai/gpt-oss-20b", LLmProviders.Groq, 131_072)
    {
        ApiName = "openai/gpt-oss-20b",
        EndpointCapabilities = ChatModelGroq.ChatResponsesBatch
    };
    
    /// <summary>
    /// <inheritdoc cref="ModelGptOss20B"/>
    /// </summary>
    public readonly ChatModel GptOss20B = ModelGptOss20B;
    
    /// <summary>
    /// openai/gpt-oss-safeguard-20b
    /// OpenAI's first open-weight reasoning model trained for safety classification (Oct 29, 2025).
    /// Bring-your-own-policy Trust &amp; Safety. 131K context, 65K max output.
    /// Supports tool use, browser search, code execution, JSON Object/Schema, and reasoning_effort.
    /// </summary>
    public static readonly ChatModel ModelGptOssSafeguard20B = new ChatModel("grok-openai/gpt-oss-safeguard-20b", LLmProviders.Groq, 131_072)
    {
        ApiName = "openai/gpt-oss-safeguard-20b",
        EndpointCapabilities = ChatModelGroq.ChatResponsesBatch
    };
    
    /// <summary>
    /// <inheritdoc cref="ModelGptOssSafeguard20B"/>
    /// </summary>
    public readonly ChatModel GptOssSafeguard20B = ModelGptOssSafeguard20B;
    
    /// <summary>
    /// All known OpenAI models from Groq.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [ModelGptOss120B, ModelGptOss20B, ModelGptOssSafeguard20B]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;

    internal ChatModelGroqOpenAi()
    {

    }
}
