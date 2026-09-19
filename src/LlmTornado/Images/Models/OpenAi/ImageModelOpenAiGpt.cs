using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Images.Models.OpenAi;

/// <summary>
/// GPT class models from OpenAI.
/// </summary>
public class ImageModelOpenAiGpt : IVendorModelClassProvider
{
    /// <summary>
    /// GPT Image 2.5 Sunburst — most capable model for image generation and editing.
    /// Released September 10, 2026. Supports low, medium, high, xhigh, max, and auto quality.
    /// </summary>
    public static readonly ImageModel ModelV25Sunburst = new ImageModel("gpt-image-2.5-sunburst", LLmProviders.OpenAi, ["gpt-image-2.5-sunburst-2026-09-08"]);

    /// <summary>
    /// <inheritdoc cref="ModelV25Sunburst"/>
    /// </summary>
    public readonly ImageModel V25Sunburst = ModelV25Sunburst;

    /// <summary>
    /// GPT Image 2.5 Flare — fastest high-quality everyday image generation.
    /// Released September 10, 2026. Supports low, medium, high, xhigh, max, and auto quality.
    /// </summary>
    public static readonly ImageModel ModelV25Flare = new ImageModel("gpt-image-2.5-flare", LLmProviders.OpenAi, ["gpt-image-2.5-flare-2026-09-08"]);

    /// <summary>
    /// <inheritdoc cref="ModelV25Flare"/>
    /// </summary>
    public readonly ImageModel V25Flare = ModelV25Flare;

    /// <summary>
    /// Latest GPT Image 2 model. Recommended default for image generation and editing.
    /// Transparent backgrounds are supported in preview (png/webp).
    /// </summary>
    public static readonly ImageModel ModelV2 = new ImageModel("gpt-image-2", LLmProviders.OpenAi, ["gpt-image-2-2026-04-21"]);

    /// <summary>
    /// <inheritdoc cref="ModelV2"/>
    /// </summary>
    public readonly ImageModel V2 = ModelV2;

    /// <summary>
    /// Recommended default model for OpenAI image generation.
    /// </summary>
    public static readonly ImageModel Default = ModelV2;
    
    /// <summary>
    /// Superior instruction following, text rendering, detailed editing, real-world knowledge
    /// </summary>
    public static readonly ImageModel ModelV1Mini = new ImageModel("gpt-image-1-mini", LLmProviders.OpenAi);

    /// <summary>
    /// <inheritdoc cref="ModelV1Mini"/>
    /// </summary>
    public readonly ImageModel V1Mini = ModelV1Mini;
    
    /// <summary>
    /// Superior instruction following, text rendering, detailed editing, real-world knowledge
    /// </summary>
    public static readonly ImageModel ModelV1 = new ImageModel("gpt-image-1", LLmProviders.OpenAi);

    /// <summary>
    /// <inheritdoc cref="ModelV1"/>
    /// </summary>
    public readonly ImageModel V1 = ModelV1;
    
    /// <summary>
    /// Superior instruction following, text rendering, detailed editing, real-world knowledge
    /// </summary>
    public static readonly ImageModel ModelV15 = new ImageModel("gpt-image-1.5", LLmProviders.OpenAi);

    /// <summary>
    /// <inheritdoc cref="ModelV15"/>
    /// </summary>
    public readonly ImageModel V15 = ModelV15;
    
    /// <summary>
    /// Latest dynamic model for image generation in ChatGPT.
    /// </summary>
    public static readonly ImageModel ModelChatGptLatest = new ImageModel("chatgpt-image-latest", LLmProviders.OpenAi);

    /// <summary>
    /// <inheritdoc cref="ModelChatGptLatest"/>
    /// </summary>
    public readonly ImageModel ChatGptLatest = ModelChatGptLatest;
    
    /// <summary>
    /// All known GPT image models from OpenAI.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;
    
    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelV25Sunburst, ModelV25Flare, ModelV2, ModelV1, ModelV1Mini, ModelV15, ModelChatGptLatest
    ]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;
    
    internal ImageModelOpenAiGpt()
    {
        
    }
}