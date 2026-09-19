using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models;

/// <summary>
/// Aya class models from Cohere.
/// </summary>
public class ChatModelCohereAya : IVendorModelClassProvider
{
    /// <summary>
    /// Tiny Aya Global is a 3.35B instruction-tuned multilingual model with the best balance across languages and regions. Supports 70 languages.
    /// </summary>
    public static readonly ChatModel ModelTinyGlobal = new ChatModel("tiny-aya-global", LLmProviders.Cohere, 8_000);
    
    /// <summary>
    /// <inheritdoc cref="ModelTinyGlobal"/>
    /// </summary>
    public readonly ChatModel TinyGlobal = ModelTinyGlobal;
    
    /// <summary>
    /// Tiny Aya Earth is a 3.35B region-specialized multilingual model, best for West Asian and African languages. Supports 70 languages.
    /// </summary>
    public static readonly ChatModel ModelTinyEarth = new ChatModel("tiny-aya-earth", LLmProviders.Cohere, 8_000);
    
    /// <summary>
    /// <inheritdoc cref="ModelTinyEarth"/>
    /// </summary>
    public readonly ChatModel TinyEarth = ModelTinyEarth;
    
    /// <summary>
    /// Tiny Aya Fire is a 3.35B region-specialized multilingual model, best for South Asian languages. Supports 70 languages.
    /// </summary>
    public static readonly ChatModel ModelTinyFire = new ChatModel("tiny-aya-fire", LLmProviders.Cohere, 8_000);
    
    /// <summary>
    /// <inheritdoc cref="ModelTinyFire"/>
    /// </summary>
    public readonly ChatModel TinyFire = ModelTinyFire;
    
    /// <summary>
    /// Tiny Aya Water is a 3.35B region-specialized multilingual model, best for European and Asia-Pacific languages. Supports 70 languages.
    /// </summary>
    public static readonly ChatModel ModelTinyWater = new ChatModel("tiny-aya-water", LLmProviders.Cohere, 8_000);
    
    /// <summary>
    /// <inheritdoc cref="ModelTinyWater"/>
    /// </summary>
    public readonly ChatModel TinyWater = ModelTinyWater;
    
    /// <summary>
    /// Aya Vision is a state-of-the-art multimodal model excelling at a variety of critical benchmarks for language, text, and image capabilities. This 8 billion parameter variant is focused on low latency and best-in-class performance. Supports 23 languages.
    /// </summary>
    public static readonly ChatModel ModelVision8B = new ChatModel("c4ai-aya-vision-8b", LLmProviders.Cohere, 16_384);
    
    /// <summary>
    /// <inheritdoc cref="ModelVision8B"/>
    /// </summary>
    public readonly ChatModel Vision8B = ModelVision8B;
    
    /// <summary>
    /// Aya Vision is a state-of-the-art multimodal model excelling at a variety of critical benchmarks for language, text, and image capabilities. Serves 23 languages. This 32 billion parameter variant is focused on state-of-art multilingual performance. Supports 23 languages.
    /// </summary>
    public static readonly ChatModel ModelVision32B = new ChatModel("c4ai-aya-vision-32b", LLmProviders.Cohere, 16_384);
    
    /// <summary>
    /// <inheritdoc cref="ModelVision32B"/>
    /// </summary>
    public readonly ChatModel Vision32B = ModelVision32B;
    
    /// <summary>
    /// Aya Expanse is a highly performant 8B multilingual model, designed to rival monolingual performance through innovations in instruction tuning with data arbitrage, preference training, and model merging. Serves 23 languages.
    /// </summary>
    public static readonly ChatModel ModelExpanse8B = new ChatModel("c4ai-aya-expanse-8b", LLmProviders.Cohere, 8_196);
    
    /// <summary>
    /// <inheritdoc cref="ModelExpanse8B"/>
    /// </summary>
    public readonly ChatModel Expanse8B = ModelExpanse8B;

    /// <summary>
    /// Aya Expanse is a highly performant 32B multilingual model, designed to rival monolingual performance through innovations in instruction tuning with data arbitrage, preference training, and model merging. Serves 23 languages.
    /// </summary>
    public static readonly ChatModel ModelExpanse32B = new ChatModel("c4ai-aya-expanse-32b", LLmProviders.Cohere, 128_000);
    
    /// <summary>
    /// <inheritdoc cref="ModelExpanse32B"/>
    /// </summary>
    public readonly ChatModel Expanse32B = ModelExpanse32B;
    
    /// <summary>
    /// All known Aya models from Cohere.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [ModelTinyGlobal, ModelTinyEarth, ModelTinyFire, ModelTinyWater, ModelExpanse8B, ModelExpanse32B, ModelVision8B, ModelVision32B]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;

    internal ChatModelCohereAya()
    {

    }
}