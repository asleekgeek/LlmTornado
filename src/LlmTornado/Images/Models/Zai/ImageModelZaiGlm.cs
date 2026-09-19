using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Images.Models.Zai;

/// <summary>
/// GLM image generation models from Z.AI.
/// </summary>
public class ImageModelZaiGlm : IVendorModelClassProvider
{
    /// <summary>
    /// GLM-Image - Multimodal image generation with strong text rendering and knowledge-intensive scenes.
    /// Recommended sizes: 1280x1280 (default), 1568x1056, 1056x1568, 1472x1088, 1088x1472, 1728x960, 960x1728.
    /// Quality: hd (default, ~20s) or standard (~5-10s).
    /// </summary>
    public static readonly ImageModel ModelImage = new ImageModel("glm-image", LLmProviders.Zai);

    /// <summary>
    /// <inheritdoc cref="ModelImage"/>
    /// </summary>
    public readonly ImageModel Image = ModelImage;

    /// <summary>
    /// CogView-4 (cogview-4-250304) - High-quality image generation.
    /// Recommended sizes: 1024x1024 (default), 768x1344, 864x1152, 1344x768, 1152x864, 1440x720, 720x1440.
    /// </summary>
    public static readonly ImageModel ModelCogView4 = new ImageModel("cogview-4-250304", LLmProviders.Zai);

    /// <summary>
    /// <inheritdoc cref="ModelCogView4"/>
    /// </summary>
    public readonly ImageModel CogView4 = ModelCogView4;

    /// <summary>
    /// All known GLM image generation models from Z.AI.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelImage,
        ModelCogView4
    ]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;

    internal ImageModelZaiGlm()
    {
    }
}
