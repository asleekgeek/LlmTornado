using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models;

/// <summary>
/// North class models from Cohere. Purpose-built generative models available on the Chat endpoint.
/// </summary>
public class ChatModelCohereNorth : IVendorModelClassProvider
{
    /// <summary>
    /// North Small Translate is a 218B total / 25B active parameter MoE model purpose-built for machine translation across more than 50 languages.
    /// </summary>
    public static readonly ChatModel ModelSmallTranslate = new ChatModel("north-small-translate-1-0", LLmProviders.Cohere, 16_000);
    
    /// <summary>
    /// <inheritdoc cref="ModelSmallTranslate"/>
    /// </summary>
    public readonly ChatModel SmallTranslate = ModelSmallTranslate;
    
    /// <summary>
    /// North Mini Code is a 30B total / 3B active parameter MoE model trained for agentic coding. 256K context, 64K max output.
    /// </summary>
    public static readonly ChatModel ModelMiniCode = new ChatModel("north-mini-code-1-0", LLmProviders.Cohere, 256_000);
    
    /// <summary>
    /// <inheritdoc cref="ModelMiniCode"/>
    /// </summary>
    public readonly ChatModel MiniCode = ModelMiniCode;
    
    /// <summary>
    /// All known North models from Cohere.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [ModelSmallTranslate, ModelMiniCode]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;

    internal ChatModelCohereNorth()
    {

    }
}
