using System;
using System.Collections.Generic;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models.Perplexity;

/// <summary>
/// Google models available through the Perplexity Agent API.
/// </summary>
public class ChatModelPerplexityGoogle : IVendorModelClassProvider
{
    /// <summary>
    /// Gemini 3.1 Pro Preview — long-context Gemini 3 Pro.
    /// </summary>
    public static readonly ChatModel ModelGemini31ProPreview = ChatModelPerplexity.CreateAgentModel("google/gemini-3.1-pro-preview", 1_048_576);

    /// <summary>
    /// <inheritdoc cref="ModelGemini31ProPreview"/>
    /// </summary>
    public readonly ChatModel Gemini31ProPreview = ModelGemini31ProPreview;
    
    /// <summary>
    /// Gemini 3.1 Flash Lite — cost-efficient Gemini 3.1.
    /// </summary>
    public static readonly ChatModel ModelGemini31FlashLite = ChatModelPerplexity.CreateAgentModel("google/gemini-3.1-flash-lite", 1_048_576);

    /// <summary>
    /// <inheritdoc cref="ModelGemini31FlashLite"/>
    /// </summary>
    public readonly ChatModel Gemini31FlashLite = ModelGemini31FlashLite;
    
    /// <summary>
    /// Gemini 3.5 Flash — fast multimodal Gemini 3.5.
    /// </summary>
    public static readonly ChatModel ModelGemini35Flash = ChatModelPerplexity.CreateAgentModel("google/gemini-3.5-flash", 1_048_576);

    /// <summary>
    /// <inheritdoc cref="ModelGemini35Flash"/>
    /// </summary>
    public readonly ChatModel Gemini35Flash = ModelGemini35Flash;
    
    /// <summary>
    /// Gemini 3.5 Flash Lite.
    /// </summary>
    public static readonly ChatModel ModelGemini35FlashLite = ChatModelPerplexity.CreateAgentModel("google/gemini-3.5-flash-lite", 1_048_576);

    /// <summary>
    /// <inheritdoc cref="ModelGemini35FlashLite"/>
    /// </summary>
    public readonly ChatModel Gemini35FlashLite = ModelGemini35FlashLite;
    
    /// <summary>
    /// Gemini 3.6 Flash.
    /// </summary>
    public static readonly ChatModel ModelGemini36Flash = ChatModelPerplexity.CreateAgentModel("google/gemini-3.6-flash", 1_048_576);

    /// <summary>
    /// <inheritdoc cref="ModelGemini36Flash"/>
    /// </summary>
    public readonly ChatModel Gemini36Flash = ModelGemini36Flash;
    
    /// <summary>
    /// Gemini 3.7 Flash.
    /// </summary>
    public static readonly ChatModel ModelGemini37Flash = ChatModelPerplexity.CreateAgentModel("google/gemini-3.7-flash", 1_048_576);

    /// <summary>
    /// <inheritdoc cref="ModelGemini37Flash"/>
    /// </summary>
    public readonly ChatModel Gemini37Flash = ModelGemini37Flash;
    
    /// <summary>
    /// Gemini 3.8 Flash.
    /// </summary>
    public static readonly ChatModel ModelGemini38Flash = ChatModelPerplexity.CreateAgentModel("google/gemini-3.8-flash", 1_048_576);

    /// <summary>
    /// <inheritdoc cref="ModelGemini38Flash"/>
    /// </summary>
    public readonly ChatModel Gemini38Flash = ModelGemini38Flash;
    
    /// <summary>
    /// Gemini 3.0 Flash Preview.
    /// </summary>
    public static readonly ChatModel ModelGemini3FlashPreview = ChatModelPerplexity.CreateAgentModel("google/gemini-3-flash-preview", 1_048_576);

    /// <summary>
    /// <inheritdoc cref="ModelGemini3FlashPreview"/>
    /// </summary>
    public readonly ChatModel Gemini3FlashPreview = ModelGemini3FlashPreview;
    
    /// <summary>
    /// All known Google models on the Perplexity Agent API.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelGemini31ProPreview, ModelGemini31FlashLite, ModelGemini35Flash, ModelGemini35FlashLite,
        ModelGemini36Flash, ModelGemini37Flash, ModelGemini38Flash, ModelGemini3FlashPreview
    ]);
    
    /// <inheritdoc />
    public List<IModel> AllModels => ModelsAll;
    
    internal ChatModelPerplexityGoogle()
    {
        
    }
}
