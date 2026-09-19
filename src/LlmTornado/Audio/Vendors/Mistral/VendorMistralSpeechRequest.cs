using LlmTornado.Audio.Models;
using Newtonsoft.Json;

namespace LlmTornado.Audio.Vendors.Mistral;

/// <summary>
/// Mistral Voxtral TTS payload. Uses voice_id or ref_audio instead of OpenAI's voice field.
/// </summary>
internal class VendorMistralSpeechRequest
{
    [JsonProperty("model")]
    [JsonConverter(typeof(AudioModelJsonConverter))]
    public AudioModel Model { get; set; }

    [JsonProperty("input")]
    public string Input { get; set; }

    [JsonProperty("voice_id", NullValueHandling = NullValueHandling.Ignore)]
    public string? VoiceId { get; set; }

    [JsonProperty("ref_audio", NullValueHandling = NullValueHandling.Ignore)]
    public string? RefAudio { get; set; }

    [JsonProperty("response_format", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(SpeechResponseFormat.SpeechResponseFormatJsonConverter))]
    public SpeechResponseFormat? ResponseFormat { get; set; }

    public VendorMistralSpeechRequest(SpeechRequest request)
    {
        Model = request.Model;
        Input = request.Input;
        VoiceId = request.VoiceId;
        RefAudio = request.RefAudio;
        ResponseFormat = request.ResponseFormat;
    }
}
