using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using LlmTornado.Code;
using LlmTornado.Live.OpenAi;
using LlmTornado.Live.Vendors.Google;

namespace LlmTornado.Live;

/// <summary>
/// Live voice endpoints: Gemini Live (Google) and GPT-Live (OpenAI).
/// </summary>
public class LiveEndpoint
{
    private readonly Lazy<OpenAiLiveEndpoint> openAi;

    /// <summary>
    /// Creates the Live endpoint.
    /// </summary>
    public LiveEndpoint(TornadoApi api)
    {
        Api = api;
        openAi = new Lazy<OpenAiLiveEndpoint>(() => new OpenAiLiveEndpoint(api), LazyThreadSafetyMode.ExecutionAndPublication);
    }

    /// <summary>
    /// Parent API instance.
    /// </summary>
    public TornadoApi Api { get; }

    /// <summary>
    /// OpenAI GPT-Live: WebSocket, WebRTC, SIP, sideband, fork, and recordings.
    /// </summary>
    public OpenAiLiveEndpoint OpenAi => openAi.Value;

    /// <summary>
    /// Opens a Live API WebSocket session using the configured Google API key or an ephemeral access token.
    /// </summary>
    public async Task<LiveSession> ConnectAsync(LiveConnectOptions? options = null, CancellationToken cancellationToken = default)
    {
        LiveConnectOptions connectOptions = options ?? new LiveConnectOptions();
        CancellationToken token = CancellationTokenSource.CreateLinkedTokenSource(connectOptions.CancellationToken, cancellationToken).Token;

        ProviderAuthentication? auth = Api.GetProviderAuthentication(LLmProviders.Google);
        string? apiKey = connectOptions.AccessToken is null ? auth?.ApiKey : null;
        string url = VendorGoogleLiveMapper.BuildWebSocketUrl(connectOptions.ApiVersion, apiKey, connectOptions.AccessToken);

        ClientWebSocket webSocket = new ClientWebSocket();
        await webSocket.ConnectAsync(new Uri(url), token).ConfigureAwait(false);
        connectOptions.OnOpen?.Invoke();

        LiveSession session = new LiveSession(webSocket, connectOptions);
        session.StartReceiveLoop(token);
        await session.SendSetupAsync(connectOptions.Config, token).ConfigureAwait(false);

        return session;
    }
}
