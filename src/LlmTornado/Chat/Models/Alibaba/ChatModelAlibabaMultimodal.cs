using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models.Alibaba;

/// <summary>
/// Alibaba multimodal models - text, images, audio, and video processing.
/// </summary>
public class ChatModelAlibabaMultimodal : IVendorModelClassProvider
{
    /// <summary>
    /// Qwen3.8-Omni-Flash - Native omni-modal model (text, image, audio, video). 1M context, hybrid thinking.
    /// </summary>
    public static readonly ChatModel ModelQwen38OmniFlash = new ChatModel("qwen3.8-omni-flash", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen38OmniFlash"/>
    /// </summary>
    public readonly ChatModel Qwen38OmniFlash = ModelQwen38OmniFlash;

    /// <summary>
    /// Qwen3.5-Omni-Plus - Full-modal understanding and generation. 256k context.
    /// </summary>
    public static readonly ChatModel ModelQwen35OmniPlus = new ChatModel("qwen3.5-omni-plus", LLmProviders.Alibaba, 262_144);

    /// <summary>
    /// <inheritdoc cref="ModelQwen35OmniPlus"/>
    /// </summary>
    public readonly ChatModel Qwen35OmniPlus = ModelQwen35OmniPlus;

    /// <summary>
    /// Qwen3.5-Omni-Plus-2026-03-15 - Snapshot from March 15, 2026
    /// </summary>
    public static readonly ChatModel ModelQwen35OmniPlus20260315 = new ChatModel("qwen3.5-omni-plus-2026-03-15", LLmProviders.Alibaba, 262_144);

    /// <summary>
    /// <inheritdoc cref="ModelQwen35OmniPlus20260315"/>
    /// </summary>
    public readonly ChatModel Qwen35OmniPlus20260315 = ModelQwen35OmniPlus20260315;

    /// <summary>
    /// Qwen3.5-Omni-Plus-Realtime - Real-time WebSocket omni model
    /// </summary>
    public static readonly ChatModel ModelQwen35OmniPlusRealtime = new ChatModel("qwen3.5-omni-plus-realtime", LLmProviders.Alibaba, 262_144);

    /// <summary>
    /// <inheritdoc cref="ModelQwen35OmniPlusRealtime"/>
    /// </summary>
    public readonly ChatModel Qwen35OmniPlusRealtime = ModelQwen35OmniPlusRealtime;

    /// <summary>
    /// Qwen3.5-Omni-Plus-Realtime-2026-03-15 - Real-time snapshot from March 15, 2026
    /// </summary>
    public static readonly ChatModel ModelQwen35OmniPlusRealtime20260315 = new ChatModel("qwen3.5-omni-plus-realtime-2026-03-15", LLmProviders.Alibaba, 262_144);

    /// <summary>
    /// <inheritdoc cref="ModelQwen35OmniPlusRealtime20260315"/>
    /// </summary>
    public readonly ChatModel Qwen35OmniPlusRealtime20260315 = ModelQwen35OmniPlusRealtime20260315;

    /// <summary>
    /// Qwen3.5-Omni-Flash - Faster omni-modal HTTP model
    /// </summary>
    public static readonly ChatModel ModelQwen35OmniFlash = new ChatModel("qwen3.5-omni-flash", LLmProviders.Alibaba, 262_144);

    /// <summary>
    /// <inheritdoc cref="ModelQwen35OmniFlash"/>
    /// </summary>
    public readonly ChatModel Qwen35OmniFlash = ModelQwen35OmniFlash;

    /// <summary>
    /// Qwen3.5-Omni-Flash-2026-03-15 - Snapshot from March 15, 2026
    /// </summary>
    public static readonly ChatModel ModelQwen35OmniFlash20260315 = new ChatModel("qwen3.5-omni-flash-2026-03-15", LLmProviders.Alibaba, 262_144);

    /// <summary>
    /// <inheritdoc cref="ModelQwen35OmniFlash20260315"/>
    /// </summary>
    public readonly ChatModel Qwen35OmniFlash20260315 = ModelQwen35OmniFlash20260315;

    /// <summary>
    /// Qwen3.5-Omni-Flash-Realtime - Real-time WebSocket flash omni model
    /// </summary>
    public static readonly ChatModel ModelQwen35OmniFlashRealtime = new ChatModel("qwen3.5-omni-flash-realtime", LLmProviders.Alibaba, 262_144);

    /// <summary>
    /// <inheritdoc cref="ModelQwen35OmniFlashRealtime"/>
    /// </summary>
    public readonly ChatModel Qwen35OmniFlashRealtime = ModelQwen35OmniFlashRealtime;

    /// <summary>
    /// Qwen3.5-Omni-Flash-Realtime-2026-03-15 - Real-time snapshot from March 15, 2026
    /// </summary>
    public static readonly ChatModel ModelQwen35OmniFlashRealtime20260315 = new ChatModel("qwen3.5-omni-flash-realtime-2026-03-15", LLmProviders.Alibaba, 262_144);

    /// <summary>
    /// <inheritdoc cref="ModelQwen35OmniFlashRealtime20260315"/>
    /// </summary>
    public readonly ChatModel Qwen35OmniFlashRealtime20260315 = ModelQwen35OmniFlashRealtime20260315;

    /// <summary>
    /// Qwen3.8-LiveTranslate-Flash-Realtime - Real-time multilingual audio/video translation (~2.3s latency)
    /// </summary>
    public static readonly ChatModel ModelQwen38LiveTranslateFlashRealtime = new ChatModel("qwen3.8-livetranslate-flash-realtime", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen38LiveTranslateFlashRealtime"/>
    /// </summary>
    public readonly ChatModel Qwen38LiveTranslateFlashRealtime = ModelQwen38LiveTranslateFlashRealtime;

    /// <summary>
    /// Qwen3.5-LiveTranslate-Flash-Realtime - Real-time multilingual audio/video translation (60 languages)
    /// </summary>
    public static readonly ChatModel ModelQwen35LiveTranslateFlashRealtime = new ChatModel("qwen3.5-livetranslate-flash-realtime", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen35LiveTranslateFlashRealtime"/>
    /// </summary>
    public readonly ChatModel Qwen35LiveTranslateFlashRealtime = ModelQwen35LiveTranslateFlashRealtime;

    /// <summary>
    /// Qwen3.5-LiveTranslate-Flash-Realtime-2026-05-19 - Snapshot from May 19, 2026
    /// </summary>
    public static readonly ChatModel ModelQwen35LiveTranslateFlashRealtime20260519 = new ChatModel("qwen3.5-livetranslate-flash-realtime-2026-05-19", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen35LiveTranslateFlashRealtime20260519"/>
    /// </summary>
    public readonly ChatModel Qwen35LiveTranslateFlashRealtime20260519 = ModelQwen35LiveTranslateFlashRealtime20260519;

    /// <summary>
    /// Qwen-Image-3.0-Pro - High-fidelity image generation with long-text and dense layouts
    /// </summary>
    public static readonly ChatModel ModelQwenImage30Pro = new ChatModel("qwen-image-3.0-pro", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwenImage30Pro"/>
    /// </summary>
    public readonly ChatModel QwenImage30Pro = ModelQwenImage30Pro;

    /// <summary>
    /// Qwen-Image-3.0 - Standard image generation, balanced quality and speed
    /// </summary>
    public static readonly ChatModel ModelQwenImage30 = new ChatModel("qwen-image-3.0", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwenImage30"/>
    /// </summary>
    public readonly ChatModel QwenImage30 = ModelQwenImage30;

    /// <summary>
    /// Qwen-Image-2.0-Pro-2026-06-22 - Unified generation and editing snapshot
    /// </summary>
    public static readonly ChatModel ModelQwenImage20Pro20260622 = new ChatModel("qwen-image-2.0-pro-2026-06-22", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwenImage20Pro20260622"/>
    /// </summary>
    public readonly ChatModel QwenImage20Pro20260622 = ModelQwenImage20Pro20260622;

    /// <summary>
    /// Qwen-Image-2.0-Pro-2026-04-22 - April 22, 2026 image snapshot
    /// </summary>
    public static readonly ChatModel ModelQwenImage20Pro20260422 = new ChatModel("qwen-image-2.0-pro-2026-04-22", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwenImage20Pro20260422"/>
    /// </summary>
    public readonly ChatModel QwenImage20Pro20260422 = ModelQwenImage20Pro20260422;

    /// <summary>
    /// Qwen-Audio-3.0-TTS-Plus - High-quality speech synthesis
    /// </summary>
    public static readonly ChatModel ModelQwenAudio30TtsPlus = new ChatModel("qwen-audio-3.0-tts-plus", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwenAudio30TtsPlus"/>
    /// </summary>
    public readonly ChatModel QwenAudio30TtsPlus = ModelQwenAudio30TtsPlus;

    /// <summary>
    /// Qwen-Audio-3.0-TTS-Flash - Low-latency speech synthesis
    /// </summary>
    public static readonly ChatModel ModelQwenAudio30TtsFlash = new ChatModel("qwen-audio-3.0-tts-flash", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwenAudio30TtsFlash"/>
    /// </summary>
    public readonly ChatModel QwenAudio30TtsFlash = ModelQwenAudio30TtsFlash;

    /// <summary>
    /// Qwen-Audio-3.0-ASR-Flash - Non-real-time speech recognition (30 languages, Chinese dialects)
    /// </summary>
    public static readonly ChatModel ModelQwenAudio30AsrFlash = new ChatModel("qwen-audio-3.0-asr-flash", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwenAudio30AsrFlash"/>
    /// </summary>
    public readonly ChatModel QwenAudio30AsrFlash = ModelQwenAudio30AsrFlash;

    /// <summary>
    /// Qwen-Audio-3.0-ASR-Flash-Streaming - Real-time speech recognition
    /// </summary>
    public static readonly ChatModel ModelQwenAudio30AsrFlashStreaming = new ChatModel("qwen-audio-3.0-asr-flash-streaming", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwenAudio30AsrFlashStreaming"/>
    /// </summary>
    public readonly ChatModel QwenAudio30AsrFlashStreaming = ModelQwenAudio30AsrFlashStreaming;

    /// <summary>
    /// Qwen-Audio-3.0-ASR-Flash-Filetrans - File transcription speech recognition
    /// </summary>
    public static readonly ChatModel ModelQwenAudio30AsrFlashFiletrans = new ChatModel("qwen-audio-3.0-asr-flash-filetrans", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwenAudio30AsrFlashFiletrans"/>
    /// </summary>
    public readonly ChatModel QwenAudio30AsrFlashFiletrans = ModelQwenAudio30AsrFlashFiletrans;

    /// <summary>
    /// Qwen-Audio-3.0-Realtime-Plus - End-to-end real-time speech conversation
    /// </summary>
    public static readonly ChatModel ModelQwenAudio30RealtimePlus = new ChatModel("qwen-audio-3.0-realtime-plus", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwenAudio30RealtimePlus"/>
    /// </summary>
    public readonly ChatModel QwenAudio30RealtimePlus = ModelQwenAudio30RealtimePlus;

    /// <summary>
    /// Qwen-Audio-3.0-Realtime-Flash - Low-latency real-time speech conversation
    /// </summary>
    public static readonly ChatModel ModelQwenAudio30RealtimeFlash = new ChatModel("qwen-audio-3.0-realtime-flash", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwenAudio30RealtimeFlash"/>
    /// </summary>
    public readonly ChatModel QwenAudio30RealtimeFlash = ModelQwenAudio30RealtimeFlash;

    /// <summary>
    /// Fun-ASR-2025-11-07 - Speech recognition snapshot with dialect and multilingual upgrades
    /// </summary>
    public static readonly ChatModel ModelFunAsr20251107 = new ChatModel("fun-asr-2025-11-07", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelFunAsr20251107"/>
    /// </summary>
    public readonly ChatModel FunAsr20251107 = ModelFunAsr20251107;

    /// <summary>
    /// Fun-ASR-Flash-2026-06-15 - June 2026 ASR snapshot
    /// </summary>
    public static readonly ChatModel ModelFunAsrFlash20260615 = new ChatModel("fun-asr-flash-2026-06-15", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelFunAsrFlash20260615"/>
    /// </summary>
    public readonly ChatModel FunAsrFlash20260615 = ModelFunAsrFlash20260615;

    /// <summary>
    /// Qwen-MT-Image-2.0 - Image translation across 55 languages
    /// </summary>
    public static readonly ChatModel ModelQwenMtImage20 = new ChatModel("qwen-mt-image-2.0", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwenMtImage20"/>
    /// </summary>
    public readonly ChatModel QwenMtImage20 = ModelQwenMtImage20;

    /// <summary>
    /// Qwen-Image-Plus - First image generation foundation model with complex text rendering
    /// </summary>
    public static readonly ChatModel ModelQwenImagePlus = new ChatModel("qwen-image-plus", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwenImagePlus"/>
    /// </summary>
    public readonly ChatModel QwenImagePlus = ModelQwenImagePlus;

    /// <summary>
    /// Qwen-Image - First image generation foundation model
    /// </summary>
    public static readonly ChatModel ModelQwenImage = new ChatModel("qwen-image", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwenImage"/>
    /// </summary>
    public readonly ChatModel QwenImage = ModelQwenImage;

    /// <summary>
    /// Qwen-Image-Edit - First Tongyi Qwen image editing model
    /// </summary>
    public static readonly ChatModel ModelQwenImageEdit = new ChatModel("qwen-image-edit", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwenImageEdit"/>
    /// </summary>
    public readonly ChatModel QwenImageEdit = ModelQwenImageEdit;

    /// <summary>
    /// Qwen3-Omni-Flash - Multimodal large-scale model with Thinker-Talker MoE architecture
    /// </summary>
    public static readonly ChatModel ModelQwen3OmniFlash = new ChatModel("qwen3-omni-flash", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3OmniFlash"/>
    /// </summary>
    public readonly ChatModel Qwen3OmniFlash = ModelQwen3OmniFlash;

    /// <summary>
    /// Qwen3-Omni-Flash-Realtime - Real-time version of Qwen3-Omni-Flash
    /// </summary>
    public static readonly ChatModel ModelQwen3OmniFlashRealtime = new ChatModel("qwen3-omni-flash-realtime", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3OmniFlashRealtime"/>
    /// </summary>
    public readonly ChatModel Qwen3OmniFlashRealtime = ModelQwen3OmniFlashRealtime;

    /// <summary>
    /// Fun-ASR - Next-generation end-to-end speech recognition model
    /// </summary>
    public static readonly ChatModel ModelFunAsr = new ChatModel("fun-asr", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelFunAsr"/>
    /// </summary>
    public readonly ChatModel FunAsr = ModelFunAsr;

    /// <summary>
    /// Qwen3-ASR-Flash - Highly accurate multilingual speech recognition model
    /// </summary>
    public static readonly ChatModel ModelQwen3AsrFlash = new ChatModel("qwen3-asr-flash", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3AsrFlash"/>
    /// </summary>
    public readonly ChatModel Qwen3AsrFlash = ModelQwen3AsrFlash;

    /// <summary>
    /// Qwen3-LiveTranslate-Flash-Realtime - Real-time multilingual simultaneous audio/video interpretation
    /// </summary>
    public static readonly ChatModel ModelQwen3LiveTranslateFlashRealtime = new ChatModel("qwen3-livetranslate-flash-realtime", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3LiveTranslateFlashRealtime"/>
    /// </summary>
    public readonly ChatModel Qwen3LiveTranslateFlashRealtime = ModelQwen3LiveTranslateFlashRealtime;

    /// <summary>
    /// Qwen3-TTS-Flash - Latest offline text-to-speech foundation model
    /// </summary>
    public static readonly ChatModel ModelQwen3TtsFlash = new ChatModel("qwen3-tts-flash", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3TtsFlash"/>
    /// </summary>
    public readonly ChatModel Qwen3TtsFlash = ModelQwen3TtsFlash;

    /// <summary>
    /// Qwen3-TTS-Flash-Realtime - Latest real-time speech synthesis foundation model
    /// </summary>
    public static readonly ChatModel ModelQwen3TtsFlashRealtime = new ChatModel("qwen3-tts-flash-realtime", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3TtsFlashRealtime"/>
    /// </summary>
    public readonly ChatModel Qwen3TtsFlashRealtime = ModelQwen3TtsFlashRealtime;

    /// <summary>
    /// Qwen3-LiveTranslate-Flash-Realtime-2025-09-22 - Snapshot from September 22, 2025
    /// </summary>
    public static readonly ChatModel ModelQwen3LiveTranslateFlashRealtime20250922 = new ChatModel("qwen3-livetranslate-flash-realtime-2025-09-22", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3LiveTranslateFlashRealtime20250922"/>
    /// </summary>
    public readonly ChatModel Qwen3LiveTranslateFlashRealtime20250922 = ModelQwen3LiveTranslateFlashRealtime20250922;

    /// <summary>
    /// Fun-ASR-2025-08-25 - Snapshot from August 25, 2025
    /// </summary>
    public static readonly ChatModel ModelFunAsr20250825 = new ChatModel("fun-asr-2025-08-25", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelFunAsr20250825"/>
    /// </summary>
    public readonly ChatModel FunAsr20250825 = ModelFunAsr20250825;

    /// <summary>
    /// Qwen3-TTS-Flash-2025-09-18 - Snapshot from September 18, 2025
    /// </summary>
    public static readonly ChatModel ModelQwen3TtsFlash20250918 = new ChatModel("qwen3-tts-flash-2025-09-18", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3TtsFlash20250918"/>
    /// </summary>
    public readonly ChatModel Qwen3TtsFlash20250918 = ModelQwen3TtsFlash20250918;

    /// <summary>
    /// Qwen3-TTS-Flash-Realtime-2025-09-18 - Snapshot from September 18, 2025
    /// </summary>
    public static readonly ChatModel ModelQwen3TtsFlashRealtime20250918 = new ChatModel("qwen3-tts-flash-realtime-2025-09-18", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3TtsFlashRealtime20250918"/>
    /// </summary>
    public readonly ChatModel Qwen3TtsFlashRealtime20250918 = ModelQwen3TtsFlashRealtime20250918;

    /// <summary>
    /// Qwen3-Omni-Flash-2025-09-15 - Snapshot from September 15, 2025
    /// </summary>
    public static readonly ChatModel ModelQwen3OmniFlash20250915 = new ChatModel("qwen3-omni-flash-2025-09-15", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3OmniFlash20250915"/>
    /// </summary>
    public readonly ChatModel Qwen3OmniFlash20250915 = ModelQwen3OmniFlash20250915;

    /// <summary>
    /// Qwen3-Omni-Flash-Realtime-2025-09-15 - Snapshot from September 15, 2025
    /// </summary>
    public static readonly ChatModel ModelQwen3OmniFlashRealtime20250915 = new ChatModel("qwen3-omni-flash-realtime-2025-09-15", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3OmniFlashRealtime20250915"/>
    /// </summary>
    public readonly ChatModel Qwen3OmniFlashRealtime20250915 = ModelQwen3OmniFlashRealtime20250915;

    /// <summary>
    /// Qwen3-ASR-Flash-2025-09-08 - Snapshot from September 8, 2025
    /// </summary>
    public static readonly ChatModel ModelQwen3AsrFlash20250908 = new ChatModel("qwen3-asr-flash-2025-09-08", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3AsrFlash20250908"/>
    /// </summary>
    public readonly ChatModel Qwen3AsrFlash20250908 = ModelQwen3AsrFlash20250908;

    /// <summary>
    /// Qwen3-Omni-30b-a3b-Captioner - Fine-grained audio analysis model
    /// </summary>
    public static readonly ChatModel ModelQwen3Omni30bA3bCaptioner = new ChatModel("qwen3-omni-30b-a3b-captioner", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen3Omni30bA3bCaptioner"/>
    /// </summary>
    public readonly ChatModel Qwen3Omni30bA3bCaptioner = ModelQwen3Omni30bA3bCaptioner;

    /// <summary>
    /// Qwen2.5-Omni-7B - Multimodal understanding and generation large model
    /// </summary>
    public static readonly ChatModel ModelQwen2_5Omni7B = new ChatModel("qwen2.5-omni-7b", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelQwen2_5Omni7B"/>
    /// </summary>
    public readonly ChatModel Qwen2_5Omni7B = ModelQwen2_5Omni7B;

    /// <summary>
    /// All known multimodal models from Alibaba.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelQwen38OmniFlash, ModelQwen35OmniPlus, ModelQwen35OmniPlus20260315, ModelQwen35OmniPlusRealtime,
        ModelQwen35OmniPlusRealtime20260315, ModelQwen35OmniFlash, ModelQwen35OmniFlash20260315, ModelQwen35OmniFlashRealtime,
        ModelQwen35OmniFlashRealtime20260315, ModelQwen38LiveTranslateFlashRealtime, ModelQwen35LiveTranslateFlashRealtime,
        ModelQwen35LiveTranslateFlashRealtime20260519, ModelQwenImage30Pro, ModelQwenImage30, ModelQwenImage20Pro20260622,
        ModelQwenImage20Pro20260422, ModelQwenAudio30TtsPlus, ModelQwenAudio30TtsFlash, ModelQwenAudio30AsrFlash,
        ModelQwenAudio30AsrFlashStreaming, ModelQwenAudio30AsrFlashFiletrans, ModelQwenAudio30RealtimePlus, ModelQwenAudio30RealtimeFlash,
        ModelFunAsr20251107, ModelFunAsrFlash20260615, ModelQwenMtImage20, ModelQwenImagePlus, ModelQwenImage, ModelQwenImageEdit,
        ModelQwen3OmniFlash, ModelQwen3OmniFlashRealtime, ModelFunAsr, ModelQwen3AsrFlash, ModelQwen3LiveTranslateFlashRealtime,
        ModelQwen3TtsFlash, ModelQwen3TtsFlashRealtime, ModelQwen3LiveTranslateFlashRealtime20250922, ModelFunAsr20250825,
        ModelQwen3TtsFlash20250918, ModelQwen3TtsFlashRealtime20250918, ModelQwen3OmniFlash20250915, ModelQwen3OmniFlashRealtime20250915,
        ModelQwen3AsrFlash20250908, ModelQwen3Omni30bA3bCaptioner, ModelQwen2_5Omni7B
    ]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;

    internal ChatModelAlibabaMultimodal()
    {
    }
}
