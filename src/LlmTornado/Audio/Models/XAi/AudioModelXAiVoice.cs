using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Audio.Models.XAi;

/// <summary>
/// Voice, speech-to-text, and speech-to-speech models from xAI.
/// </summary>
public class AudioModelXAiVoice : IVendorModelClassProvider
{
    /// <summary>
    /// Grok Voice Think Fast 2.0 — speech-to-speech model.
    /// <c>grok-voice-latest</c> routes here as of August 5, 2026.
    /// </summary>
    public static readonly AudioModel ModelThinkFast20 = new AudioModel("grok-voice-think-fast-2.0", LLmProviders.XAi, 0, [ "grok-voice-latest" ]);

    /// <summary>
    /// <inheritdoc cref="ModelThinkFast20"/>
    /// </summary>
    public readonly AudioModel ThinkFast20 = ModelThinkFast20;
    
    /// <summary>
    /// Grok Voice Think Fast 1.0 — previous speech-to-speech model. Deprecated in favor of 2.0.
    /// </summary>
    public static readonly AudioModel ModelThinkFast10 = new AudioModel("grok-voice-think-fast-1.0", LLmProviders.XAi);

    /// <summary>
    /// <inheritdoc cref="ModelThinkFast10"/>
    /// </summary>
    public readonly AudioModel ThinkFast10 = ModelThinkFast10;
    
    /// <summary>
    /// Grok Voice Transcribe 2.0 — speech-to-text.
    /// </summary>
    public static readonly AudioModel ModelTranscribe20 = new AudioModel("grok-voice-transcribe-2.0", LLmProviders.XAi);

    /// <summary>
    /// <inheritdoc cref="ModelTranscribe20"/>
    /// </summary>
    public readonly AudioModel Transcribe20 = ModelTranscribe20;
    
    /// <summary>
    /// Grok Voice Transcribe 1.0 — speech-to-text. Default transcribe model.
    /// </summary>
    public static readonly AudioModel ModelTranscribe10 = new AudioModel("grok-voice-transcribe-1.0", LLmProviders.XAi);

    /// <summary>
    /// <inheritdoc cref="ModelTranscribe10"/>
    /// </summary>
    public readonly AudioModel Transcribe10 = ModelTranscribe10;
    
    /// <summary>
    /// All known xAI voice models.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelThinkFast20, ModelThinkFast10, ModelTranscribe20, ModelTranscribe10
    ]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;

    internal AudioModelXAiVoice()
    {

    }
}
