using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models.MoonshotAi;

/// <summary>
/// All models from Moonshot AI.
/// </summary>
public class ChatModelMoonshotAiModels : IVendorModelClassProvider
{
    /// <summary>
    /// kimi-k3 — Kimi's flagship 2.8T model for long-horizon coding, knowledge work, and deep reasoning.
    /// Native visual and video understanding, always-on thinking, and a 1M-token context window.
    /// Configure reasoning with <see cref="ChatReasoningEfforts"/> values Low, High, and Max (default Max).
    /// </summary>
    public static readonly ChatModel ModelKimiK3 = new ChatModel("kimi-k3", LLmProviders.MoonshotAi, 1_048_576)
    {
        EndpointCapabilities = [ ChatModelEndpointCapabilities.Chat, ChatModelEndpointCapabilities.Responses, ChatModelEndpointCapabilities.Batch ]
    };
    
    /// <summary>
    /// <inheritdoc cref="ModelKimiK3"/>
    /// </summary>
    public readonly ChatModel KimiK3 = ModelKimiK3;
    
    /// <summary>
    /// kimi-k2.7-code — Kimi's dedicated coding model with 256K context, multimodal input, and always-on thinking.
    /// </summary>
    public static readonly ChatModel ModelKimiK27Code = new ChatModel("kimi-k2.7-code", LLmProviders.MoonshotAi, 262_144)
    {
        EndpointCapabilities = [ ChatModelEndpointCapabilities.Chat, ChatModelEndpointCapabilities.Responses, ChatModelEndpointCapabilities.Batch ]
    };
    
    /// <summary>
    /// <inheritdoc cref="ModelKimiK27Code"/>
    /// </summary>
    public readonly ChatModel KimiK27Code = ModelKimiK27Code;
    
    /// <summary>
    /// kimi-k2.7-code-highspeed — High-speed variant of Kimi K2.7 Code (~180 tok/s, up to 260 tok/s in short context).
    /// Same capabilities and parameter constraints as <see cref="ModelKimiK27Code"/>.
    /// </summary>
    public static readonly ChatModel ModelKimiK27CodeHighspeed = new ChatModel("kimi-k2.7-code-highspeed", LLmProviders.MoonshotAi, 262_144)
    {
        EndpointCapabilities = [ ChatModelEndpointCapabilities.Chat, ChatModelEndpointCapabilities.Responses, ChatModelEndpointCapabilities.Batch ]
    };
    
    /// <summary>
    /// <inheritdoc cref="ModelKimiK27CodeHighspeed"/>
    /// </summary>
    public readonly ChatModel KimiK27CodeHighspeed = ModelKimiK27CodeHighspeed;
    
    /// <summary>
    /// kimi-k2.6 — General-purpose multimodal model with 256K context, thinking and non-thinking modes,
    /// plus text, image, and video input. Disable thinking with <see cref="LlmTornado.Chat.ChatRequest.ReasoningBudget"/> = 0
    /// or <see cref="ChatReasoningEfforts.None"/>.
    /// </summary>
    public static readonly ChatModel ModelKimiK26 = new ChatModel("kimi-k2.6", LLmProviders.MoonshotAi, 262_144)
    {
        EndpointCapabilities = [ ChatModelEndpointCapabilities.Chat, ChatModelEndpointCapabilities.Responses, ChatModelEndpointCapabilities.Batch ]
    };
    
    /// <summary>
    /// <inheritdoc cref="ModelKimiK26"/>
    /// </summary>
    public readonly ChatModel KimiK26 = ModelKimiK26;
    
    /// <summary>
    /// kimi-k2.5 — Discontinued 31 Aug 2026. Prefer <see cref="ModelKimiK3"/>.
    /// Native multimodal support, thinking mode, and 256K context.
    /// </summary>
    public static readonly ChatModel ModelKimiK25 = new ChatModel("kimi-k2.5", LLmProviders.MoonshotAi, 262_144);
    
    /// <summary>
    /// <inheritdoc cref="ModelKimiK25"/>
    /// </summary>
    public readonly ChatModel KimiK25 = ModelKimiK25;
    
    /// <summary>
    /// kimi-k2-0905-preview
    /// </summary>
    public static readonly ChatModel ModelKimiK20905Preview = new ChatModel("kimi-k2-0905-preview", LLmProviders.MoonshotAi, 262_144);
    
    /// <summary>
    /// <inheritdoc cref="ModelKimiK20905Preview"/>
    /// </summary>
    public readonly ChatModel KimiK20905Preview = ModelKimiK20905Preview;
    
