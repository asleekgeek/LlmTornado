using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models.Alibaba;

/// <summary>
/// Alibaba flagship models - highest performance, most powerful models.
/// </summary>
public class ChatModelAlibabaFlagship : IVendorModelClassProvider
{
    /// <summary>
    /// Qwen3.8-Max - Native vision-language flagship (2.4T MoE). Hybrid thinking enabled by default, 1M context.
    /// </summary>
    public static readonly ChatModel ModelQwen38Max = new ChatModel("qwen3.8-max", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen38Max"/>
    /// </summary>
    public readonly ChatModel Qwen38Max = ModelQwen38Max;

    /// <summary>
    /// Qwen3.8-Max-0902 - September 2, 2026 snapshot with stronger coding and agent orchestration.
    /// </summary>
    public static readonly ChatModel ModelQwen38Max0902 = new ChatModel("qwen3.8-max-0902", LLmProviders.Alibaba, 1_000_000, [ "qwen3.8-max-2026-09-02" ]);

    /// <summary>
    /// <inheritdoc cref="ModelQwen38Max0902"/>
    /// </summary>
    public readonly ChatModel Qwen38Max0902 = ModelQwen38Max0902;

    /// <summary>
    /// Qwen3.7-Plus - Balanced vision-language model with multimodal hybrid agents. Thinking enabled by default.
    /// </summary>
    public static readonly ChatModel ModelQwen37Plus = new ChatModel("qwen3.7-plus", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen37Plus"/>
    /// </summary>
    public readonly ChatModel Qwen37Plus = ModelQwen37Plus;

    /// <summary>
    /// Qwen3.7-Plus-2026-05-26 - Snapshot from May 26, 2026
    /// </summary>
    public static readonly ChatModel ModelQwen37Plus20260526 = new ChatModel("qwen3.7-plus-2026-05-26", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen37Plus20260526"/>
    /// </summary>
    public readonly ChatModel Qwen37Plus20260526 = ModelQwen37Plus20260526;

    /// <summary>
    /// Qwen3.7-Max - Flagship of the 3.7 series. Later snapshots add vision. Thinking enabled by default.
    /// </summary>
    public static readonly ChatModel ModelQwen37Max = new ChatModel("qwen3.7-max", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen37Max"/>
    /// </summary>
    public readonly ChatModel Qwen37Max = ModelQwen37Max;

    /// <summary>
    /// Qwen3.7-Max-Preview - Thinking-only preview snapshot
    /// </summary>
    public static readonly ChatModel ModelQwen37MaxPreview = new ChatModel("qwen3.7-max-preview", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen37MaxPreview"/>
    /// </summary>
    public readonly ChatModel Qwen37MaxPreview = ModelQwen37MaxPreview;

    /// <summary>
    /// Qwen3.7-Max-2026-06-08 - Snapshot with visual-modal understanding
    /// </summary>
    public static readonly ChatModel ModelQwen37Max20260608 = new ChatModel("qwen3.7-max-2026-06-08", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen37Max20260608"/>
    /// </summary>
    public readonly ChatModel Qwen37Max20260608 = ModelQwen37Max20260608;

    /// <summary>
    /// Qwen3.7-Max-2026-05-20 - Text-only snapshot from May 20, 2026
    /// </summary>
    public static readonly ChatModel ModelQwen37Max20260520 = new ChatModel("qwen3.7-max-2026-05-20", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen37Max20260520"/>
    /// </summary>
    public readonly ChatModel Qwen37Max20260520 = ModelQwen37Max20260520;

    /// <summary>
    /// Qwen3.7-Max-2026-05-17 - Thinking-only snapshot from May 17, 2026
    /// </summary>
    public static readonly ChatModel ModelQwen37Max20260517 = new ChatModel("qwen3.7-max-2026-05-17", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen37Max20260517"/>
    /// </summary>
    public readonly ChatModel Qwen37Max20260517 = ModelQwen37Max20260517;

    /// <summary>
    /// Qwen3.6-Plus - Native vision-language Plus model. Thinking enabled by default, 1M context.
    /// </summary>
    public static readonly ChatModel ModelQwen36Plus = new ChatModel("qwen3.6-plus", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen36Plus"/>
    /// </summary>
    public readonly ChatModel Qwen36Plus = ModelQwen36Plus;

    /// <summary>
    /// Qwen3.6-Plus-2026-04-02 - Snapshot from April 2, 2026
    /// </summary>
    public static readonly ChatModel ModelQwen36Plus20260402 = new ChatModel("qwen3.6-plus-2026-04-02", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen36Plus20260402"/>
    /// </summary>
    public readonly ChatModel Qwen36Plus20260402 = ModelQwen36Plus20260402;

    /// <summary>
    /// Qwen3.6-Max-Preview - Largest closed-source 3.6 model. Text-only, 256k context.
    /// </summary>
    public static readonly ChatModel ModelQwen36MaxPreview = new ChatModel("qwen3.6-max-preview", LLmProviders.Alibaba, 256_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen36MaxPreview"/>
    /// </summary>
    public readonly ChatModel Qwen36MaxPreview = ModelQwen36MaxPreview;

    /// <summary>
    /// Qwen3.8-27B - Open-source native vision-language dense model. Thinking enabled by default.
    /// </summary>
    public static readonly ChatModel ModelQwen3827B = new ChatModel("qwen3.8-27b", LLmProviders.Alibaba, 256_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3827B"/>
    /// </summary>
    public readonly ChatModel Qwen3827B = ModelQwen3827B;

    /// <summary>
    /// Qwen3.8-2.4T-A95B - Open-source flagship MoE. Thinking-only, 1M context.
    /// </summary>
    public static readonly ChatModel ModelQwen3824TA95B = new ChatModel("qwen3.8-2.4t-a95b", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3824TA95B"/>
    /// </summary>
    public readonly ChatModel Qwen3824TA95B = ModelQwen3824TA95B;

    /// <summary>
    /// Qwen3-Max - Most powerful general-purpose LLM
    /// </summary>
    public static readonly ChatModel ModelQwen3Max = new ChatModel("qwen3-max", LLmProviders.Alibaba, 256_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3Max"/>
    /// </summary>
    public readonly ChatModel Qwen3Max = ModelQwen3Max;

    /// <summary>
    /// Qwen3.5-Plus - Native vision-language model. Thinking enabled by default, 1M context.
    /// </summary>
    public static readonly ChatModel ModelQwen35Plus = new ChatModel("qwen3.5-plus", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen35Plus"/>
    /// </summary>
    public readonly ChatModel Qwen35Plus = ModelQwen35Plus;

    /// <summary>
    /// Qwen3.5-Plus-2026-04-20 - Snapshot with faster inference and stronger agentic coding
    /// </summary>
    public static readonly ChatModel ModelQwen35Plus20260420 = new ChatModel("qwen3.5-plus-2026-04-20", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen35Plus20260420"/>
    /// </summary>
    public readonly ChatModel Qwen35Plus20260420 = ModelQwen35Plus20260420;

    /// <summary>
    /// Qwen3.5-Plus-2026-02-15 - Initial Qwen3.5-Plus snapshot
    /// </summary>
    public static readonly ChatModel ModelQwen35Plus20260215 = new ChatModel("qwen3.5-plus-2026-02-15", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen35Plus20260215"/>
    /// </summary>
    public readonly ChatModel Qwen35Plus20260215 = ModelQwen35Plus20260215;

    /// <summary>
    /// Qwen3-Max-2026-01-23 - Snapshot from January 23, 2026
    /// </summary>
    public static readonly ChatModel ModelQwen3Max20260123 = new ChatModel("qwen3-max-2026-01-23", LLmProviders.Alibaba, 256_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3Max20260123"/>
    /// </summary>
    public readonly ChatModel Qwen3Max20260123 = ModelQwen3Max20260123;

    /// <summary>
    /// Qwen3-Max-Preview - Preview version with state-of-the-art performance
    /// </summary>
    public static readonly ChatModel ModelQwen3MaxPreview = new ChatModel("qwen3-max-preview", LLmProviders.Alibaba, 256_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3MaxPreview"/>
    /// </summary>
    public readonly ChatModel Qwen3MaxPreview = ModelQwen3MaxPreview;

    /// <summary>
    /// Qwen3-Coder-Plus - Powerful coding agent with tool calling
    /// </summary>
    public static readonly ChatModel ModelQwen3CoderPlus = new ChatModel("qwen3-coder-plus", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3CoderPlus"/>
    /// </summary>
    public readonly ChatModel Qwen3CoderPlus = ModelQwen3CoderPlus;

    /// <summary>
    /// Qwen-Plus - Enhanced version with balanced performance
    /// </summary>
    public static readonly ChatModel ModelQwenPlus = new ChatModel("qwen-plus", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwenPlus"/>
    /// </summary>
    public readonly ChatModel QwenPlus = ModelQwenPlus;

    /// <summary>
    /// Qwen-MT-Plus - Flagship translation model with 92 languages
    /// </summary>
    public static readonly ChatModel ModelQwenMtPlus = new ChatModel("qwen-mt-plus", LLmProviders.Alibaba, 16_384);

    /// <summary>
    /// <inheritdoc cref="ModelQwenMtPlus"/>
    /// </summary>
    public readonly ChatModel QwenMtPlus = ModelQwenMtPlus;

    /// <summary>
    /// Qwen-Plus-Latest - Dynamically updated version
    /// </summary>
    public static readonly ChatModel ModelQwenPlusLatest = new ChatModel("qwen-plus-latest", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwenPlusLatest"/>
    /// </summary>
    public readonly ChatModel QwenPlusLatest = ModelQwenPlusLatest;

    /// <summary>
    /// Qwen-Plus-Character-Japanese - Optimized for Japanese role-playing
    /// </summary>
    public static readonly ChatModel ModelQwenPlusCharacterJapanese = new ChatModel("qwen-plus-character-ja", LLmProviders.Alibaba, 32_768, [ "qwen-plus-character-japanese" ]);

    /// <summary>
    /// <inheritdoc cref="ModelQwenPlusCharacterJapanese"/>
    /// </summary>
    public readonly ChatModel QwenPlusCharacterJapanese = ModelQwenPlusCharacterJapanese;

    /// <summary>
    /// Qwen3-Max-2025-09-23 - Snapshot from September 23, 2025
    /// </summary>
    public static readonly ChatModel ModelQwen3Max20250923 = new ChatModel("qwen3-max-2025-09-23", LLmProviders.Alibaba, 256_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3Max20250923"/>
    /// </summary>
    public readonly ChatModel Qwen3Max20250923 = ModelQwen3Max20250923;

    /// <summary>
    /// Qwen3-Coder-Plus-2025-09-23 - Snapshot from September 23, 2025
    /// </summary>
    public static readonly ChatModel ModelQwen3CoderPlus20250923 = new ChatModel("qwen3-coder-plus-2025-09-23", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3CoderPlus20250923"/>
    /// </summary>
    public readonly ChatModel Qwen3CoderPlus20250923 = ModelQwen3CoderPlus20250923;

    /// <summary>
    /// Qwen-Plus-2025-09-11 - Snapshot from September 11, 2025
    /// </summary>
    public static readonly ChatModel ModelQwenPlus20250911 = new ChatModel("qwen-plus-2025-09-11", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwenPlus20250911"/>
    /// </summary>
    public readonly ChatModel QwenPlus20250911 = ModelQwenPlus20250911;

    /// <summary>
    /// Qwen-Plus-2025-07-28 - Snapshot from July 28, 2025
    /// </summary>
    public static readonly ChatModel ModelQwenPlus20250728 = new ChatModel("qwen-plus-2025-07-28", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwenPlus20250728"/>
    /// </summary>
    public readonly ChatModel QwenPlus20250728 = ModelQwenPlus20250728;

    /// <summary>
    /// Qwen3-Coder-Plus-2025-07-22 - Snapshot from July 22, 2025
    /// </summary>
    public static readonly ChatModel ModelQwen3CoderPlus20250722 = new ChatModel("qwen3-coder-plus-2025-07-22", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3CoderPlus20250722"/>
    /// </summary>
    public readonly ChatModel Qwen3CoderPlus20250722 = ModelQwen3CoderPlus20250722;

    /// <summary>
    /// Qwen-Plus-2025-07-14 - Snapshot from July 14, 2025
    /// </summary>
    public static readonly ChatModel ModelQwenPlus20250714 = new ChatModel("qwen-plus-2025-07-14", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwenPlus20250714"/>
    /// </summary>
    public readonly ChatModel QwenPlus20250714 = ModelQwenPlus20250714;

    /// <summary>
    /// Qwen-Plus-2025-04-28 - Snapshot from April 28, 2025
    /// </summary>
    public static readonly ChatModel ModelQwenPlus20250428 = new ChatModel("qwen-plus-2025-04-28", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwenPlus20250428"/>
    /// </summary>
    public readonly ChatModel QwenPlus20250428 = ModelQwenPlus20250428;

    /// <summary>
    /// Qwen3-Next-80B-A3B-Instruct - Open-source non-thinking mode model
    /// </summary>
    public static readonly ChatModel ModelQwen3Next80BA3BInstruct = new ChatModel("qwen3-next-80b-a3b-instruct", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3Next80BA3BInstruct"/>
    /// </summary>
    public readonly ChatModel Qwen3Next80BA3BInstruct = ModelQwen3Next80BA3BInstruct;

    /// <summary>
    /// Qwen3-Next-80B-A3B-Thinking - Open-source thinking mode model
    /// </summary>
    public static readonly ChatModel ModelQwen3Next80BA3BThinking = new ChatModel("qwen3-next-80b-a3b-thinking", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3Next80BA3BThinking"/>
    /// </summary>
    public readonly ChatModel Qwen3Next80BA3BThinking = ModelQwen3Next80BA3BThinking;

    /// <summary>
    /// Qwen3-Coder-480B-A35B-Instruct - SOTA coding performance
    /// </summary>
    public static readonly ChatModel ModelQwen3Coder480BA35BInstruct = new ChatModel("qwen3-coder-480b-a35b-instruct", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3Coder480BA35BInstruct"/>
    /// </summary>
    public readonly ChatModel Qwen3Coder480BA35BInstruct = ModelQwen3Coder480BA35BInstruct;

    /// <summary>
    /// Qwen3-235B-A22B-Instruct-2507 - Open-source model from July 2025
    /// </summary>
    public static readonly ChatModel ModelQwen3235BA22BInstruct2507 = new ChatModel("qwen3-235b-a22b-instruct-2507", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3235BA22BInstruct2507"/>
    /// </summary>
    public readonly ChatModel Qwen3235BA22BInstruct2507 = ModelQwen3235BA22BInstruct2507;

    /// <summary>
    /// Qwen3-235B-A22B-Thinking-2507 - Open-source reasoning model from July 2025
    /// </summary>
    public static readonly ChatModel ModelQwen3235BA22BThinking2507 = new ChatModel("qwen3-235b-a22b-thinking-2507", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3235BA22BThinking2507"/>
    /// </summary>
    public readonly ChatModel Qwen3235BA22BThinking2507 = ModelQwen3235BA22BThinking2507;

    /// <summary>
    /// Qwen3-235B-A22B - Hybrid reasoning model
    /// </summary>
    public static readonly ChatModel ModelQwen3235BA22B = new ChatModel("qwen3-235b-a22b", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3235BA22B"/>
    /// </summary>
    public readonly ChatModel Qwen3235BA22B = ModelQwen3235BA22B;

    /// <summary>
    /// Qwen3-32B - Hybrid reasoning model with SOTA performance
    /// </summary>
    public static readonly ChatModel ModelQwen332B = new ChatModel("qwen3-32b", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen332B"/>
    /// </summary>
    public readonly ChatModel Qwen332B = ModelQwen332B;

    /// <summary>
    /// Qwen-Plus-2025-01-25 - Snapshot from January 25, 2025
    /// </summary>
    public static readonly ChatModel ModelQwenPlus20250125 = new ChatModel("qwen-plus-2025-01-25", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwenPlus20250125"/>
    /// </summary>
    public readonly ChatModel QwenPlus20250125 = ModelQwenPlus20250125;

    /// <summary>
    /// All known flagship models from Alibaba.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelQwen38Max, ModelQwen38Max0902, ModelQwen37Plus, ModelQwen37Plus20260526, ModelQwen37Max,
        ModelQwen37MaxPreview, ModelQwen37Max20260608, ModelQwen37Max20260520, ModelQwen37Max20260517,
        ModelQwen36Plus, ModelQwen36Plus20260402, ModelQwen36MaxPreview, ModelQwen3827B, ModelQwen3824TA95B,
        ModelQwen3Max, ModelQwen3MaxPreview, ModelQwen3CoderPlus, ModelQwenPlus, ModelQwenMtPlus,
        ModelQwenPlusLatest, ModelQwenPlusCharacterJapanese, ModelQwen3Max20260123, ModelQwen3Max20250923, ModelQwen3CoderPlus20250923,
        ModelQwenPlus20250911, ModelQwenPlus20250728, ModelQwen3CoderPlus20250722, ModelQwenPlus20250714,
        ModelQwenPlus20250428, ModelQwen3Next80BA3BInstruct, ModelQwen3Next80BA3BThinking, ModelQwen3Coder480BA35BInstruct,
        ModelQwen3235BA22BInstruct2507, ModelQwen3235BA22BThinking2507, ModelQwen3235BA22B, ModelQwen332B, ModelQwenPlus20250125,
        ModelQwen35Plus, ModelQwen35Plus20260420, ModelQwen35Plus20260215
    ]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;

    internal ChatModelAlibabaFlagship()
    {
    }
}
