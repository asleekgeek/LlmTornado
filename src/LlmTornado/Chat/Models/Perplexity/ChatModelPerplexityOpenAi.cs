using System;
using System.Collections.Generic;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models.Perplexity;

/// <summary>
/// OpenAI models available through the Perplexity Agent API.
/// </summary>
public class ChatModelPerplexityOpenAi : IVendorModelClassProvider
{
    /// <summary>
    /// GPT-5.6 Sol — flagship GPT-5.6 model for complex reasoning and coding. Supports flex and priority tiers.
    /// </summary>
    public static readonly ChatModel ModelGpt56Sol = ChatModelPerplexity.CreateAgentModel("openai/gpt-5.6-sol", 1_050_000);

    /// <summary>
    /// <inheritdoc cref="ModelGpt56Sol"/>
    /// </summary>
    public readonly ChatModel Gpt56Sol = ModelGpt56Sol;
    
    /// <summary>
    /// GPT-5.6 Terra — balances intelligence and cost. Supports flex and priority tiers.
    /// </summary>
    public static readonly ChatModel ModelGpt56Terra = ChatModelPerplexity.CreateAgentModel("openai/gpt-5.6-terra", 1_050_000);

    /// <summary>
    /// <inheritdoc cref="ModelGpt56Terra"/>
    /// </summary>
    public readonly ChatModel Gpt56Terra = ModelGpt56Terra;
    
    /// <summary>
    /// GPT-5.6 Luna — cost-sensitive, high-volume GPT-5.6. Supports flex and priority tiers. Powers the fast and low presets.
    /// </summary>
    public static readonly ChatModel ModelGpt56Luna = ChatModelPerplexity.CreateAgentModel("openai/gpt-5.6-luna", 1_050_000);

    /// <summary>
    /// <inheritdoc cref="ModelGpt56Luna"/>
    /// </summary>
    public readonly ChatModel Gpt56Luna = ModelGpt56Luna;
    
    /// <summary>
    /// GPT-5.5 frontier model. Supports flex and priority tiers.
    /// </summary>
    public static readonly ChatModel ModelGpt55 = ChatModelPerplexity.CreateAgentModel("openai/gpt-5.5", 1_050_000);

    /// <summary>
    /// <inheritdoc cref="ModelGpt55"/>
    /// </summary>
    public readonly ChatModel Gpt55 = ModelGpt55;
    
    /// <summary>
    /// GPT-5.4. Supports flex and priority tiers.
    /// </summary>
    public static readonly ChatModel ModelGpt54 = ChatModelPerplexity.CreateAgentModel("openai/gpt-5.4", 1_050_000);

    /// <summary>
    /// <inheritdoc cref="ModelGpt54"/>
    /// </summary>
    public readonly ChatModel Gpt54 = ModelGpt54;
    
    /// <summary>
    /// GPT-5.4 Mini. Supports flex and priority tiers.
    /// </summary>
    public static readonly ChatModel ModelGpt54Mini = ChatModelPerplexity.CreateAgentModel("openai/gpt-5.4-mini", 400_000);

    /// <summary>
    /// <inheritdoc cref="ModelGpt54Mini"/>
    /// </summary>
    public readonly ChatModel Gpt54Mini = ModelGpt54Mini;
    
    /// <summary>
    /// GPT-5.4 Nano. Supports flex and priority tiers.
    /// </summary>
    public static readonly ChatModel ModelGpt54Nano = ChatModelPerplexity.CreateAgentModel("openai/gpt-5.4-nano", 400_000);

    /// <summary>
    /// <inheritdoc cref="ModelGpt54Nano"/>
    /// </summary>
    public readonly ChatModel Gpt54Nano = ModelGpt54Nano;
    
    /// <summary>
    /// GPT-5.2. Supports flex and priority tiers.
    /// </summary>
    public static readonly ChatModel ModelGpt52 = ChatModelPerplexity.CreateAgentModel("openai/gpt-5.2", 400_000);

    /// <summary>
    /// <inheritdoc cref="ModelGpt52"/>
    /// </summary>
    public readonly ChatModel Gpt52 = ModelGpt52;
    
    /// <summary>
    /// GPT-5.1. Supports flex and priority tiers.
    /// </summary>
    public static readonly ChatModel ModelGpt51 = ChatModelPerplexity.CreateAgentModel("openai/gpt-5.1", 400_000);

    /// <summary>
    /// <inheritdoc cref="ModelGpt51"/>
    /// </summary>
    public readonly ChatModel Gpt51 = ModelGpt51;
    
    /// <summary>
    /// GPT-5. Supports flex and priority tiers.
    /// </summary>
    public static readonly ChatModel ModelGpt5 = ChatModelPerplexity.CreateAgentModel("openai/gpt-5", 400_000);

    /// <summary>
    /// <inheritdoc cref="ModelGpt5"/>
    /// </summary>
    public readonly ChatModel Gpt5 = ModelGpt5;
    
    /// <summary>
    /// GPT-5 Mini. Supports flex and priority tiers.
    /// </summary>
    public static readonly ChatModel ModelGpt5Mini = ChatModelPerplexity.CreateAgentModel("openai/gpt-5-mini", 400_000);

    /// <summary>
    /// <inheritdoc cref="ModelGpt5Mini"/>
    /// </summary>
    public readonly ChatModel Gpt5Mini = ModelGpt5Mini;
    
    /// <summary>
    /// All known OpenAI models on the Perplexity Agent API.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelGpt56Sol, ModelGpt56Terra, ModelGpt56Luna, ModelGpt55, ModelGpt54, ModelGpt54Mini, ModelGpt54Nano,
        ModelGpt52, ModelGpt51, ModelGpt5, ModelGpt5Mini
    ]);
    
    /// <inheritdoc />
    public List<IModel> AllModels => ModelsAll;
    
    internal ChatModelPerplexityOpenAi()
    {
        
    }
}
