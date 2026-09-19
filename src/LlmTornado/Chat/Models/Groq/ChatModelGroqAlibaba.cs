using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models;

/// <summary>
/// Alibaba models hosted by Groq.
/// </summary>
public class ChatModelGroqAlibaba : IVendorModelClassProvider
{
    /// <summary>
    /// qwen/qwen3-32b
    /// Qwen 3 32B with thinking/non-thinking modes via reasoning_effort. Deprecated Jul 17, 2026.
    /// </summary>
    public static readonly ChatModel ModelQwen332B = new ChatModel("grok-qwen/qwen3-32b", LLmProviders.Groq, 131_072)
    {
        ApiName = "qwen/qwen3-32b",
        EndpointCapabilities = ChatModelGroq.ChatResponsesBatch
    };
    
    /// <summary>
    /// <inheritdoc cref="ModelQwen332B"/>
    /// </summary>
    public readonly ChatModel Qwen332B = ModelQwen332B;
    
    /// <summary>
    /// qwen/qwen3.6-27b
    /// Qwen 3.6 27B dense multimodal model with thinking/instruct modes, tool use, JSON, and vision.
    /// reasoning_effort: none, default, low, medium, high. 131K context, 16K max output.
    /// </summary>
    public static readonly ChatModel ModelQwen3627B = new ChatModel("grok-qwen/qwen3.6-27b", LLmProviders.Groq, 131_072)
    {
        ApiName = "qwen/qwen3.6-27b",
        EndpointCapabilities = ChatModelGroq.ChatResponsesBatch
    };
    
    /// <summary>
    /// <inheritdoc cref="ModelQwen3627B"/>
    /// </summary>
    public readonly ChatModel Qwen3627B = ModelQwen3627B;
    
    /// <summary>
    /// qwen/qwen3.8-27b
    /// Qwen 3.8 27B dense multimodal model with thinking/instruct modes, tool use, JSON, and vision.
    /// reasoning_effort: none, default, low, medium, high. 131K context, 16K max output.
    /// </summary>
    public static readonly ChatModel ModelQwen3827B = new ChatModel("grok-qwen/qwen3.8-27b", LLmProviders.Groq, 131_042)
    {
        ApiName = "qwen/qwen3.8-27b",
        EndpointCapabilities = ChatModelGroq.ChatResponsesBatch
    };
    
    /// <summary>
    /// <inheritdoc cref="ModelQwen3827B"/>
    /// </summary>
    public readonly ChatModel Qwen3827B = ModelQwen3827B;
    
    /// <summary>
    /// qwen/qwen3-vl-32b-instruct
    /// Qwen 3 VL Instruct 32B vision-language model. Enterprise access.
    /// </summary>
    public static readonly ChatModel ModelQwen3Vl32BInstruct = new ChatModel("grok-qwen/qwen3-vl-32b-instruct", LLmProviders.Groq, 131_072)
    {
        ApiName = "qwen/qwen3-vl-32b-instruct",
        EndpointCapabilities = ChatModelGroq.ChatResponsesBatch
    };
    
    /// <summary>
    /// <inheritdoc cref="ModelQwen3Vl32BInstruct"/>
    /// </summary>
    public readonly ChatModel Qwen3Vl32BInstruct = ModelQwen3Vl32BInstruct;
    
    /// <summary>
    /// All known Alibaba models from Groq.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [ModelQwen332B, ModelQwen3627B, ModelQwen3827B, ModelQwen3Vl32BInstruct]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;

    internal ChatModelGroqAlibaba()
    {

    }
}
