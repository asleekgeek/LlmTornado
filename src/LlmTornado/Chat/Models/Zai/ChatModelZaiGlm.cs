using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models.Zai;

/// <summary>
/// GLM models from ZAI.
/// </summary>
public class ChatModelZaiGlm : IVendorModelClassProvider
{
    /// <summary>
    /// GLM-5.3 - Flagship coding and agent model. Always reasons; supports reasoning_effort: low, high, max (default max).
    /// Text-only, 1M context, 128K max output. Thinking cannot be disabled.
    /// </summary>
    public static readonly ChatModel ModelGlm53 = new ChatModel("glm-5.3", LLmProviders.Zai, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelGlm53"/>
    /// </summary>
    public readonly ChatModel Glm53 = ModelGlm53;

    /// <summary>
    /// GLM-5.3-Flash - Native multimodal (video/image/text/file) model with frontier intelligence at low cost.
    /// Always reasons; supports reasoning_effort: low, high, max. 1M context, 128K max output.
    /// Thinking cannot be disabled.
    /// </summary>
    public static readonly ChatModel ModelGlm53Flash = new ChatModel("glm-5.3-flash", LLmProviders.Zai, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelGlm53Flash"/>
    /// </summary>
    public readonly ChatModel Glm53Flash = ModelGlm53Flash;

    /// <summary>
    /// GLM-5.3-FlashX - Ultra-fast variant of GLM-5.3-Flash (~200 tokens/s). Native multimodal, 1M context, 128K max output.
    /// Always reasons; thinking cannot be disabled.
    /// </summary>
    public static readonly ChatModel ModelGlm53FlashX = new ChatModel("glm-5.3-flashx", LLmProviders.Zai, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelGlm53FlashX"/>
    /// </summary>
    public readonly ChatModel Glm53FlashX = ModelGlm53FlashX;

    /// <summary>
    /// GLM-5.2 - Long-horizon coding model with lossless 1M context and 128K max output.
    /// Supports reasoning_effort: low, high, max.
    /// </summary>
    public static readonly ChatModel ModelGlm52 = new ChatModel("glm-5.2", LLmProviders.Zai, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelGlm52"/>
    /// </summary>
    public readonly ChatModel Glm52 = ModelGlm52;

    /// <summary>
    /// GLM-5.1 - Long-horizon agentic model aligned with Claude Opus 4.6. Can work autonomously for up to 8 hours.
    /// 200K context, 128K max output. Thinking is enabled by default and can be disabled.
    /// </summary>
    public static readonly ChatModel ModelGlm51 = new ChatModel("glm-5.1", LLmProviders.Zai, 200_000);

    /// <summary>
    /// <inheritdoc cref="ModelGlm51"/>
    /// </summary>
    public readonly ChatModel Glm51 = ModelGlm51;

    /// <summary>
    /// GLM-5 - Flagship Foundation Model designed for Agentic Engineering, capable of complex system engineering and long-range Agent tasks. 200K context, 128K max output.
    /// </summary>
    public static readonly ChatModel ModelGlm5 = new ChatModel("glm-5", LLmProviders.Zai, 200_000);

    /// <summary>
    /// <inheritdoc cref="ModelGlm5"/>
    /// </summary>
    public readonly ChatModel Glm5 = ModelGlm5;
    
    /// <summary>
    /// GLM-4.7 - Highest Performance, Strong Coding, More Versatile. 200K context, 128K max output.
    /// </summary>
    public static readonly ChatModel ModelGlm47 = new ChatModel("glm-4.7", LLmProviders.Zai, 200_000);

    /// <summary>
    /// <inheritdoc cref="ModelGlm47"/>
    /// </summary>
    public readonly ChatModel Glm47 = ModelGlm47;
    
    /// <summary>
    /// GLM-4.7-Flash - Lightweight and efficient model, free-tier version of GLM-4.7 with strong coding, reasoning, and generative task performance. 200K context, 128K max output.
    /// </summary>
    public static readonly ChatModel ModelGlm47Flash = new ChatModel("glm-4.7-flash", LLmProviders.Zai, 200_000);

    /// <summary>
    /// <inheritdoc cref="ModelGlm47Flash"/>
    /// </summary>
    public readonly ChatModel Glm47Flash = ModelGlm47Flash;
    
    /// <summary>
    /// GLM-4.7-FlashX - Ultra-fast response variant of GLM-4.7. 200K context, 128K max output.
    /// </summary>
    public static readonly ChatModel ModelGlm47FlashX = new ChatModel("glm-4.7-flashx", LLmProviders.Zai, 200_000);

    /// <summary>
    /// <inheritdoc cref="ModelGlm47FlashX"/>
    /// </summary>
    public readonly ChatModel Glm47FlashX = ModelGlm47FlashX;
    
    /// <summary>
    /// GLM-4.6 - Highest Performance, Strong Coding, More Versatile. 200K context, 128K max output.
    /// </summary>
    public static readonly ChatModel ModelGlm46 = new ChatModel("glm-4.6", LLmProviders.Zai, 200_000);

    /// <summary>
    /// <inheritdoc cref="ModelGlm46"/>
    /// </summary>
    public readonly ChatModel Glm46 = ModelGlm46;

    /// <summary>
    /// GLM-4.6V - Multimodal (Video/Image/Text/File) with native Function Calling, for cloud and high-performance scenarios. 128K context.
    /// </summary>
    public static readonly ChatModel ModelGlm46V = new ChatModel("glm-4.6v", LLmProviders.Zai, 128_000);

    /// <summary>
    /// <inheritdoc cref="ModelGlm46V"/>
    /// </summary>
    public readonly ChatModel Glm46V = ModelGlm46V;

    /// <summary>
    /// GLM-4.6V-Flash - Multimodal (Video/Image/Text/File), for local deployment and low-latency applications. 128K context.
    /// </summary>
    public static readonly ChatModel ModelGlm46VFlash = new ChatModel("glm-4.6v-flash", LLmProviders.Zai, 128_000);

    /// <summary>
    /// <inheritdoc cref="ModelGlm46VFlash"/>
    /// </summary>
    public readonly ChatModel Glm46VFlash = ModelGlm46VFlash;

    /// <summary>
    /// GLM-4.6V-FlashX - Ultra-fast multimodal (Video/Image/Text/File) vision model. 128K context.
    /// </summary>
    public static readonly ChatModel ModelGlm46VFlashX = new ChatModel("glm-4.6v-flashx", LLmProviders.Zai, 128_000);

    /// <summary>
    /// <inheritdoc cref="ModelGlm46VFlashX"/>
    /// </summary>
    public readonly ChatModel Glm46VFlashX = ModelGlm46VFlashX;

    /// <summary>
    /// GLM-4.5 - Better Performance, Strong Reasoning, More Versatile
    /// </summary>
    public static readonly ChatModel ModelGlm45 = new ChatModel("glm-4.5", LLmProviders.Zai, 128_000);

    /// <summary>
    /// <inheritdoc cref="ModelGlm45"/>
    /// </summary>
    public readonly ChatModel Glm45 = ModelGlm45;

    /// <summary>
    /// GLM-4.5V - Multimodal, Flexible Reasoning, State-of-the-art in its scale
    /// </summary>
    public static readonly ChatModel ModelGlm45V = new ChatModel("glm-4.5v", LLmProviders.Zai, 64_000);

    /// <summary>
    /// <inheritdoc cref="ModelGlm45V"/>
    /// </summary>
    public readonly ChatModel Glm45V = ModelGlm45V;

    /// <summary>
    /// GLM-4.5-X - Good Performance, Strong Reasoning, Ultra-Fast Response
    /// </summary>
    public static readonly ChatModel ModelGlm45X = new ChatModel("glm-4.5-x", LLmProviders.Zai, 128_000);

    /// <summary>
    /// <inheritdoc cref="ModelGlm45X"/>
    /// </summary>
    public readonly ChatModel Glm45X = ModelGlm45X;

    /// <summary>
    /// GLM-4.5-Air - Cost-Effective, Lightweight, High Performance
    /// </summary>
    public static readonly ChatModel ModelGlm45Air = new ChatModel("glm-4.5-air", LLmProviders.Zai, 128_000);

    /// <summary>
    /// <inheritdoc cref="ModelGlm45Air"/>
    /// </summary>
    public readonly ChatModel Glm45Air = ModelGlm45Air;

    /// <summary>
    /// GLM-4.5-AirX - Lightweight, High Performance, Ultra-Fast Response
    /// </summary>
    public static readonly ChatModel ModelGlm45AirX = new ChatModel("glm-4.5-airx", LLmProviders.Zai, 128_000);

    /// <summary>
    /// <inheritdoc cref="ModelGlm45AirX"/>
    /// </summary>
    public readonly ChatModel Glm45AirX = ModelGlm45AirX;

    /// <summary>
    /// GLM-4-32B-0414-128K - High intelligence at unmatched cost-efficiency
    /// </summary>
    public static readonly ChatModel ModelGlm432B = new ChatModel("glm-4-32b-0414-128k", LLmProviders.Zai, 128_000);

    /// <summary>
    /// <inheritdoc cref="ModelGlm432B"/>
    /// </summary>
    public readonly ChatModel Glm432B = ModelGlm432B;

    /// <summary>
    /// GLM-4.5-Flash - Lightweight, High Performance. Free-tier. 200K context.
    /// </summary>
    public static readonly ChatModel ModelGlm45Flash = new ChatModel("glm-4.5-flash", LLmProviders.Zai, 200_000);

    /// <summary>
    /// <inheritdoc cref="ModelGlm45Flash"/>
    /// </summary>
    public readonly ChatModel Glm45Flash = ModelGlm45Flash;

    /// <summary>
    /// AutoGLM-Phone-Multilingual - Mobile intelligent assistant model. 4K max output.
    /// </summary>
    public static readonly ChatModel ModelAutoGlmPhone = new ChatModel("autoglm-phone-multilingual", LLmProviders.Zai, 128_000);

    /// <summary>
    /// <inheritdoc cref="ModelAutoGlmPhone"/>
    /// </summary>
    public readonly ChatModel AutoGlmPhone = ModelAutoGlmPhone;

    /// <summary>
    /// All GLM models from ZAI.
    /// </summary>
    public List<IModel> AllModels => ModelsAll;
    
    /// <summary>
    /// All GLM models from ZAI.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelGlm53,
        ModelGlm53Flash,
        ModelGlm53FlashX,
        ModelGlm52,
        ModelGlm51,
        ModelGlm5,
        ModelGlm47,
        ModelGlm47Flash,
        ModelGlm47FlashX,
        ModelGlm46,
        ModelGlm46V,
        ModelGlm46VFlash,
        ModelGlm46VFlashX,
        ModelGlm45,
        ModelGlm45V,
        ModelGlm45X,
        ModelGlm45Air,
        ModelGlm45AirX,
        ModelGlm432B,
        ModelGlm45Flash,
        ModelAutoGlmPhone
    ]);

    internal ChatModelZaiGlm()
    {
        
    }
}
