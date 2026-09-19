using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Images.Models.XAi;


/// <summary>
/// Grok class models from xAI.
/// </summary>
public class ImageModelXAiGrok : IVendorModelClassProvider
{
    /// <summary>
    /// Our latest image generation model, capable of creating high-quality, detailed images from text prompts with enhanced creativity and precision.
    /// </summary>
    public static readonly ImageModel ModelV2241212 = new ImageModel("grok-2-image-1212", LLmProviders.XAi, [ "grok-2-image", "grok-2-image-latest" ]);

    /// <summary>
    /// <inheritdoc cref="ModelV2241212"/>
    /// </summary>
    public readonly ImageModel V2241212 = ModelV2241212;
    
    /// <summary>
    /// Grok Imagine image 1.0. Generate and edit images from text prompts.
    /// Supports aspect ratios, resolutions, and image editing with masks.
    /// </summary>
    public static readonly ImageModel ModelImagine = new ImageModel("grok-imagine-image", LLmProviders.XAi);
    
    /// <summary>
    /// <inheritdoc cref="ModelImagine"/>
    /// </summary>
    public readonly ImageModel Imagine = ModelImagine;
    
    /// <summary>
    /// Grok Imagine Image 2.0 — current recommended image model.
    /// Supports quality (auto / low / medium), 1k and 2k resolution, cinematic 21:9 and 5:2 ratios,
    /// and multi-image editing (up to 5 source images).
    /// </summary>
    public static readonly ImageModel ModelImagine20 = new ImageModel("grok-imagine-image-2.0", LLmProviders.XAi);
    
    /// <summary>
    /// <inheritdoc cref="ModelImagine20"/>
    /// </summary>
    public readonly ImageModel Imagine20 = ModelImagine20;
    
    /// <summary>
    /// Grok Imagine Image Quality. Retires November 2, 2026; requests then route to
    /// <see cref="ModelImagine20"/> with quality set to low.
    /// </summary>
    public static readonly ImageModel ModelImagineQuality = new ImageModel("grok-imagine-image-quality", LLmProviders.XAi);
    
    /// <summary>
    /// <inheritdoc cref="ModelImagineQuality"/>
    /// </summary>
    public readonly ImageModel ImagineQuality = ModelImagineQuality;
    
    /// <summary>
    /// All known Grok models from xAI.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;
    
    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelV2241212,
        ModelImagine,
        ModelImagine20,
        ModelImagineQuality
    ]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;
    
    internal ImageModelXAiGrok()
    {
        
    }
}