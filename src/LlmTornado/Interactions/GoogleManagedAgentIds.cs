namespace LlmTornado.Interactions;

/// <summary>
/// Known managed agent identifiers for the Gemini Interactions API.
/// </summary>
public static class GoogleManagedAgentIds
{
    /// <summary>
    /// General-purpose Antigravity managed agent (Gemini 3.8 Flash harness).
    /// Replaces <see cref="AntigravityPreview052026"/>.
    /// </summary>
    public const string AntigravityPreview092026 = "antigravity-preview-09-2026";

    /// <summary>
    /// Legacy Antigravity managed agent (Gemini 3.5 Flash harness). Shuts down October 5, 2026.
    /// </summary>
    public const string AntigravityPreview052026 = "antigravity-preview-05-2026";

    /// <summary>
    /// Gemini Deep Research agent.
    /// </summary>
    public const string DeepResearchProPreview122025 = "deep-research-pro-preview-12-2025";

    /// <summary>
    /// Gemini Deep Research agent (April 2026 preview).
    /// </summary>
    public const string DeepResearchPreview042026 = "deep-research-preview-04-2026";

    /// <summary>
    /// Gemini Deep Research Max agent.
    /// </summary>
    public const string DeepResearchMaxPreview042026 = "deep-research-max-preview-04-2026";
}
