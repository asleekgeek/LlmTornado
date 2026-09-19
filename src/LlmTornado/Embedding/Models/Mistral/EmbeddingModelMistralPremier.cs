using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Embedding.Models.Mistral;

/// <summary>
/// Premier embedding models from Mistral.
/// </summary>
public class EmbeddingModelMistralPremier : BaseVendorModelProvider
{
    /// <inheritdoc cref="BaseVendorModelProvider.Provider"/>
    public override LLmProviders Provider => LLmProviders.Mistral;
    
    /// <summary>
    /// Our state-of-the-art semantic for extracting representation of code extracts
    /// </summary>
    public static readonly EmbeddingModel ModelCodestralEmbed = new EmbeddingModel("codestral-embed", LLmProviders.Mistral, 8_192, 1_546, [ 1546, 1024, 512, 256 ]);

    /// <summary>
    /// <inheritdoc cref="ModelCodestralEmbed"/>
    /// </summary>
    public readonly EmbeddingModel CodestralEmbed = ModelCodestralEmbed;
    
    /// <summary>
    /// Our state-of-the-art semantic for extracting representation of text extracts
    /// </summary>
    public static readonly EmbeddingModel ModelMistralEmbed = new EmbeddingModel("mistral-embed", LLmProviders.Mistral, 32_000, 1_024);

    /// <summary>
    /// <inheritdoc cref="ModelMistralEmbed"/>
    /// </summary>
    public readonly EmbeddingModel MistralEmbed = ModelMistralEmbed;
    
    /// <summary>
    /// All known embedding models.
    /// </summary>
    public override List<IModel> AllModels => ModelsAll;
    
    /// <summary>
    /// Checks whether the model is owned by the provider.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public override bool OwnsModel(string model)
    {
        return AllModelsMap.Contains(model);
    }

    /// <summary>
    /// Map of models owned by the provider.
    /// </summary>
    public static HashSet<string> AllModelsMap => LazyAllModelsMap.Value;

    private static readonly Lazy<HashSet<string>> LazyAllModelsMap = new Lazy<HashSet<string>>(() =>
    {
        HashSet<string> map = [];
        ModelsAll.ForEach(x => { map.Add(x.Name); });
        return map;
    });
    
    /// <summary>
    /// All known Mistral Premier models.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ModelCodestralEmbed,
        ModelMistralEmbed,
    ]);
    
    internal EmbeddingModelMistralPremier()
    {
        
    }
}