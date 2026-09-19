using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Videos.Models.MiniMax;

/// <summary>
/// MiniMax H3 video generation models.
/// </summary>
public class VideoModelMiniMaxH3 : IVendorModelClassProvider
{
    /// <summary>
    /// MiniMax-H3 - Next-generation multimodal video model.
    /// Supports text / image / first-and-last-frame / reference input (image, video, audio).
    /// Resolutions: 768P, 2K. Duration: 4–15 seconds. 24 fps. Released July 31, 2026.
    /// </summary>
    public static readonly VideoModel ModelH3 = new VideoModel("MiniMax-H3", LLmProviders.MiniMax);
    
    /// <summary>
    /// <inheritdoc cref="ModelH3"/>
    /// </summary>
    public readonly VideoModel H3 = ModelH3;

    /// <summary>
    /// MiniMax-H3-Max - Fast generation variant of H3.
    /// Supports text-to-video, image-to-video (first / last frame), and reference input.
    /// Resolutions: 480P, 768P (no 2K). Duration: 5–15 seconds. Released July 31, 2026.
    /// </summary>
    public static readonly VideoModel ModelH3Max = new VideoModel("MiniMax-H3-Max", LLmProviders.MiniMax);
    
    /// <summary>
    /// <inheritdoc cref="ModelH3Max"/>
    /// </summary>
    public readonly VideoModel H3Max = ModelH3Max;

    /// <summary>
    /// All known H3 video models from MiniMax.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelH3, ModelH3Max
    ]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;

    /// <summary>
    /// Known H3 model names used to route requests to the V2 video API.
    /// </summary>
    public static bool IsH3Model(string? modelName)
    {
        return modelName is "MiniMax-H3" or "MiniMax-H3-Max";
    }
    
    internal VideoModelMiniMaxH3()
    {
        
    }
}