    /// <summary>
    /// kimi-k2-0711-preview
    /// </summary>
    public static readonly ChatModel ModelKimiK20711Preview = new ChatModel("kimi-k2-0711-preview", LLmProviders.MoonshotAi, 131_072);
    
    /// <summary>
    /// <inheritdoc cref="ModelKimiK20711Preview"/>
    /// </summary>
    public readonly ChatModel KimiK20711Preview = ModelKimiK20711Preview;
    
    /// <summary>
    /// kimi-k2-turbo-preview
    /// </summary>
    public static readonly ChatModel ModelKimiK2TurboPreview = new ChatModel("kimi-k2-turbo-preview", LLmProviders.MoonshotAi, 262_144);
    
    /// <summary>
    /// <inheritdoc cref="ModelKimiK2TurboPreview"/>
    /// </summary>
    public readonly ChatModel KimiK2TurboPreview = ModelKimiK2TurboPreview;
    
    /// <summary>
    /// kimi-k2-thinking
    /// </summary>
    public static readonly ChatModel ModelKimiK2Thinking = new ChatModel("kimi-k2-thinking", LLmProviders.MoonshotAi, 262_144);
    
    /// <summary>
    /// <inheritdoc cref="ModelKimiK2Thinking"/>
    /// </summary>
    public readonly ChatModel KimiK2Thinking = ModelKimiK2Thinking;
    
    /// <summary>
    /// kimi-k2-thinking-turbo
    /// </summary>
    public static readonly ChatModel ModelKimiK2ThinkingTurbo = new ChatModel("kimi-k2-thinking-turbo", LLmProviders.MoonshotAi, 262_144);
    
    /// <summary>
    /// <inheritdoc cref="ModelKimiK2ThinkingTurbo"/>
    /// </summary>
    public readonly ChatModel KimiK2ThinkingTurbo = ModelKimiK2ThinkingTurbo;
    
    /// <summary>
    /// moonshot-v1-8k
    /// </summary>
    public static readonly ChatModel ModelMoonshotV18k = new ChatModel("moonshot-v1-8k", LLmProviders.MoonshotAi, 8_192);
    
    /// <summary>
    /// <inheritdoc cref="ModelMoonshotV18k"/>
    /// </summary>
    public readonly ChatModel MoonshotV18k = ModelMoonshotV18k;
    
    /// <summary>
    /// moonshot-v1-32k
    /// </summary>
    public static readonly ChatModel ModelMoonshotV132k = new ChatModel("moonshot-v1-32k", LLmProviders.MoonshotAi, 32_768);
    
    /// <summary>
    /// <inheritdoc cref="ModelMoonshotV132k"/>
    /// </summary>
    public readonly ChatModel MoonshotV132k = ModelMoonshotV132k;
    
    /// <summary>
    /// moonshot-v1-128k
    /// </summary>
    public static readonly ChatModel ModelMoonshotV1128k = new ChatModel("moonshot-v1-128k", LLmProviders.MoonshotAi, 131_072);
    
    /// <summary>
    /// <inheritdoc cref="ModelMoonshotV1128k"/>
    /// </summary>
    public readonly ChatModel MoonshotV1128k = ModelMoonshotV1128k;
    
    /// <summary>
    /// moonshot-v1-auto
    /// </summary>
    public static readonly ChatModel ModelMoonshotV1Auto = new ChatModel("moonshot-v1-auto", LLmProviders.MoonshotAi, 131_072);
    
    /// <summary>
    /// <inheritdoc cref="ModelMoonshotV1Auto"/>
    /// </summary>
    public readonly ChatModel MoonshotV1Auto = ModelMoonshotV1Auto;
    
    /// <summary>
    /// kimi-latest
    /// </summary>
    public static readonly ChatModel ModelKimiLatest = new ChatModel("kimi-latest", LLmProviders.MoonshotAi, 131_072);
    
    /// <summary>
    /// <inheritdoc cref="ModelKimiLatest"/>
    /// </summary>
    public readonly ChatModel KimiLatest = ModelKimiLatest;
    
    /// <summary>
    /// kimi-latest-8k
    /// </summary>
    public static readonly ChatModel ModelKimiLatest8k = new ChatModel("kimi-latest-8k", LLmProviders.MoonshotAi, 8_192);
    
    /// <summary>
    /// <inheritdoc cref="ModelKimiLatest8k"/>
    /// </summary>
    public readonly ChatModel KimiLatest8k = ModelKimiLatest8k;
    
    /// <summary>
    /// kimi-latest-32k
    /// </summary>
    public static readonly ChatModel ModelKimiLatest32k = new ChatModel("kimi-latest-32k", LLmProviders.MoonshotAi, 32_768);
    
