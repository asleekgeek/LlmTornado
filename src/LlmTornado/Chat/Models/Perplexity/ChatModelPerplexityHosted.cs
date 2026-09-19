using System;
using System.Collections.Generic;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models.Perplexity;

/// <summary>
/// Perplexity-hosted and first-party open-weight models on the Agent API.
/// </summary>
public class ChatModelPerplexityHosted : IVendorModelClassProvider
{
    /// <summary>
    /// Perplexity Sonar on the Agent API — grounded search without a preset.
    /// </summary>
    public static readonly ChatModel ModelSonar = ChatModelPerplexity.CreateAgentModel("perplexity/sonar", 128_000);

    /// <summary>
    /// <inheritdoc cref="ModelSonar"/>
    /// </summary>
    public readonly ChatModel Sonar = ModelSonar;
    
    /// <summary>
    /// GLM 5.3 — Z.AI's flagship reasoning model.
    /// </summary>
    public static readonly ChatModel ModelGlm53 = ChatModelPerplexity.CreateAgentModel("perplexity/glm-5.3", 202_752);

    /// <summary>
    /// <inheritdoc cref="ModelGlm53"/>
    /// </summary>
    public readonly ChatModel Glm53 = ModelGlm53;
    
    /// <summary>
    /// GLM 5.3 Flash — faster, cheaper GLM 5.3.
    /// </summary>
    public static readonly ChatModel ModelGlm53Flash = ChatModelPerplexity.CreateAgentModel("perplexity/glm-5.3-flash", 202_752);

    /// <summary>
    /// <inheritdoc cref="ModelGlm53Flash"/>
    /// </summary>
    public readonly ChatModel Glm53Flash = ModelGlm53Flash;
    
    /// <summary>
    /// Kimi K3 — Moonshot AI's flagship reasoning model. Accepts minimal, low, medium, high, xhigh, and max reasoning effort.
    /// </summary>
    public static readonly ChatModel ModelKimiK3 = ChatModelPerplexity.CreateAgentModel("perplexity/kimi-k3", 256_000);

    /// <summary>
    /// <inheritdoc cref="ModelKimiK3"/>
    /// </summary>
    public readonly ChatModel KimiK3 = ModelKimiK3;
    
    /// <summary>
    /// Kimi K2.7 Code — Moonshot AI coding and agentic model.
    /// </summary>
    public static readonly ChatModel ModelKimiK27Code = ChatModelPerplexity.CreateAgentModel("perplexity/kimi-k2.7-code", 256_000);

    /// <summary>
    /// <inheritdoc cref="ModelKimiK27Code"/>
    /// </summary>
    public readonly ChatModel KimiK27Code = ModelKimiK27Code;
    
    /// <summary>
    /// NVIDIA Nemotron 3 Ultra 550B.
    /// </summary>
    public static readonly ChatModel ModelNemotron3Ultra = ChatModelPerplexity.CreateAgentModel("perplexity/nemotron-3-ultra-550b-a55b", 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelNemotron3Ultra"/>
    /// </summary>
    public readonly ChatModel Nemotron3Ultra = ModelNemotron3Ultra;
    
    /// <summary>
    /// NVIDIA Nemotron 3.5 Lightning 30B — fast open-weight reasoning model.
    /// </summary>
    public static readonly ChatModel ModelNemotron35Lightning = ChatModelPerplexity.CreateAgentModel("perplexity/nemotron-3.5-lightning-30b-a3b", 262_144);

    /// <summary>
    /// <inheritdoc cref="ModelNemotron35Lightning"/>
    /// </summary>
    public readonly ChatModel Nemotron35Lightning = ModelNemotron35Lightning;
    
    /// <summary>
    /// NVIDIA Nemotron 3 Super 120B.
    /// </summary>
    public static readonly ChatModel ModelNemotron3Super = ChatModelPerplexity.CreateAgentModel("nvidia/nemotron-3-super-120b-a12b", 262_144);

    /// <summary>
    /// <inheritdoc cref="ModelNemotron3Super"/>
    /// </summary>
    public readonly ChatModel Nemotron3Super = ModelNemotron3Super;
    
    /// <summary>
    /// DeepSeek V4 Flash 0731 — fast open reasoning model with a 1M-token context window.
    /// </summary>
    public static readonly ChatModel ModelDeepSeekV4Flash = ChatModelPerplexity.CreateAgentModel("perplexity/deepseek-v4-flash-0731", 1_000_000);

    /// <summary>
    /// <inheritdoc cref="ModelDeepSeekV4Flash"/>
    /// </summary>
    public readonly ChatModel DeepSeekV4Flash = ModelDeepSeekV4Flash;
    
    /// <summary>
    /// All known Perplexity-hosted Agent API models.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelSonar, ModelGlm53, ModelGlm53Flash, ModelKimiK3, ModelKimiK27Code,
        ModelNemotron3Ultra, ModelNemotron35Lightning, ModelNemotron3Super, ModelDeepSeekV4Flash
    ]);
    
    /// <inheritdoc />
    public List<IModel> AllModels => ModelsAll;
    
    internal ChatModelPerplexityHosted()
    {
        
    }
}
