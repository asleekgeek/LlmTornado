using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;
using LlmTornado.Ocr.Models.Cohere;
using LlmTornado.Ocr.Models.Mistral;
using LlmTornado.Ocr.Models.Zai;

namespace LlmTornado.Ocr.Models;

/// <summary>
/// Represents an OCR model.
/// </summary>
public class OcrModel : ModelBase, IModel
{
    /// <inheritdoc cref="IModel.Name"/>
    public string Name { get; set; }
    
    /// <inheritdoc cref="IModel.Provider"/>
    public LLmProviders Provider { get; set; }

    /// <summary>
    /// Known OCR models from Mistral.
    /// </summary>
    public static readonly OcrModelMistral Mistral = new OcrModelMistral();

    /// <summary>
    /// Known OCR models from Z.AI.
    /// </summary>
    public static readonly OcrModelZai Zai = new OcrModelZai();
    
    /// <summary>
    /// Known parse / OCR models from Cohere.
    /// </summary>
    public static readonly OcrModelCohere Cohere = new OcrModelCohere();

    /// <summary>
    /// All known OCR models.
    /// </summary>
    public static List<IModel> AllModels => LazyModelsAll.Value;

    /// <summary>
    /// Map of models owned by the provider.
    /// </summary>
    public static HashSet<string> AllModelsMap => LazyAllModelsMap.Value;

    private static readonly Lazy<HashSet<string>> LazyAllModelsMap = new Lazy<HashSet<string>>(() =>
    {
        HashSet<string> map = [];
        AllModels.ForEach(x => { map.Add(x.Name); });
        return map;
    });

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ..OcrModelMistral.ModelsAll,
        ..OcrModelZai.ModelsAll,
        ..OcrModelCohere.ModelsAll
    ]);

    /// <summary>
    /// Creates an OCR model.
    /// </summary>
    /// <param name="name">Model name</param>
    /// <param name="provider">Provider</param>
    public OcrModel(string name, LLmProviders provider)
    {
        Name = name;
        Provider = provider;
    }

    /// <summary>
    /// Creates an OCR model with aliases.
    /// </summary>
    /// <param name="name">Model name</param>
    /// <param name="provider">Provider</param>
    /// <param name="aliases">Aliases</param>
    public OcrModel(string name, LLmProviders provider, List<string>? aliases)
    {
        Name = name;
        Provider = provider;
        Aliases = aliases;
    }

    /// <summary>
    /// Represents an OCR model from a name.
    /// </summary>
    /// <param name="name">Model name</param>
    public static implicit operator OcrModel(string name)
    {
        return new OcrModel(name, LLmProviders.Unknown);
    }
}
