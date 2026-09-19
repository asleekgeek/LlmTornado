using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models.Alibaba;

/// <summary>
/// Third-party models hosted on Alibaba Cloud Model Studio.
/// </summary>
public class ChatModelAlibabaThirdParty : IVendorModelClassProvider
{
    /// <summary>
    /// DeepSeek-V4-Pro-0813 - 1.6T MoE flagship with 1M context
    /// </summary>
    public static readonly ChatModel ModelDeepSeekV4Pro0813 = new ChatModel("deepseek-v4-pro-0813", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelDeepSeekV4Pro0813"/>
    /// </summary>
    public readonly ChatModel DeepSeekV4Pro0813 = ModelDeepSeekV4Pro0813;

    /// <summary>
    /// DeepSeek-V4-Pro - Flagship MoE with thinking, function calling, and 1M context
    /// </summary>
    public static readonly ChatModel ModelDeepSeekV4Pro = new ChatModel("deepseek-v4-pro", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelDeepSeekV4Pro"/>
    /// </summary>
    public readonly ChatModel DeepSeekV4Pro = ModelDeepSeekV4Pro;

    /// <summary>
    /// DeepSeek-V4.1-Flash - Lightweight 552B MoE with native vision and 1M context
    /// </summary>
    public static readonly ChatModel ModelDeepSeekV41Flash = new ChatModel("deepseek-v4.1-flash", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelDeepSeekV41Flash"/>
    /// </summary>
    public readonly ChatModel DeepSeekV41Flash = ModelDeepSeekV41Flash;

    /// <summary>
    /// DeepSeek-V4-Flash - Cost-efficient MoE with 1M context
    /// </summary>
    public static readonly ChatModel ModelDeepSeekV4Flash = new ChatModel("deepseek-v4-flash", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelDeepSeekV4Flash"/>
    /// </summary>
    public readonly ChatModel DeepSeekV4Flash = ModelDeepSeekV4Flash;

    /// <summary>
    /// GLM-5.3 - Z.AI flagship for coding and long-horizon agents, 1M context
    /// </summary>
    public static readonly ChatModel ModelGlm53 = new ChatModel("glm-5.3", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelGlm53"/>
    /// </summary>
    public readonly ChatModel Glm53 = ModelGlm53;

    /// <summary>
    /// ZHIPU/GLM-5.3 - Direct-supply GLM-5.3 on Model Studio
    /// </summary>
    public static readonly ChatModel ModelZhipuGlm53 = new ChatModel("ZHIPU/GLM-5.3", LLmProviders.Alibaba, 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelZhipuGlm53"/>
    /// </summary>
    public readonly ChatModel ZhipuGlm53 = ModelZhipuGlm53;

    /// <summary>
    /// GLM-5.2 - Long-horizon flagship, 198k context
    /// </summary>
    public static readonly ChatModel ModelGlm52 = new ChatModel("glm-5.2", LLmProviders.Alibaba, 198_000);

    /// <summary>
    /// <inheritdoc cref="ModelGlm52"/>
    /// </summary>
    public readonly ChatModel Glm52 = ModelGlm52;

    /// <summary>
    /// Kimi-K3 - Moonshot flagship with preserved thinking, text and image input
    /// </summary>
    public static readonly ChatModel ModelKimiK3 = new ChatModel("kimi-k3", LLmProviders.Alibaba, 256_000);

    /// <summary>
    /// <inheritdoc cref="ModelKimiK3"/>
    /// </summary>
    public readonly ChatModel KimiK3 = ModelKimiK3;

    /// <summary>
    /// Kimi-K2.7-Code - Agent-centric coding model, thinking only
    /// </summary>
    public static readonly ChatModel ModelKimiK27Code = new ChatModel("kimi-k2.7-code", LLmProviders.Alibaba, 256_000);

    /// <summary>
    /// <inheritdoc cref="ModelKimiK27Code"/>
    /// </summary>
    public readonly ChatModel KimiK27Code = ModelKimiK27Code;

    /// <summary>
    /// MiniMax-M2.5 - Lightweight MiniMax model, 192k context
    /// </summary>
    public static readonly ChatModel ModelMiniMaxM25 = new ChatModel("MiniMax-M2.5", LLmProviders.Alibaba, 192_000);

    /// <summary>
    /// <inheritdoc cref="ModelMiniMaxM25"/>
    /// </summary>
    public readonly ChatModel MiniMaxM25 = ModelMiniMaxM25;

    /// <summary>
    /// All known third-party models hosted by Alibaba.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelDeepSeekV4Pro0813, ModelDeepSeekV4Pro, ModelDeepSeekV41Flash, ModelDeepSeekV4Flash,
        ModelGlm53, ModelZhipuGlm53, ModelGlm52, ModelKimiK3, ModelKimiK27Code, ModelMiniMaxM25
    ]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;

    internal ChatModelAlibabaThirdParty()
    {
    }
}
