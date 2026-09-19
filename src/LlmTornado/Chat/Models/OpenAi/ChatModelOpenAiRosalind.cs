using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models;

/// <summary>
/// GPT-Rosalind life sciences models from OpenAI.
/// Available through the trusted-access program for approved internal life sciences research.
/// </summary>
public class ChatModelOpenAiRosalind : IVendorModelClassProvider
{
    /// <summary>
    /// GPT-Rosalind is a life sciences reasoning model for approved organizations.
    /// Released September 8, 2026 as <c>gpt-rosalind-research</c>.
    /// Requires trusted-access provisioning.
    /// </summary>
    public static readonly ChatModel ModelResearch = new ChatModel("gpt-rosalind-research", LLmProviders.OpenAi, 400_000)
    {
        EndpointCapabilities = [ ChatModelEndpointCapabilities.Responses, ChatModelEndpointCapabilities.Chat, ChatModelEndpointCapabilities.Batch ]
    };

    /// <summary>
    /// <inheritdoc cref="ModelResearch"/>
    /// </summary>
    public readonly ChatModel Research = ModelResearch;

    /// <summary>
    /// All known GPT-Rosalind models from OpenAI.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelResearch
    ]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;

    internal ChatModelOpenAiRosalind()
    {

    }
}
