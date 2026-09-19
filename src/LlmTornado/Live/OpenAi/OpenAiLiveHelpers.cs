using System;
using System.Collections.Generic;
using System.Text;

namespace LlmTornado.Live.OpenAi;

/// <summary>
/// Accumulates independent user and assistant transcript fragments with their session-timeline ranges.
/// </summary>
public sealed class OpenAiLiveTranscriptBuffer
{
    public List<OpenAiLiveTranscriptFragment> User { get; } = [];
    public List<OpenAiLiveTranscriptFragment> Assistant { get; } = [];

    public string UserText => Concat(User);
    public string AssistantText => Concat(Assistant);

    public void Apply(OpenAiLiveServerEvent evt)
    {
        switch (evt)
        {
            case OpenAiLiveInputTranscriptDeltaEvent input:
                User.Add(new OpenAiLiveTranscriptFragment(input.Delta ?? string.Empty, input.StartMs, input.EndMs));
                break;
            case OpenAiLiveOutputTranscriptDeltaEvent output:
                Assistant.Add(new OpenAiLiveTranscriptFragment(output.Delta ?? string.Empty, output.StartMs, output.EndMs));
                break;
        }
    }

    private static string Concat(List<OpenAiLiveTranscriptFragment> fragments)
    {
        StringBuilder sb = new StringBuilder();
        foreach (OpenAiLiveTranscriptFragment fragment in fragments)
        {
            sb.Append(fragment.Text);
        }

        return sb.ToString();
    }
}

/// <summary>
/// A timed transcript fragment. Boundaries follow audio cadence, not semantic turns.
/// </summary>
public readonly struct OpenAiLiveTranscriptFragment
{
    public OpenAiLiveTranscriptFragment(string text, int? startMs, int? endMs)
    {
        Text = text;
        StartMs = startMs;
        EndMs = endMs;
    }

    /// <summary>Transcript text exactly as received, including spaces.</summary>
    public string Text { get; }

    /// <summary>Inclusive start of the fragment on the session timeline, in milliseconds.</summary>
    public int? StartMs { get; }

    /// <summary>Exclusive end of the fragment on the session timeline, in milliseconds.</summary>
    public int? EndMs { get; }
}

/// <summary>
/// Encodes raw GPT-Live audio for <c>session.input_audio.append</c>.
/// </summary>
public static class OpenAiLiveAudio
{
    /// <summary>
    /// Base64-encodes raw codec bytes. PCM16 payloads must have an even length.
    /// </summary>
    public static string Encode(byte[] audio, OpenAiLiveAudioFormat? format = null)
    {
        if (audio is null || audio.Length == 0)
        {
            throw new ArgumentException("GPT-Live input audio appends must be non-empty.", nameof(audio));
        }

        if ((format?.RequiresEvenByteLength ?? true) && audio.Length % 2 != 0)
        {
            throw new ArgumentException("PCM16 audio must contain an even number of bytes.", nameof(audio));
        }

        return Convert.ToBase64String(audio);
    }

    public static byte[] Decode(string base64)
    {
        return Convert.FromBase64String(base64);
    }
}
