using System;
using System.Threading;
using System.Threading.Tasks;

namespace LlmTornado.Live.OpenAi;

/// <summary>
/// Options for opening a GPT-Live WebSocket (primary, sideband, or fork).
/// </summary>
public class OpenAiLiveConnectOptions
{
    /// <summary>
    /// Connection kind. Primary is the default audio+events socket.
    /// </summary>
    public OpenAiLiveConnectKind Kind { get; set; } = OpenAiLiveConnectKind.Primary;

    /// <summary>
    /// Existing session id for <see cref="OpenAiLiveConnectKind.Sideband"/> and <see cref="OpenAiLiveConnectKind.Fork"/>.
    /// Use the id unchanged, including its prefix.
    /// </summary>
    public string? SessionId { get; set; }

    /// <summary>
    /// API key or ephemeral client secret. When null, uses the authenticated OpenAI provider from <see cref="TornadoApi"/>.
    /// </summary>
    public string? ApiKey { get; set; }

    /// <summary>
    /// Optional <c>OpenAI-Safety-Identifier</c> header.
    /// </summary>
    public string? SafetyIdentifier { get; set; }

    /// <summary>
    /// Optional organization header.
    /// </summary>
    public string? Organization { get; set; }

    /// <summary>
    /// Optional project header.
    /// </summary>
    public string? Project { get; set; }

    /// <summary>
    /// API version segment (default <c>v1</c>).
    /// </summary>
    public string ApiVersion { get; set; } = "v1";

    /// <summary>
    /// Base host (default <c>api.openai.com</c>).
    /// </summary>
    public string Host { get; set; } = "api.openai.com";

    /// <summary>
    /// When true (default) for <see cref="OpenAiLiveConnectKind.Primary"/> and <see cref="OpenAiLiveConnectKind.Fork"/>,
    /// <c>session.start</c> is sent automatically after the socket opens.
    /// Always false for sideband connections.
    /// </summary>
    public bool AutoStart { get; set; } = true;

    /// <summary>
    /// Session configuration for automatic or manual <c>session.start</c>.
    /// Forks may use an empty object to inherit the stored source.
    /// </summary>
    public OpenAiLiveSessionConfig? Session { get; set; }

    /// <summary>
    /// Optional event id for the automatic <c>session.start</c>.
    /// </summary>
    public string? StartEventId { get; set; }

    /// <summary>
    /// Invoked for each parsed server event.
    /// </summary>
    public Func<OpenAiLiveServerEvent, ValueTask>? OnEvent { get; set; }

    /// <summary>
    /// Optional typed dispatcher. Invoked after <see cref="OnEvent"/>.
    /// </summary>
    public OpenAiLiveEventHandler? Handler { get; set; }

    /// <summary>
    /// Invoked when the WebSocket opens, before <c>session.start</c>.
    /// </summary>
    public Action? OnOpen { get; set; }

    /// <summary>
    /// Invoked on receive-loop errors.
    /// </summary>
    public Action<Exception>? OnError { get; set; }

    /// <summary>
    /// Invoked when the WebSocket closes.
    /// </summary>
    public Action<string?>? OnClose { get; set; }

    /// <summary>
    /// Cancellation token for connect and the receive loop.
    /// </summary>
    public CancellationToken CancellationToken { get; set; } = CancellationToken.None;

    /// <summary>
    /// Whether this connection should send <c>session.start</c>.
    /// </summary>
    public bool ShouldSendSessionStart =>
        AutoStart && Kind is OpenAiLiveConnectKind.Primary or OpenAiLiveConnectKind.Fork;

    /// <summary>
    /// Builds the official GPT-Live WebSocket URL. Primary connections have no query string.
    /// </summary>
    public Uri BuildWebSocketUri()
    {
        return Kind switch
        {
            OpenAiLiveConnectKind.Sideband => BuildAttachedUri("attach"),
            OpenAiLiveConnectKind.Fork => BuildAttachedUri("fork"),
            _ => new Uri($"wss://{Host}/{ApiVersion}/live/sessions")
        };
    }

    private Uri BuildAttachedUri(string suffix)
    {
        if (string.IsNullOrWhiteSpace(SessionId))
        {
            throw new InvalidOperationException($"SessionId is required for {Kind} connections.");
        }

        return new Uri($"wss://{Host}/{ApiVersion}/live/sessions/{SessionId}/{suffix}");
    }

    public static OpenAiLiveConnectOptions Primary(OpenAiLiveSessionConfig session, string? startEventId = null)
    {
        return new OpenAiLiveConnectOptions
        {
            Kind = OpenAiLiveConnectKind.Primary,
            Session = session,
            StartEventId = startEventId
        };
    }

    public static OpenAiLiveConnectOptions Sideband(string sessionId)
    {
        return new OpenAiLiveConnectOptions
        {
            Kind = OpenAiLiveConnectKind.Sideband,
            SessionId = sessionId,
            AutoStart = false
        };
    }

    public static OpenAiLiveConnectOptions Fork(string sourceSessionId, OpenAiLiveSessionConfig? overrides = null)
    {
        return new OpenAiLiveConnectOptions
        {
            Kind = OpenAiLiveConnectKind.Fork,
            SessionId = sourceSessionId,
            Session = overrides ?? OpenAiLiveSessionConfig.ForForkInherit()
        };
    }
}
