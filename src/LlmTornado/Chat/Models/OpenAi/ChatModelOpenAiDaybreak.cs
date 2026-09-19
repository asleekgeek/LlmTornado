using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models;

/// <summary>
/// OpenAI Daybreak cybersecurity models for approved defenders.
/// These models require separate Daybreak program approval and provisioning.
/// </summary>
public class ChatModelOpenAiDaybreak : IVendorModelClassProvider
{
    /// <summary>
    /// GPT-5.6 Cyber is the most advanced cybersecurity model for authorized vulnerability
    /// research and security testing. Responses API only. 400k context window.
    /// Requires Daybreak Red approval.
    /// </summary>
    public static readonly ChatModel ModelGpt56Cyber = new ChatModel("gpt-5.6-cyber", LLmProviders.OpenAi, 400_000)
    {
        EndpointCapabilities = [ ChatModelEndpointCapabilities.Responses, ChatModelEndpointCapabilities.Batch ]
    };

    /// <summary>
    /// <inheritdoc cref="ModelGpt56Cyber"/>
    /// </summary>
    public readonly ChatModel Gpt56Cyber = ModelGpt56Cyber;

    /// <summary>
    /// Daybreak Red is an alias for advanced cybersecurity models used for authorized
    /// vulnerability reproduction, exploit validation, penetration testing, and red teaming.
    /// Responses API only. Requires separate Daybreak Red approval.
    /// </summary>
    public static readonly ChatModel ModelRedLatest = new ChatModel("gpt-daybreak-red-latest", LLmProviders.OpenAi, 400_000)
    {
        EndpointCapabilities = [ ChatModelEndpointCapabilities.Responses, ChatModelEndpointCapabilities.Batch ]
    };

    /// <summary>
    /// <inheritdoc cref="ModelRedLatest"/>
    /// </summary>
    public readonly ChatModel RedLatest = ModelRedLatest;

    /// <summary>
    /// Daybreak Blue is an alias for flagship general-purpose models with safeguards for
    /// defensive cybersecurity work such as vulnerability discovery and secure code review.
    /// Responses API only. Requires Daybreak Blue approval.
    /// </summary>
    public static readonly ChatModel ModelBlueLatest = new ChatModel("gpt-daybreak-blue-latest", LLmProviders.OpenAi, 1_050_000)
    {
        EndpointCapabilities = [ ChatModelEndpointCapabilities.Responses, ChatModelEndpointCapabilities.Batch ]
    };

    /// <summary>
    /// <inheritdoc cref="ModelBlueLatest"/>
    /// </summary>
    public readonly ChatModel BlueLatest = ModelBlueLatest;

    /// <summary>
    /// All known OpenAI Daybreak models.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelGpt56Cyber, ModelRedLatest, ModelBlueLatest
    ]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;

    internal ChatModelOpenAiDaybreak()
    {

    }
}
