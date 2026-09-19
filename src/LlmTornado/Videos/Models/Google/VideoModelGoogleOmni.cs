using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Videos.Models.Google;

/// <summary>
/// Google Gemini Omni conversational video generation models.
/// </summary>
public class VideoModelGoogleOmni : IVendorModelClassProvider
{
    /// <summary>
    /// gemini-omni-1.1-flash - Fast conversational video generation and editing with native audio.
    /// Supports text/image-to-video, video extension, first+last-frame interpolation, and 360p/720p/1080p/4K output.
    /// Output clips are 3–10 seconds at 24 FPS.
    /// </summary>
    public static readonly VideoModel ModelOmni11Flash = new VideoModel("gemini-omni-1.1-flash", LLmProviders.Google);

    /// <summary>
    /// <inheritdoc cref="ModelOmni11Flash"/>
    /// </summary>
    public readonly VideoModel Omni11Flash = ModelOmni11Flash;

    /// <summary>
    /// gemini-omni-flash-preview - Preview endpoint for Omni Flash. Prefer <see cref="ModelOmni11Flash"/>.
    /// </summary>
    [Obsolete("Deprecated September 30, 2026. Use ModelOmni11Flash instead.")]
    public static readonly VideoModel ModelOmniFlashPreview = new VideoModel("gemini-omni-flash-preview", LLmProviders.Google);

    /// <summary>
    /// <inheritdoc cref="ModelOmniFlashPreview"/>
    /// </summary>
    [Obsolete("Deprecated September 30, 2026. Use Omni11Flash instead.")]
    public readonly VideoModel OmniFlashPreview = ModelOmniFlashPreview;

    /// <summary>
    /// All known Gemini Omni video models from Google.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelOmni11Flash,
        ModelOmniFlashPreview
    ]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;

    internal VideoModelGoogleOmni()
    {

    }
}
