using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models.Alibaba;

/// <summary>
/// Alibaba cost-optimized models - fast, low-cost models with long context.
/// </summary>
public class ChatModelAlibabaCostOptimized : IVendorModelClassProvider
{
    /// <summary>
    /// Qwen3.8-Flash - Fast native vision-language model. Hybrid thinking enabled by default, 1M context.
    /// </summary>
    public static readonly ChatModel ModelQwen38Flash = new ChatModel("qwen3.8-flash", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen38Flash"/>
    /// </summary>
    public readonly ChatModel Qwen38Flash = ModelQwen38Flash;

    /// <summary>
    /// Qwen3.7-Flash - Fast 3.7 vision-language model. Thinking enabled by default, 1M context.
    /// </summary>
    public static readonly ChatModel ModelQwen37Flash = new ChatModel("qwen3.7-flash", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen37Flash"/>
    /// </summary>
    public readonly ChatModel Qwen37Flash = ModelQwen37Flash;

    /// <summary>
    /// Qwen3.7-Flash-2026-07-15 - Snapshot from July 15, 2026
    /// </summary>
    public static readonly ChatModel ModelQwen37Flash20260715 = new ChatModel("qwen3.7-flash-2026-07-15", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen37Flash20260715"/>
    /// </summary>
    public readonly ChatModel Qwen37Flash20260715 = ModelQwen37Flash20260715;

    /// <summary>
    /// Qwen3.6-Flash - Fast 3.6 vision-language model. Thinking enabled by default, 1M context.
    /// </summary>
    public static readonly ChatModel ModelQwen36Flash = new ChatModel("qwen3.6-flash", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen36Flash"/>
    /// </summary>
    public readonly ChatModel Qwen36Flash = ModelQwen36Flash;

    /// <summary>
    /// Qwen3.6-Flash-2026-04-16 - Snapshot from April 16, 2026
    /// </summary>
    public static readonly ChatModel ModelQwen36Flash20260416 = new ChatModel("qwen3.6-flash-2026-04-16", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen36Flash20260416"/>
    /// </summary>
    public readonly ChatModel Qwen36Flash20260416 = ModelQwen36Flash20260416;

    /// <summary>
    /// Qwen3.5-Flash - Fast 3.5 vision-language model. Thinking enabled by default, 1M context.
    /// </summary>
    public static readonly ChatModel ModelQwen35Flash = new ChatModel("qwen3.5-flash", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen35Flash"/>
    /// </summary>
    public readonly ChatModel Qwen35Flash = ModelQwen35Flash;

    /// <summary>
    /// Qwen3.5-Flash-2026-02-23 - Snapshot from February 23, 2026
    /// </summary>
    public static readonly ChatModel ModelQwen35Flash20260223 = new ChatModel("qwen3.5-flash-2026-02-23", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen35Flash20260223"/>
    /// </summary>
    public readonly ChatModel Qwen35Flash20260223 = ModelQwen35Flash20260223;

    /// <summary>
    /// Qwen3.6-35B-A3B - Open-source 3.6 MoE vision-language model
    /// </summary>
    public static readonly ChatModel ModelQwen3635BA3B = new ChatModel("qwen3.6-35b-a3b", LLmProviders.Alibaba, 256_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3635BA3B"/>
    /// </summary>
    public readonly ChatModel Qwen3635BA3B = ModelQwen3635BA3B;

    /// <summary>
    /// Qwen3.6-27B - Open-source 3.6 dense vision-language model
    /// </summary>
    public static readonly ChatModel ModelQwen3627B = new ChatModel("qwen3.6-27b", LLmProviders.Alibaba, 256_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3627B"/>
    /// </summary>
    public readonly ChatModel Qwen3627B = ModelQwen3627B;

    /// <summary>
    /// Qwen3.5-397B-A17B - Open-source 3.5 MoE model
    /// </summary>
    public static readonly ChatModel ModelQwen35397BA17B = new ChatModel("qwen3.5-397b-a17b", LLmProviders.Alibaba, 256_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen35397BA17B"/>
    /// </summary>
    public readonly ChatModel Qwen35397BA17B = ModelQwen35397BA17B;

    /// <summary>
    /// Qwen3.5-122B-A10B - Open-source 3.5 MoE model
    /// </summary>
    public static readonly ChatModel ModelQwen35122BA10B = new ChatModel("qwen3.5-122b-a10b", LLmProviders.Alibaba, 256_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen35122BA10B"/>
    /// </summary>
    public readonly ChatModel Qwen35122BA10B = ModelQwen35122BA10B;

    /// <summary>
    /// Qwen3.5-27B - Open-source 3.5 dense model
    /// </summary>
    public static readonly ChatModel ModelQwen3527B = new ChatModel("qwen3.5-27b", LLmProviders.Alibaba, 256_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3527B"/>
    /// </summary>
    public readonly ChatModel Qwen3527B = ModelQwen3527B;

    /// <summary>
    /// Qwen3.5-35B-A3B - Open-source 3.5 MoE model
    /// </summary>
    public static readonly ChatModel ModelQwen3535BA3B = new ChatModel("qwen3.5-35b-a3b", LLmProviders.Alibaba, 256_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3535BA3B"/>
    /// </summary>
    public readonly ChatModel Qwen3535BA3B = ModelQwen3535BA3B;

    /// <summary>
    /// Qwen3-Coder-Next - Next-generation coding model, 256k context
    /// </summary>
    public static readonly ChatModel ModelQwen3CoderNext = new ChatModel("qwen3-coder-next", LLmProviders.Alibaba, 256_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3CoderNext"/>
    /// </summary>
    public readonly ChatModel Qwen3CoderNext = ModelQwen3CoderNext;

    /// <summary>
    /// Qwen-MT-Flash - Fast translation model
    /// </summary>
    public static readonly ChatModel ModelQwenMtFlash = new ChatModel("qwen-mt-flash", LLmProviders.Alibaba, 16_384);

    /// <summary>
    /// <inheritdoc cref="ModelQwenMtFlash"/>
    /// </summary>
    public readonly ChatModel QwenMtFlash = ModelQwenMtFlash;

    /// <summary>
    /// Qwen-MT-Lite - Lightweight translation model
    /// </summary>
    public static readonly ChatModel ModelQwenMtLite = new ChatModel("qwen-mt-lite", LLmProviders.Alibaba, 16_384);

    /// <summary>
    /// <inheritdoc cref="ModelQwenMtLite"/>
    /// </summary>
    public readonly ChatModel QwenMtLite = ModelQwenMtLite;

    /// <summary>
    /// Qwen-Flash-Character - Role-playing model for anthropomorphic interaction
    /// </summary>
    public static readonly ChatModel ModelQwenFlashCharacter = new ChatModel("qwen-flash-character", LLmProviders.Alibaba, 8_192);

    /// <summary>
    /// <inheritdoc cref="ModelQwenFlashCharacter"/>
    /// </summary>
    public readonly ChatModel QwenFlashCharacter = ModelQwenFlashCharacter;

    /// <summary>
    /// Qwen3-Coder-Flash - Code generation model with tool interaction
    /// </summary>
    public static readonly ChatModel ModelQwen3CoderFlash = new ChatModel("qwen3-coder-flash", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3CoderFlash"/>
    /// </summary>
    public readonly ChatModel Qwen3CoderFlash = ModelQwen3CoderFlash;

    /// <summary>
    /// Qwen-Flash - Fast and low-cost model for simple tasks
    /// </summary>
    public static readonly ChatModel ModelQwenFlash = new ChatModel("qwen-flash", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwenFlash"/>
    /// </summary>
    public readonly ChatModel QwenFlash = ModelQwenFlash;

    /// <summary>
    /// Qwen-MT-Turbo - Fast translation model with 92 languages
    /// </summary>
    public static readonly ChatModel ModelQwenMtTurbo = new ChatModel("qwen-mt-turbo", LLmProviders.Alibaba, 16_384);

    /// <summary>
    /// <inheritdoc cref="ModelQwenMtTurbo"/>
    /// </summary>
    public readonly ChatModel QwenMtTurbo = ModelQwenMtTurbo;

    /// <summary>
    /// Qwen-Flash-2025-07-28 - Snapshot from July 28, 2025
    /// </summary>
    public static readonly ChatModel ModelQwenFlash20250728 = new ChatModel("qwen-flash-2025-07-28", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwenFlash20250728"/>
    /// </summary>
    public readonly ChatModel QwenFlash20250728 = ModelQwenFlash20250728;

    /// <summary>
    /// Qwen3-Coder-Flash-2025-07-28 - Snapshot from July 28, 2025
    /// </summary>
    public static readonly ChatModel ModelQwen3CoderFlash20250728 = new ChatModel("qwen3-coder-flash-2025-07-28", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3CoderFlash20250728"/>
    /// </summary>
    public readonly ChatModel Qwen3CoderFlash20250728 = ModelQwen3CoderFlash20250728;

    /// <summary>
    /// Qwen3-Coder-30B-A3B-Instruct - SOTA coding performance for smaller scale
    /// </summary>
    public static readonly ChatModel ModelQwen3Coder30BA3BInstruct = new ChatModel("qwen3-coder-30b-a3b-instruct", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3Coder30BA3BInstruct"/>
    /// </summary>
    public readonly ChatModel Qwen3Coder30BA3BInstruct = ModelQwen3Coder30BA3BInstruct;

    /// <summary>
    /// Qwen3-30B-A3B-Instruct-2507 - Open-source model from July 2025
    /// </summary>
    public static readonly ChatModel ModelQwen330BA3BInstruct2507 = new ChatModel("qwen3-30b-a3b-instruct-2507", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen330BA3BInstruct2507"/>
    /// </summary>
    public readonly ChatModel Qwen330BA3BInstruct2507 = ModelQwen330BA3BInstruct2507;

    /// <summary>
    /// Qwen3-30B-A3B-Thinking-2507 - Open-source reasoning model from July 2025
    /// </summary>
    public static readonly ChatModel ModelQwen330BA3BThinking2507 = new ChatModel("qwen3-30b-a3b-thinking-2507", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen330BA3BThinking2507"/>
    /// </summary>
    public readonly ChatModel Qwen330BA3BThinking2507 = ModelQwen330BA3BThinking2507;

    /// <summary>
    /// Qwen3-30B-A3B - Hybrid reasoning model
    /// </summary>
    public static readonly ChatModel ModelQwen330BA3B = new ChatModel("qwen3-30b-a3b", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen330BA3B"/>
    /// </summary>
    public readonly ChatModel Qwen330BA3B = ModelQwen330BA3B;

    /// <summary>
    /// Qwen3-14B - Hybrid reasoning model with SOTA performance
    /// </summary>
    public static readonly ChatModel ModelQwen314B = new ChatModel("qwen3-14b", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen314B"/>
    /// </summary>
    public readonly ChatModel Qwen314B = ModelQwen314B;

    /// <summary>
    /// Qwen3-8B - Hybrid reasoning model with SOTA performance
    /// </summary>
    public static readonly ChatModel ModelQwen38B = new ChatModel("qwen3-8b", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen38B"/>
    /// </summary>
    public readonly ChatModel Qwen38B = ModelQwen38B;

    /// <summary>
    /// Qwen3-4B - Hybrid reasoning model with SOTA performance
    /// </summary>
    public static readonly ChatModel ModelQwen34B = new ChatModel("qwen3-4b", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen34B"/>
    /// </summary>
    public readonly ChatModel Qwen34B = ModelQwen34B;

    /// <summary>
    /// Qwen3-1.7B - Hybrid reasoning model with enhanced user experience
    /// </summary>
    public static readonly ChatModel ModelQwen31_7B = new ChatModel("qwen3-1.7b", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen31_7B"/>
    /// </summary>
    public readonly ChatModel Qwen31_7B = ModelQwen31_7B;

    /// <summary>
    /// Qwen3-0.6B - Hybrid reasoning model with enhanced capabilities
    /// </summary>
    public static readonly ChatModel ModelQwen30_6B = new ChatModel("qwen3-0.6b", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen30_6B"/>
    /// </summary>
    public readonly ChatModel Qwen30_6B = ModelQwen30_6B;

    /// <summary>
    /// All known cost-optimized models from Alibaba.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelQwen38Flash, ModelQwen37Flash, ModelQwen37Flash20260715, ModelQwen36Flash, ModelQwen36Flash20260416,
        ModelQwen35Flash, ModelQwen35Flash20260223, ModelQwen3635BA3B, ModelQwen3627B, ModelQwen35397BA17B,
        ModelQwen35122BA10B, ModelQwen3527B, ModelQwen3535BA3B, ModelQwen3CoderNext, ModelQwenMtFlash, ModelQwenMtLite,
        ModelQwenFlashCharacter, ModelQwen3CoderFlash, ModelQwenFlash, ModelQwenMtTurbo, ModelQwenFlash20250728, ModelQwen3CoderFlash20250728,
        ModelQwen3Coder30BA3BInstruct, ModelQwen330BA3BInstruct2507, ModelQwen330BA3BThinking2507, ModelQwen330BA3B,
        ModelQwen314B, ModelQwen38B, ModelQwen34B, ModelQwen31_7B, ModelQwen30_6B
    ]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;

    internal ChatModelAlibabaCostOptimized()
    {
    }
}
