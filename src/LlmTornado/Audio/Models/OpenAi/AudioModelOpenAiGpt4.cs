using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Audio.Models.OpenAi;

/// <summary>
/// Gpt4 class models from OpenAI.
/// </summary>
public class AudioModelOpenAiGpt4 : IVendorModelClassProvider
{
    /// <summary>
    /// gpt-4o-mini-tts
    /// </summary>
    public static readonly AudioModel Model4OMiniTts = new AudioModel("gpt-4o-mini-tts", LLmProviders.OpenAi, 16_385);

    /// <summary>
    /// <inheritdoc cref="Model4OMiniTts"/>
    /// </summary>
    public readonly AudioModel Gpt4OMiniTts = Model4OMiniTts;
    
    /// <summary>
    /// gpt-4o-transcribe. Deprecated: shutting down February 26, 2027. Migrate to gpt-transcribe.
    /// </summary>
    public static readonly AudioModel Model4OTranscribe = new AudioModel("gpt-4o-transcribe", LLmProviders.OpenAi, 16_385);

    /// <summary>
    /// <inheritdoc cref="Model4OTranscribe"/>
    /// </summary>
    [Obsolete("gpt-4o-transcribe shuts down on February 26, 2027. Use AudioModel.OpenAi.Gpt.Transcribe.")]
    public readonly AudioModel Gpt4OTranscribe = Model4OTranscribe;
    
    /// <summary>
    /// gpt-4o-mini-transcribe. Deprecated: shutting down February 26, 2027. Migrate to gpt-transcribe.
    /// </summary>
    public static readonly AudioModel Model4OMiniTranscribe = new AudioModel("gpt-4o-mini-transcribe", LLmProviders.OpenAi, 16_385);

    /// <summary>
    /// <inheritdoc cref="Model4OMiniTranscribe"/>
    /// </summary>
    [Obsolete("gpt-4o-mini-transcribe shuts down on February 26, 2027. Use AudioModel.OpenAi.Gpt.Transcribe.")]
    public readonly AudioModel Gpt4OMiniTranscribe = Model4OMiniTranscribe;
    
    /// <summary>
    /// gpt-audio-mini-2025-12-15
    /// </summary>
    public static readonly AudioModel ModelGptAudioMini20251215 = new AudioModel("gpt-audio-mini-2025-12-15", LLmProviders.OpenAi, 16_385);
    
    /// <summary>
    /// <inheritdoc cref="ModelGptAudioMini20251215"/>
    /// </summary>
    public readonly AudioModel GptAudioMini20251215 = ModelGptAudioMini20251215;

    /// <summary>
    /// gpt-4o-mini-transcribe-2025-12-15
    /// </summary>
    public static readonly AudioModel ModelGpt4OMiniTranscribe20251215 = new AudioModel("gpt-4o-mini-transcribe-2025-12-15", LLmProviders.OpenAi, 16_385);
    
    /// <summary>
    /// <inheritdoc cref="ModelGpt4OMiniTranscribe20251215"/>
    /// </summary>
    public readonly AudioModel Gpt4OMiniTranscribe20251215 = ModelGpt4OMiniTranscribe20251215;
    
    /// <summary>
    /// gpt-4o-mini-transcribe-2025-03-20
    /// </summary>
    public static readonly AudioModel ModelGpt4OMiniTranscribe20250320 = new AudioModel("gpt-4o-mini-transcribe-2025-03-20", LLmProviders.OpenAi, 16_385);

    /// <summary>
    /// <inheritdoc cref="ModelGpt4OMiniTranscribe20250320"/>
    /// </summary>
    public readonly AudioModel Gpt4OMiniTranscribe20250320 = ModelGpt4OMiniTranscribe20250320;
    
    /// <summary>
    /// gpt-4o-mini-tts-2025-03-20
    /// </summary>
    public static readonly AudioModel ModelGpt4OMiniTts20250320 = new AudioModel("gpt-4o-mini-tts-2025-03-20", LLmProviders.OpenAi, 16_385);

    /// <summary>
    /// <inheritdoc cref="ModelGpt4OMiniTts20250320"/>
    /// </summary>
    public readonly AudioModel Gpt4OMiniTts20250320 = ModelGpt4OMiniTts20250320;
    
     /// <summary>
    /// gpt-4o-mini-tts-2025-12-15
    /// </summary>
    public static readonly AudioModel ModelGpt4OMiniTts20251215 = new AudioModel("gpt-4o-mini-tts-2025-12-15", LLmProviders.OpenAi, 16_385);

    /// <summary>
    /// <inheritdoc cref="ModelGpt4OMiniTts20251215"/>
    /// </summary>
    public readonly AudioModel Gpt4OMiniTts20251215 = ModelGpt4OMiniTts20251215;
    
    /// <summary>
    /// gpt-4o-transcribe-diarize. Deprecated: shutting down February 26, 2027. Migrate to gpt-transcribe.
    /// </summary>
    public static readonly AudioModel ModelGpt4OTranscribeDiarize = new AudioModel("gpt-4o-transcribe-diarize", LLmProviders.OpenAi, 16_385);
    
    /// <summary>
    /// <inheritdoc cref="ModelGpt4OTranscribeDiarize"/>
    /// </summary>
    [Obsolete("gpt-4o-transcribe-diarize shuts down on February 26, 2027. Use AudioModel.OpenAi.Gpt.Transcribe.")]
    public readonly AudioModel Gpt4OTranscribeDiarize = ModelGpt4OTranscribeDiarize;

    /// <summary>
    /// All known Gpt4 models from OpenAI.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;
    
    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        Model4OMiniTts,
        Model4OTranscribe,
        Model4OMiniTranscribe,
        ModelGptAudioMini20251215,
        ModelGpt4OMiniTranscribe20251215,
        ModelGpt4OTranscribeDiarize,
        ModelGpt4OMiniTranscribe20250320,
        ModelGpt4OMiniTts20250320,
        ModelGpt4OMiniTts20251215
    ]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;
    
    internal AudioModelOpenAiGpt4()
    {
        
    }
}