    /// <summary>
    /// <inheritdoc cref="ModelKimiLatest32k"/>
    /// </summary>
    public readonly ChatModel KimiLatest32k = ModelKimiLatest32k;
    
    /// <summary>
    /// kimi-latest-128k
    /// </summary>
    public static readonly ChatModel ModelKimiLatest128k = new ChatModel("kimi-latest-128k", LLmProviders.MoonshotAi, 131_072);
    
    /// <summary>
    /// <inheritdoc cref="ModelKimiLatest128k"/>
    /// </summary>
    public readonly ChatModel KimiLatest128k = ModelKimiLatest128k;
    
    /// <summary>
    /// moonshot-v1-8k-vision-preview
    /// </summary>
    public static readonly ChatModel ModelMoonshotV18kVisionPreview = new ChatModel("moonshot-v1-8k-vision-preview", LLmProviders.MoonshotAi, 8_192);
    
    /// <summary>
    /// <inheritdoc cref="ModelMoonshotV18kVisionPreview"/>
    /// </summary>
    public readonly ChatModel MoonshotV18kVisionPreview = ModelMoonshotV18kVisionPreview;
    
    /// <summary>
    /// moonshot-v1-32k-vision-preview
    /// </summary>
    public static readonly ChatModel ModelMoonshotV132kVisionPreview = new ChatModel("moonshot-v1-32k-vision-preview", LLmProviders.MoonshotAi, 32_768);
    
    /// <summary>
    /// <inheritdoc cref="ModelMoonshotV132kVisionPreview"/>
    /// </summary>
    public readonly ChatModel MoonshotV132kVisionPreview = ModelMoonshotV132kVisionPreview;
    
    /// <summary>
    /// moonshot-v1-128k-vision-preview
    /// </summary>
    public static readonly ChatModel ModelMoonshotV1128kVisionPreview = new ChatModel("moonshot-v1-128k-vision-preview", LLmProviders.MoonshotAi, 131_072);
    
    /// <summary>
    /// <inheritdoc cref="ModelMoonshotV1128kVisionPreview"/>
    /// </summary>
    public readonly ChatModel MoonshotV1128kVisionPreview = ModelMoonshotV1128kVisionPreview;
    
    /// <summary>
    /// kimi-thinking-preview
    /// </summary>
    public static readonly ChatModel ModelKimiThinkingPreview = new ChatModel("kimi-thinking-preview", LLmProviders.MoonshotAi, 131_072);
    
    /// <summary>
    /// <inheritdoc cref="ModelKimiThinkingPreview"/>
    /// </summary>
    public readonly ChatModel KimiThinkingPreview = ModelKimiThinkingPreview;
    
    /// <summary>
    /// All known models from Moonshot AI.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelKimiK3,
        ModelKimiK27Code,
        ModelKimiK27CodeHighspeed,
        ModelKimiK26,
        ModelKimiK25,
        ModelKimiK20905Preview,
        ModelKimiK20711Preview,
        ModelKimiK2TurboPreview,
        ModelKimiK2Thinking,
        ModelKimiK2ThinkingTurbo,
        ModelMoonshotV18k,
        ModelMoonshotV132k,
        ModelMoonshotV1128k,
        ModelMoonshotV1Auto,
        ModelKimiLatest,
        ModelKimiLatest8k,
        ModelKimiLatest32k,
        ModelKimiLatest128k,
        ModelMoonshotV18kVisionPreview,
        ModelMoonshotV132kVisionPreview,
        ModelMoonshotV1128kVisionPreview,
        ModelKimiThinkingPreview
    ]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;

    internal ChatModelMoonshotAiModels()
    {

    }

    internal static bool IsK3(string? modelName)
    {
        return modelName?.Contains("kimi-k3", StringComparison.OrdinalIgnoreCase) == true;
    }

    internal static bool IsK27(string? modelName)
    {
        return modelName?.Contains("k2.7", StringComparison.OrdinalIgnoreCase) == true;
    }

    internal static bool IsK26(string? modelName)
    {
        return modelName?.Contains("k2.6", StringComparison.OrdinalIgnoreCase) == true;
    }

    internal static bool IsK25(string? modelName)
    {
        return modelName?.Contains("k2.5", StringComparison.OrdinalIgnoreCase) == true;
    }

    internal static bool UsesFixedSampling(string? modelName)
    {
        return IsK3(modelName) || IsK27(modelName) || IsK26(modelName) || IsK25(modelName);
    }

    internal static bool SupportsThinkingToggle(string? modelName)
    {
        return IsK26(modelName) || IsK25(modelName);
    }
}