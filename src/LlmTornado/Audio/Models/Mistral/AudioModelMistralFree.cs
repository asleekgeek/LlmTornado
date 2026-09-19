using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Audio.Models.Mistral;

/// <summary>
/// Free (as in free weights) audio models from Mistral.
/// </summary>
public class AudioModelMistralFree : IVendorModelClassProvider
{
    /// <summary>
    /// Voxtral Mini Transcribe 2 — batch transcription with diarization, context biasing, and word-level timestamps.
    /// </summary>
    public static readonly AudioModel ModelVoxtralMini2602 = new AudioModel("voxtral-mini-2602", LLmProviders.Mistral, 32_000, [ "voxtral-mini-latest" ]);

    /// <summary>
    /// <inheritdoc cref="ModelVoxtralMini2602"/>
    /// </summary>
    public readonly AudioModel VoxtralMini2602 = ModelVoxtralMini2602;

    /// <summary>
    /// <inheritdoc cref="ModelVoxtralMini2602"/>
    /// </summary>
    public readonly AudioModel VoxtralMiniTranscribe2 = ModelVoxtralMini2602;

    /// <summary>
    /// Voxtral Mini Transcribe Realtime — live streaming transcription (not compatible with diarize).
    /// </summary>
    public static readonly AudioModel ModelVoxtralMiniTranscribeRealtime2602 = new AudioModel("voxtral-mini-transcribe-realtime-2602", LLmProviders.Mistral, 32_000);

    /// <summary>
    /// <inheritdoc cref="ModelVoxtralMiniTranscribeRealtime2602"/>
    /// </summary>
    public readonly AudioModel VoxtralMiniTranscribeRealtime2602 = ModelVoxtralMiniTranscribeRealtime2602;

    /// <summary>
    /// Voxtral Mini TTS — text-to-speech with zero-shot voice cloning (March 2026).
    /// </summary>
    public static readonly AudioModel ModelVoxtralMiniTts2603 = new AudioModel("voxtral-mini-tts-2603", LLmProviders.Mistral, 4_096, [ "voxtral-tts-2603", "voxtral-mini-tts-latest" ]);

    /// <summary>
    /// <inheritdoc cref="ModelVoxtralMiniTts2603"/>
    /// </summary>
    public readonly AudioModel VoxtralMiniTts2603 = ModelVoxtralMiniTts2603;

    /// <summary>
    /// <inheritdoc cref="ModelVoxtralMiniTts2603"/>
    /// </summary>
    public readonly AudioModel VoxtralTts = ModelVoxtralMiniTts2603;

    /// <summary>
    /// Voxtral Mini (3B) — first-generation transcription / chat audio model (July 2025).
    /// </summary>
    public static readonly AudioModel ModelVoxtralMini2507 = new AudioModel("voxtral-mini-2507", LLmProviders.Mistral, 32_000);

    /// <summary>
    /// <inheritdoc cref="ModelVoxtralMini2507"/>
    /// </summary>
    public readonly AudioModel VoxtralMini2507 = ModelVoxtralMini2507;
    
    /// <summary>
    /// All known free models from Mistral.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelVoxtralMini2602, ModelVoxtralMiniTranscribeRealtime2602, ModelVoxtralMiniTts2603, ModelVoxtralMini2507
    ]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;
    
    internal AudioModelMistralFree()
    {
        
    }
}