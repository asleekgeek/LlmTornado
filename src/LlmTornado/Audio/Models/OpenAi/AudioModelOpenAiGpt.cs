using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Audio.Models.OpenAi;

/// <summary>
/// GPT transcribe models from OpenAI (July 30, 2026 release).
/// </summary>
public class AudioModelOpenAiGpt : IVendorModelClassProvider
{
    /// <summary>
    /// GPT Transcribe — high-accuracy speech-to-text for completed audio files,
    /// streamed file transcripts, and committed Realtime turns.
    /// Supports free-form transcription context, keyword hints, and multiple input languages.
    /// Recommended replacement for whisper-1 and gpt-4o-transcribe.
    /// </summary>
    public static readonly AudioModel ModelTranscribe = new AudioModel("gpt-transcribe", LLmProviders.OpenAi, 16_385);

    /// <summary>
    /// <inheritdoc cref="ModelTranscribe"/>
    /// </summary>
    public readonly AudioModel Transcribe = ModelTranscribe;

    /// <summary>
    /// GPT Live Transcribe — low-latency streaming speech-to-text for live audio.
    /// Supports tunable latency, unstructured context, keyword hints, and multiple language hints.
    /// Recommended replacement for gpt-4o-transcribe streaming workloads.
    /// </summary>
    public static readonly AudioModel ModelLiveTranscribe = new AudioModel("gpt-live-transcribe", LLmProviders.OpenAi, 16_385);

    /// <summary>
    /// <inheritdoc cref="ModelLiveTranscribe"/>
    /// </summary>
    public readonly AudioModel LiveTranscribe = ModelLiveTranscribe;

    /// <summary>
    /// All known GPT transcribe models from OpenAI.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelTranscribe,
        ModelLiveTranscribe
    ]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;

    internal AudioModelOpenAiGpt()
    {

    }
}
