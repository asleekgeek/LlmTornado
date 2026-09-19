using System.Collections.Generic;

namespace LlmTornado.Chat.Vendors.Groq;

/// <summary>
/// Chat features supported only by Groq.
/// </summary>
public class ChatRequestVendorGroqExtensions
{
    /// <summary>
    /// Search settings for Compound systems (<c>search_settings</c>).
    /// </summary>
    public ChatRequestVendorGroqSearchSettings? SearchSettings { get; set; }

    /// <summary>
    /// Compound system customization (<c>compound_custom</c>), including enabled built-in tools.
    /// </summary>
    public ChatRequestVendorGroqCompoundCustom? CompoundCustom { get; set; }

    /// <summary>
    /// Value of the <c>Groq-Model-Version</c> header. Use <c>latest</c> for the newest Compound prerelease.
    /// </summary>
    public string? ModelVersion { get; set; }
}

/// <summary>
/// Domain and locale filters for Compound web search.
/// </summary>
public class ChatRequestVendorGroqSearchSettings
{
    /// <summary>
    /// Limit web search to these domains.
    /// </summary>
    public List<string>? IncludeDomains { get; set; }

    /// <summary>
    /// Omit these domains from web search results.
    /// </summary>
    public List<string>? ExcludeDomains { get; set; }

    /// <summary>
    /// When true, include images in search results.
    /// </summary>
    public bool? IncludeImages { get; set; }

    /// <summary>
    /// ISO country code used to prioritize search results from a specific country.
    /// </summary>
    public string? Country { get; set; }
}

/// <summary>
/// Compound-specific request options.
/// </summary>
public class ChatRequestVendorGroqCompoundCustom
{
    /// <summary>
    /// Built-in tool configuration.
    /// </summary>
    public ChatRequestVendorGroqCompoundTools? Tools { get; set; }
}

/// <summary>
/// Built-in Compound tools. Identifiers: <c>web_search</c>, <c>visit_website</c>, <c>code_interpreter</c>, <c>wolfram_alpha</c>.
/// </summary>
public class ChatRequestVendorGroqCompoundTools
{
    /// <summary>
    /// Tools Compound may call. If omitted, all tools enabled for the system version are available.
    /// </summary>
    public List<string>? EnabledTools { get; set; }
}

/// <summary>
/// Built-in Compound tool identifiers.
/// </summary>
public static class ChatRequestVendorGroqCompoundToolIds
{
    /// <summary>
    /// Real-time web search with citations.
    /// </summary>
    public const string WebSearch = "web_search";

    /// <summary>
    /// Fetch and analyze a specific web page.
    /// </summary>
    public const string VisitWebsite = "visit_website";

    /// <summary>
    /// Execute Python in a sandbox.
    /// </summary>
    public const string CodeInterpreter = "code_interpreter";

    /// <summary>
    /// Computational knowledge via Wolfram Alpha.
    /// </summary>
    public const string WolframAlpha = "wolfram_alpha";
}
