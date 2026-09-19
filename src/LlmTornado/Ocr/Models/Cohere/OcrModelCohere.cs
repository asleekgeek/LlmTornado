using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Ocr.Models.Cohere;

/// <summary>
/// Known document parse / OCR models from Cohere.
/// </summary>
public class OcrModelCohere : BaseVendorModelProvider
{
    /// <inheritdoc cref="BaseVendorModelProvider.Provider"/>
    public override LLmProviders Provider => LLmProviders.Cohere;

    /// <summary>
    /// Parse v5.0 extracts structured, machine-readable data from enterprise document images via the Parse endpoint.
    /// Currently accepts image URL or base64 data URI inputs.
    /// </summary>
    public static readonly OcrModel ModelParseV5 = new OcrModel("parse-v5.0", LLmProviders.Cohere);

    /// <summary>
    /// <inheritdoc cref="ModelParseV5"/>
    /// </summary>
    public readonly OcrModel ParseV5 = ModelParseV5;

    /// <summary>
    /// All known parse models from Cohere.
    /// </summary>
    public override List<IModel> AllModels => ModelsAll;

    /// <summary>
    /// Checks whether the model is owned by the provider.
    /// </summary>
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
    /// <inheritdoc cref="AllModels"/>
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [ModelParseV5]);

    internal OcrModelCohere()
    {
    }
}
