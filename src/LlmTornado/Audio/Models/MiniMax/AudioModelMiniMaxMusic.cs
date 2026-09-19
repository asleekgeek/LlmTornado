using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Audio.Models.MiniMax;

/// <summary>
/// MiniMax music generation models.
/// </summary>
public class AudioModelMiniMaxMusic : IVendorModelClassProvider
{
    /// <summary>
    /// music-3.0 - Latest music generation model. Supports instrumental output and automatic lyric generation.
    /// Released July 16, 2026.
    /// </summary>
    public static readonly AudioModel ModelMusic30 = new AudioModel("music-3.0", LLmProviders.MiniMax);
    
    /// <summary>
    /// <inheritdoc cref="ModelMusic30"/>
    /// </summary>
    public readonly AudioModel Music30 = ModelMusic30;
    
    /// <summary>
    /// music-3.0-free - Free-tier version of music-3.0.
    /// </summary>
    public static readonly AudioModel ModelMusic30Free = new AudioModel("music-3.0-free", LLmProviders.MiniMax);
    
    /// <summary>
    /// <inheritdoc cref="ModelMusic30Free"/>
    /// </summary>
    public readonly AudioModel Music30Free = ModelMusic30Free;
    
    /// <summary>
    /// music-2.6 - Previous-generation text-to-music model. Cover reborn, bass redefined.
    /// Released April 2026.
    /// </summary>
    public static readonly AudioModel ModelMusic26 = new AudioModel("music-2.6", LLmProviders.MiniMax);
    
    /// <summary>
    /// <inheritdoc cref="ModelMusic26"/>
    /// </summary>
    public readonly AudioModel Music26 = ModelMusic26;
    
    /// <summary>
    /// music-2.6-free - Free-tier version of music-2.6.
    /// </summary>
    public static readonly AudioModel ModelMusic26Free = new AudioModel("music-2.6-free", LLmProviders.MiniMax);
    
    /// <summary>
    /// <inheritdoc cref="ModelMusic26Free"/>
    /// </summary>
    public readonly AudioModel Music26Free = ModelMusic26Free;
    
    /// <summary>
    /// music-cover - Generate cover versions from reference audio, with optional lyric edits.
    /// </summary>
    public static readonly AudioModel ModelMusicCover = new AudioModel("music-cover", LLmProviders.MiniMax);
    
    /// <summary>
    /// <inheritdoc cref="ModelMusicCover"/>
    /// </summary>
    public readonly AudioModel MusicCover = ModelMusicCover;
    
    /// <summary>
    /// music-cover-free - Free-tier version of music-cover.
    /// </summary>
    public static readonly AudioModel ModelMusicCoverFree = new AudioModel("music-cover-free", LLmProviders.MiniMax);
    
    /// <summary>
    /// <inheritdoc cref="ModelMusicCoverFree"/>
    /// </summary>
    public readonly AudioModel MusicCoverFree = ModelMusicCoverFree;
    
    /// <summary>
    /// music-2.5 - MiniMax's music generation model. Generates songs from lyrics and a style prompt.
    /// Supports structure tags in lyrics: [Intro], [Verse], [Chorus], [Bridge], [Outro], etc.
    /// Output formats: mp3, wav, pcm. Configurable sample rate and bitrate.
    /// </summary>
    public static readonly AudioModel ModelMusic25 = new AudioModel("music-2.5", LLmProviders.MiniMax);
    
    /// <summary>
    /// <inheritdoc cref="ModelMusic25"/>
    /// </summary>
    public readonly AudioModel Music25 = ModelMusic25;
    
    /// <summary>
    /// All known music models from MiniMax.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelMusic30, ModelMusic30Free, ModelMusic26, ModelMusic26Free, ModelMusicCover, ModelMusicCoverFree, ModelMusic25
    ]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;

    internal AudioModelMiniMaxMusic()
    {
        
    }
}
