using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models;

/// <summary>
/// Claude 3.5 class models from Anthropic.
/// </summary>
public class ChatModelAnthropicClaude35 : IVendorModelClassProvider
{
    /// <summary>
    /// Most balanced model between intelligence and speed. Retired October 28, 2025 on the Claude API.
    /// </summary>
    [Obsolete("Retired October 28, 2025 on the Claude API. Use ChatModel.Anthropic.Claude5.Sonnet instead.")]
    public static readonly ChatModel ModelSonnet = new ChatModel("claude-3-5-sonnet-20240620", LLmProviders.Anthropic, 200_000);

    /// <summary>
    /// New snapshot of Sonnet 3.5. Retired October 28, 2025 on the Claude API.
    /// </summary>
    [Obsolete("Retired October 28, 2025 on the Claude API. Use ChatModel.Anthropic.Claude5.Sonnet instead.")]
    public static readonly ChatModel ModelSonnet241022 = new ChatModel("claude-3-5-sonnet-20241022", LLmProviders.Anthropic, 200_000);

    /// <summary>
    /// Points to <see cref="ModelSonnet241022"/>. Retired October 28, 2025 on the Claude API.
    /// </summary>
    [Obsolete("Retired October 28, 2025 on the Claude API. Use ChatModel.Anthropic.Claude5.Sonnet instead.")]
    public static readonly ChatModel ModelSonnetLatest = new ChatModel("claude-3-5-sonnet-latest", LLmProviders.Anthropic, 200_000);

    /// <summary>
    /// <inheritdoc cref="ModelSonnet"/>
    /// </summary>
    [Obsolete("Retired October 28, 2025 on the Claude API. Use ChatModel.Anthropic.Claude5.Sonnet instead.")]
    public readonly ChatModel Sonnet = ModelSonnet;
    
    /// <summary>
    /// <inheritdoc cref="ModelSonnet241022"/>
    /// </summary>
    [Obsolete("Retired October 28, 2025 on the Claude API. Use ChatModel.Anthropic.Claude5.Sonnet instead.")]
    public readonly ChatModel Sonnet241022 = ModelSonnet241022;
    
    /// <summary>
    /// <inheritdoc cref="ModelSonnetLatest"/>
    /// </summary>
    [Obsolete("Retired October 28, 2025 on the Claude API. Use ChatModel.Anthropic.Claude5.Sonnet instead.")]
    public readonly ChatModel SonnetLatest = ModelSonnetLatest;
    
    /// <summary>
    /// All known Claude 3.5 models from Anthropic.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [ModelSonnet, ModelSonnet241022, ModelSonnetLatest]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;

    internal ChatModelAnthropicClaude35()
    {

    }
}