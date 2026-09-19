using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Ocr.Models.Mistral;

/// <summary>
/// Known OCR models from Mistral.
/// </summary>
public class OcrModelMistral : BaseVendorModelProvider
{
    /// <inheritdoc cref="BaseVendorModelProvider.Provider"/>
    public override LLmProviders Provider => LLmProviders.Mistral;

    /// <summary>
    /// OCR 4.1 (mistral-ocr-4-1) — generally available August 2026.
    /// Adds paragraph-level blocks, structural labels, and page / block / word confidence scores.
    /// </summary>
    public static readonly OcrModel ModelOcr41 = new OcrModel("mistral-ocr-4-1", LLmProviders.Mistral, ["mistral-ocr-latest", "mistral-ocr-4"]);

    /// <summary>
    /// <inheritdoc cref="ModelOcr41"/>
    /// </summary>
    public readonly OcrModel Ocr41 = ModelOcr41;

    /// <summary>
    /// OCR 4.0 (mistral-ocr-4-0) — released June 2026.
    /// Native paragraph-level bounding boxes and structural block labels.
    /// </summary>
    public static readonly OcrModel ModelOcr40 = new OcrModel("mistral-ocr-4-0", LLmProviders.Mistral);

    /// <summary>
    /// <inheritdoc cref="ModelOcr40"/>
    /// </summary>
    public readonly OcrModel Ocr40 = ModelOcr40;

    /// <summary>
    /// <inheritdoc cref="ModelOcr40"/>
    /// </summary>
    public readonly OcrModel Ocr4 = ModelOcr40;

    /// <summary>
    /// OCR 3 (mistral-ocr-2512) — released December 2025.
    /// Features: table_format (markdown/html), extract_header, extract_footer, hyperlinks output.
    /// </summary>
    public static readonly OcrModel ModelOcr2512 = new OcrModel("mistral-ocr-2512", LLmProviders.Mistral);

    /// <summary>
    /// <inheritdoc cref="ModelOcr2512"/>
    /// </summary>
    public readonly OcrModel Ocr2512 = ModelOcr2512;

    /// <summary>
    /// <inheritdoc cref="ModelOcr2512"/>
    /// </summary>
    public readonly OcrModel Ocr3 = ModelOcr2512;

    /// <summary>
    /// Latest OCR model. Currently OCR 4.1.
    /// </summary>
    public static readonly OcrModel ModelOcrLatest = new OcrModel("mistral-ocr-latest", LLmProviders.Mistral);

    /// <summary>
    /// <inheritdoc cref="ModelOcrLatest"/>
    /// </summary>
    public readonly OcrModel Latest = ModelOcrLatest;

    /// <summary>
    /// All known OCR models from Mistral.
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
    /// <inheritdoc cref="AllModels"/>
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [ModelOcr41, ModelOcr40, ModelOcr2512, ModelOcrLatest]);

    internal OcrModelMistral()
    {
    }
}
