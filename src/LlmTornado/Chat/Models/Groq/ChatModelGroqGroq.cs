using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models;

/// <summary>
/// Groq systems hosted by Groq (Compound agentic systems).
/// </summary>
public class ChatModelGroqGroq : IVendorModelClassProvider
{
    /// <summary>
    /// groq/compound
    /// Production Compound system with built-in web search, code execution, visit website, and Wolfram Alpha.
    /// Multiple tool calls per request. 131K context, 8K max output.
    /// </summary>
    public static readonly ChatModel ModelCompound = new ChatModel("groq-compound", LLmProviders.Groq, 131_072)
    {
        ApiName = "groq/compound",
        EndpointCapabilities = ChatModelGroq.ChatResponses
    };
    
    /// <summary>
    /// <inheritdoc cref="ModelCompound"/>
    /// </summary>
    public readonly ChatModel Compound = ModelCompound;
    
    /// <summary>
    /// groq/compound-mini
    /// Production Compound Mini system. Single tool call per request, ~3x lower latency than Compound.
    /// 131K context, 8K max output.
    /// </summary>
    public static readonly ChatModel ModelCompoundMini = new ChatModel("groq-compound-mini", LLmProviders.Groq, 131_072)
    {
        ApiName = "groq/compound-mini",
        EndpointCapabilities = ChatModelGroq.ChatResponses
    };
    
    /// <summary>
    /// <inheritdoc cref="ModelCompoundMini"/>
    /// </summary>
    public readonly ChatModel CompoundMini = ModelCompoundMini;
    
    /// <summary>
    /// compound-beta
    /// Legacy Compound Beta identifier. Prefer <see cref="ModelCompound"/>.
    /// </summary>
    public static readonly ChatModel ModelCompoundBeta = new ChatModel("groq-compound-beta", LLmProviders.Groq, 131_072)
    {
        ApiName = "compound-beta",
        EndpointCapabilities = ChatModelGroq.ChatOnly
    };
    
    /// <summary>
    /// <inheritdoc cref="ModelCompoundBeta"/>
    /// </summary>
    public readonly ChatModel CompoundBeta = ModelCompoundBeta;
    
    /// <summary>
    /// compound-beta-mini
    /// Legacy Compound Beta Mini identifier. Prefer <see cref="ModelCompoundMini"/>.
    /// </summary>
    public static readonly ChatModel ModelCompoundBetaMini = new ChatModel("groq-compound-beta-mini", LLmProviders.Groq, 131_072)
    {
        ApiName = "compound-beta-mini",
        EndpointCapabilities = ChatModelGroq.ChatOnly
    };
    
    /// <summary>
    /// <inheritdoc cref="ModelCompoundBetaMini"/>
    /// </summary>
    public readonly ChatModel CompoundBetaMini = ModelCompoundBetaMini;
    
    /// <summary>
    /// All known Groq-hosted systems.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelCompound, ModelCompoundMini, ModelCompoundBeta, ModelCompoundBetaMini
    ]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;

    internal ChatModelGroqGroq()
    {

    }
}
