using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Audio.Models.MiniMax;

/// <summary>
/// MiniMax speech synthesis models.
/// </summary>
public class AudioModelMiniMaxSpeech : IVendorModelClassProvider
{
    /// <summary>
    /// speech-2.8-hd - Latest HD model. Ultra-realistic quality featuring sound tags.
    /// 40 languages, 7 emotions. Released January 23, 2026.
    /// </summary>
    public static readonly AudioModel ModelSpeech28Hd = new AudioModel("speech-2.8-hd", LLmProviders.MiniMax);
    
    /// <summary>
    /// <inheritdoc cref="ModelSpeech28Hd"/>
    /// </summary>
    public readonly AudioModel Speech28Hd = ModelSpeech28Hd;
    
    /// <summary>
    /// speech-2.8-turbo - Latest Turbo model. Seamless speed meets natural flow.
    /// </summary>
    public static readonly AudioModel ModelSpeech28Turbo = new AudioModel("speech-2.8-turbo", LLmProviders.MiniMax);
    
    /// <summary>
    /// <inheritdoc cref="ModelSpeech28Turbo"/>
    /// </summary>
    public readonly AudioModel Speech28Turbo = ModelSpeech28Turbo;
    
    /// <summary>
    /// speech-2.6-hd - HD model with outstanding prosody and cloning similarity.
    /// </summary>
    public static readonly AudioModel ModelSpeech26Hd = new AudioModel("speech-2.6-hd", LLmProviders.MiniMax);
    
    /// <summary>
    /// <inheritdoc cref="ModelSpeech26Hd"/>
    /// </summary>
    public readonly AudioModel Speech26Hd = ModelSpeech26Hd;
    
    /// <summary>
    /// speech-2.6-turbo - Turbo model with support for 40 languages.
    /// </summary>
    public static readonly AudioModel ModelSpeech26Turbo = new AudioModel("speech-2.6-turbo", LLmProviders.MiniMax);
    
    /// <summary>
    /// <inheritdoc cref="ModelSpeech26Turbo"/>
    /// </summary>
    public readonly AudioModel Speech26Turbo = ModelSpeech26Turbo;
    
    /// <summary>
    /// speech-02-hd - Superior rhythm and stability with outstanding replication similarity.
    /// </summary>
    public static readonly AudioModel ModelSpeech02Hd = new AudioModel("speech-02-hd", LLmProviders.MiniMax);
    
    /// <summary>
    /// <inheritdoc cref="ModelSpeech02Hd"/>
    /// </summary>
    public readonly AudioModel Speech02Hd = ModelSpeech02Hd;
    
    /// <summary>
    /// speech-02-turbo - Superior rhythm and stability with enhanced multilingual capabilities.
    /// </summary>
    public static readonly AudioModel ModelSpeech02Turbo = new AudioModel("speech-02-turbo", LLmProviders.MiniMax);
    
    /// <summary>
    /// <inheritdoc cref="ModelSpeech02Turbo"/>
    /// </summary>
    public readonly AudioModel Speech02Turbo = ModelSpeech02Turbo;
    
    /// <summary>
    /// All known speech models from MiniMax.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelSpeech28Hd, ModelSpeech28Turbo, ModelSpeech26Hd, ModelSpeech26Turbo, ModelSpeech02Hd, ModelSpeech02Turbo
    ]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;

    internal AudioModelMiniMaxSpeech()
    {
        
    }
}
