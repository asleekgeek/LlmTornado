using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models;

/// <summary>
/// Meta models hosted by Groq.
/// </summary>
public class ChatModelGroqMeta : IVendorModelClassProvider
{
    /// <summary>
    /// meta-llama/llama-4-scout-17b-16e-instruct
    /// Llama 4 Scout (17Bx16MoE) with vision (up to 5 images), tool use, and JSON mode.
    /// Deprecated Jul 17, 2026 for free/developer tiers.
    /// </summary>
    public static readonly ChatModel ModelLlama4Scout = new ChatModel("meta-llama/llama-4-scout-17b-16e-instruct", LLmProviders.Groq, 131_072)
    {
        EndpointCapabilities = ChatModelGroq.ChatResponsesBatch
    };
    
    /// <summary>
    /// <inheritdoc cref="ModelLlama4Scout"/>
    /// </summary>
    public readonly ChatModel Llama4Scout = ModelLlama4Scout;
    
    /// <summary>
    /// meta-llama/llama-4-maverick-17b-128e-instruct
    /// Llama 4 Maverick (17Bx128E) with vision, tool use, and JSON mode.
    /// Deprecated Mar 9, 2026 for free/developer tiers.
    /// </summary>
    public static readonly ChatModel ModelLlama4Maverick = new ChatModel("meta-llama/llama-4-maverick-17b-128e-instruct", LLmProviders.Groq, 131_072)
    {
        EndpointCapabilities = ChatModelGroq.ChatResponsesBatch
    };
    
    /// <summary>
    /// <inheritdoc cref="ModelLlama4Maverick"/>
    /// </summary>
    public readonly ChatModel Llama4Maverick = ModelLlama4Maverick;
    
    /// <summary>
    /// llama-3.3-70b-versatile
    /// Production Llama 3.3 70B. Enterprise-tier after Aug 16, 2026 deprecation of free/developer access.
    /// </summary>
    public static readonly ChatModel ModelLlama3370BVersatile = new ChatModel("groq-llama-3.3-70b-versatile", LLmProviders.Groq, 131_072)
    {
        ApiName = "llama-3.3-70b-versatile",
        EndpointCapabilities = ChatModelGroq.ChatResponsesBatch
    };
    
    /// <summary>
    /// <inheritdoc cref="ModelLlama3370BVersatile"/>
    /// </summary>
    public readonly ChatModel Llama3370BVersatile = ModelLlama3370BVersatile;
    
    /// <summary>
    /// llama-3.1-8b-instant
    /// Production Llama 3.1 8B Instant. Enterprise-tier after Aug 16, 2026 deprecation of free/developer access.
    /// </summary>
    public static readonly ChatModel ModelLlama318BInstant = new ChatModel("groq-llama-3.1-8b-instant", LLmProviders.Groq, 131_072)
    {
        ApiName = "llama-3.1-8b-instant",
        EndpointCapabilities = ChatModelGroq.ChatResponsesBatch
    };
    
    /// <summary>
    /// <inheritdoc cref="ModelLlama318BInstant"/>
    /// </summary>
    public readonly ChatModel Llama318BInstant = ModelLlama318BInstant;
    
    /// <summary>
    /// llama3-70b-8192
    /// Deprecated Aug 30, 2025. Replacement: llama-3.3-70b-versatile.
    /// </summary>
    public static readonly ChatModel ModelLlama370B = new ChatModel("groq-llama3-70b-8192", LLmProviders.Groq, 8_192)
    {
        ApiName = "llama3-70b-8192",
        EndpointCapabilities = ChatModelGroq.ChatOnly
    };
    
    /// <summary>
    /// <inheritdoc cref="ModelLlama370B"/>
    /// </summary>
    public readonly ChatModel Llama370B = ModelLlama370B;
    
    /// <summary>
    /// llama3-8b-8192
    /// Deprecated Aug 30, 2025. Replacement: llama-3.1-8b-instant.
    /// </summary>
    public static readonly ChatModel ModelLlama38B = new ChatModel("groq-llama3-8b-8192", LLmProviders.Groq, 8_192)
    {
        ApiName = "llama3-8b-8192",
        EndpointCapabilities = ChatModelGroq.ChatOnly
    };
    
    /// <summary>
    /// <inheritdoc cref="ModelLlama38B"/>
    /// </summary>
    public readonly ChatModel Llama38B = ModelLlama38B;
    
    /// <summary>
    /// meta-llama/llama-prompt-guard-2-22m
    /// Llama Prompt Guard 2 (22M) classifier for prompt injection and jailbreak detection.
    /// 512 token context.
    /// </summary>
    public static readonly ChatModel ModelLlamaPromptGuard222M = new ChatModel("grok-meta-llama/llama-prompt-guard-2-22m", LLmProviders.Groq, 512)
    {
        ApiName = "meta-llama/llama-prompt-guard-2-22m",
        EndpointCapabilities = ChatModelGroq.ChatOnly
    };
    
    /// <summary>
    /// <inheritdoc cref="ModelLlamaPromptGuard222M"/>
    /// </summary>
    public readonly ChatModel LlamaPromptGuard222M = ModelLlamaPromptGuard222M;
    
    /// <summary>
    /// meta-llama/llama-prompt-guard-2-86m
    /// Llama Prompt Guard 2 (86M) classifier for prompt injection and jailbreak detection.
    /// 512 token context.
    /// </summary>
    public static readonly ChatModel ModelLlamaPromptGuard286M = new ChatModel("grok-meta-llama/llama-prompt-guard-2-86m", LLmProviders.Groq, 512)
    {
        ApiName = "meta-llama/llama-prompt-guard-2-86m",
        EndpointCapabilities = ChatModelGroq.ChatOnly
    };
    
    /// <summary>
    /// <inheritdoc cref="ModelLlamaPromptGuard286M"/>
    /// </summary>
    public readonly ChatModel LlamaPromptGuard286M = ModelLlamaPromptGuard286M;
    
    /// <summary>
    /// meta-llama/Llama-Guard-4-12B
    /// Multimodal content moderation model (128K context). Deprecated Mar 5, 2026
    /// in favor of openai/gpt-oss-safeguard-20b.
    /// </summary>
    public static readonly ChatModel ModelLlamaGuard412B = new ChatModel("grok-meta-llama/llama-guard-4-12b", LLmProviders.Groq, 131_072)
    {
        ApiName = "meta-llama/Llama-Guard-4-12B",
        EndpointCapabilities = ChatModelGroq.ChatOnly
    };
    
    /// <summary>
    /// <inheritdoc cref="ModelLlamaGuard412B"/>
    /// </summary>
    public readonly ChatModel LlamaGuard412B = ModelLlamaGuard412B;
    
    /// <summary>
    /// All known Meta models from Groq.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelLlama3370BVersatile, ModelLlama318BInstant, ModelLlama370B, ModelLlama38B,
        ModelLlama4Scout, ModelLlama4Maverick,
        ModelLlamaPromptGuard222M, ModelLlamaPromptGuard286M, ModelLlamaGuard412B
    ]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;

    internal ChatModelGroqMeta()
    {

    }
}
