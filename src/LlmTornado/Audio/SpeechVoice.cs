using System;
using Newtonsoft.Json;

namespace LlmTornado.Audio;

/// <summary>
///     Represents available sizes for image generation endpoints
/// </summary>
public class SpeechVoice
{
    private SpeechVoice(string? value)
    {
        Value = value ?? string.Empty;
    }

    private string Value { get; }

    /// <summary>
    ///     Requests a voice named Alloy
    /// </summary>
    public static SpeechVoice Alloy => new SpeechVoice("alloy");

    /// <summary>
    ///     Requests a voice named Echo
    /// </summary>
    public static SpeechVoice Echo => new SpeechVoice("echo");

    /// <summary>
    ///     Requests a voice named Fabled
    /// </summary>
    public static SpeechVoice Fable => new SpeechVoice("fable");

    /// <summary>
    ///     Requests a voice named Onyx
    /// </summary>
    public static SpeechVoice Onyx => new SpeechVoice("onyx");

    /// <summary>
    ///     Requests a voice named Nova
    /// </summary>
    public static SpeechVoice Nova => new SpeechVoice("nova");

    /// <summary>
    ///     Requests a voice named Shimmer
    /// </summary>
    public static SpeechVoice Shimmer => new SpeechVoice("shimmer");

    /// <summary>
    ///     Requests a voice named Ash
    /// </summary>
    public static SpeechVoice Ash => new SpeechVoice("ash");

    // Groq Canopy Labs Orpheus voices
    
    /// <summary>
    ///     Requests the Autumn voice from Orpheus (Groq).
    /// </summary>
    public static SpeechVoice AutumnOrpheus => new SpeechVoice("autumn");
    
    /// <summary>
    ///     Requests the Diana voice from Orpheus (Groq).
    /// </summary>
    public static SpeechVoice DianaOrpheus => new SpeechVoice("diana");
    
    /// <summary>
    ///     Requests the Hannah voice from Orpheus (Groq).
    /// </summary>
    public static SpeechVoice HannahOrpheus => new SpeechVoice("hannah");
    
    /// <summary>
    ///     Requests the Austin voice from Orpheus (Groq).
    /// </summary>
    public static SpeechVoice AustinOrpheus => new SpeechVoice("austin");
    
    /// <summary>
    ///     Requests the Daniel voice from Orpheus (Groq).
    /// </summary>
    public static SpeechVoice DanielOrpheus => new SpeechVoice("daniel");
    
    /// <summary>
    ///     Requests the Troy voice from Orpheus (Groq).
    /// </summary>
    public static SpeechVoice TroyOrpheus => new SpeechVoice("troy");
    
    /// <summary>
    ///     Requests the Abdullah voice from Orpheus Arabic Saudi (Groq). Default Arabic voice.
    /// </summary>
    public static SpeechVoice AbdullahOrpheus => new SpeechVoice("abdullah");
    
    /// <summary>
    ///     Requests the Fahad voice from Orpheus Arabic Saudi (Groq).
    /// </summary>
    public static SpeechVoice FahadOrpheus => new SpeechVoice("fahad");
    
    /// <summary>
    ///     Requests the Sultan voice from Orpheus Arabic Saudi (Groq).
    /// </summary>
    public static SpeechVoice SultanOrpheus => new SpeechVoice("sultan");
    
    /// <summary>
    ///     Requests the Lulwa voice from Orpheus Arabic Saudi (Groq).
    /// </summary>
    public static SpeechVoice LulwaOrpheus => new SpeechVoice("lulwa");
    
    /// <summary>
    ///     Requests the Noura voice from Orpheus Arabic Saudi (Groq).
    /// </summary>
    public static SpeechVoice NouraOrpheus => new SpeechVoice("noura");
    
    /// <summary>
    ///     Requests the Aisha voice from Orpheus Arabic Saudi (Groq).
    /// </summary>
    public static SpeechVoice AishaOrpheus => new SpeechVoice("aisha");
    
    /// <summary>
    ///     Creates a custom voice with the specified name.
    /// </summary>
    /// <param name="voiceName">The name of the voice.</param>
    /// <returns>A SpeechVoice instance with the specified name.</returns>
    public static SpeechVoice Custom(string voiceName) => new SpeechVoice(voiceName);

    /// <summary>
    ///     Gets the string value for this size to pass to the API
    /// </summary>
    /// <returns>The size as a string</returns>
    public override string ToString()
    {
        return Value;
    }

    /// <summary>
    ///     Gets the string value for this size to pass to the API
    /// </summary>
    /// <param name="value">The SpeechVoice to convert</param>
    public static implicit operator string(SpeechVoice value)
    {
        return value.Value;
    }

    internal class SpeechVoiceJsonConverter : JsonConverter<SpeechVoice>
    {
        public override void WriteJson(JsonWriter writer, SpeechVoice value, JsonSerializer serializer)
        {
            writer.WriteValue(value?.ToString());
        }

        public override SpeechVoice ReadJson(JsonReader reader, Type objectType, SpeechVoice existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return new SpeechVoice(reader.ReadAsString());
        }
    }
}