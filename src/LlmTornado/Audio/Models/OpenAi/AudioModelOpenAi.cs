using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Audio.Models.OpenAi;

/// <summary>
/// Known audio models from OpenAI.
/// </summary>
public class AudioModelOpenAi : BaseVendorModelProvider
{
    /// <inheritdoc cref="BaseVendorModelProvider.Provider"/>
    public override LLmProviders Provider => LLmProviders.OpenAi;
    
    /// <summary>
    /// Whisper models.
    /// </summary>
    public readonly AudioModelOpenAiWhisper Whisper = new AudioModelOpenAiWhisper();
    
    /// <summary>
    /// Tts models.
    /// </summary>
    public readonly AudioModelOpenAiTts Tts = new AudioModelOpenAiTts();
    
    /// <summary>
    /// Gpt4o models.
    /// </summary>
    public readonly AudioModelOpenAiGpt4 Gpt4 = new AudioModelOpenAiGpt4();
    
    /// <summary>
    /// GPT Transcribe / GPT Live Transcribe models (July 30, 2026).
    /// </summary>
    public readonly AudioModelOpenAiGpt Gpt = new AudioModelOpenAiGpt();

    /// <summary>
    /// All known chat models from OpenAI.
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

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [
        ..AudioModelOpenAiWhisper.ModelsAll,
        ..AudioModelOpenAiTts.ModelsAll,
        ..AudioModelOpenAiGpt4.ModelsAll,
        ..AudioModelOpenAiGpt.ModelsAll
    ]);

    /// <summary>
    /// Models supporting "verbose_json" output & "timestamp_granularities"
    /// </summary>
    public static List<IModel> VerboseJsonCompatibleModels => LazyVerboseJsonCompatibleModels.Value;

    private static readonly Lazy<List<IModel>> LazyVerboseJsonCompatibleModels = new Lazy<List<IModel>>(() => [
        ..AudioModelOpenAiWhisper.ModelsAll
    ]);
    
    /// <summary>
    /// Models supporting streaming.
    /// </summary>
    public static List<IModel> StreamingCompatibleModels => LazyStreamingCompatibleModels.Value;

    private static readonly Lazy<List<IModel>> LazyStreamingCompatibleModels = new Lazy<List<IModel>>(() => [
        ..AudioModelOpenAiTts.ModelsAll,
        ..AudioModelOpenAiGpt4.ModelsAll,
        ..AudioModelOpenAiGpt.ModelsAll
    ]);
    
    /// <summary>
    /// Models supporting "include".
    /// </summary>
    public static List<IModel> IncludeCompatibleModels => LazyIncludeCompatibleModels.Value;

    private static readonly Lazy<List<IModel>> LazyIncludeCompatibleModels = new Lazy<List<IModel>>(() => [
        ..AudioModelOpenAiGpt4.ModelsAll,
        ..AudioModelOpenAiGpt.ModelsAll
    ]);
    
    internal AudioModelOpenAi()
    {
        
    }
}
