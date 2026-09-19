using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Ocr.Models.Zai;

/// <summary>
/// Known OCR models from Z.AI.
/// </summary>
public class OcrModelZai : BaseVendorModelProvider
{
    /// <inheritdoc cref="BaseVendorModelProvider.Provider"/>
    public override LLmProviders Provider => LLmProviders.Zai;

    /// <summary>
    /// GLM-OCR (glm-ocr) - Compact 0.9B document parsing model.
    /// Supports images (JPG/PNG ≤10MB) and PDFs (≤50MB, up to 30 pages) via URL or base64.
    /// </summary>
    public static readonly OcrModel ModelGlmOcr = new OcrModel("glm-ocr", LLmProviders.Zai);

    /// <summary>
    /// <inheritdoc cref="ModelGlmOcr"/>
    /// </summary>
    public readonly OcrModel GlmOcr = ModelGlmOcr;

    /// <summary>
    /// All known OCR models from Z.AI.
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

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [ModelGlmOcr]);

    internal OcrModelZai()
    {
    }
}
