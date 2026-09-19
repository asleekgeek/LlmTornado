using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Audio.Models.Cohere;

/// <summary>
/// Cohere Transcribe ASR models.
/// </summary>
public class AudioModelCohereTranscribe : IVendorModelClassProvider
{
    /// <summary>
    /// Open-source 2B multilingual speech transcription model. 14 languages, 25MB max file size.
    /// Language must be supplied in ISO-639-1 format; the model does not auto-detect language.
    /// </summary>
    public static readonly AudioModel ModelV0326 = new AudioModel("cohere-transcribe-03-2026", LLmProviders.Cohere);

    /// <summary>
    /// <inheritdoc cref="ModelV0326"/>
    /// </summary>
    public readonly AudioModel V0326 = ModelV0326;

    /// <summary>
    /// Finetune of Cohere Transcribe optimized for Arabic audio. 25MB max file size.
    /// </summary>
    public static readonly AudioModel ModelArabic0726 = new AudioModel("cohere-transcribe-arabic-07-2026", LLmProviders.Cohere);

    /// <summary>
    /// <inheritdoc cref="ModelArabic0726"/>
    /// </summary>
    public readonly AudioModel Arabic0726 = ModelArabic0726;

    /// <summary>
    /// All known Cohere Transcribe models.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [ModelV0326, ModelArabic0726]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;

    internal AudioModelCohereTranscribe()
    {
    }
}
