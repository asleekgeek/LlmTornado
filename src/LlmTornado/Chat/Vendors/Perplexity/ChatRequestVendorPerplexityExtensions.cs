using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LlmTornado.Chat.Vendors.Perplexity;

/// <summary>
/// Chat features supported only by Perplexity (Sonar Chat Completions and the Agent API).
/// </summary>
public class ChatRequestVendorPerplexityExtensions
{
    /// <summary>
    /// Agent API preset. When set, the request is sent as <c>preset</c> instead of (or in addition to) <c>model</c>.
    /// </summary>
    public ChatRequestVendorPerplexityPresets? Preset { get; set; }
    
    /// <summary>
    /// Fallback model chain for the Agent API. Tried in order when the primary model is unavailable.
    /// </summary>
    public List<string>? FallbackModels { get; set; }
    
    /// <summary>
    /// Agent API service tier. <see cref="ChatRequestVendorPerplexityServiceTiers.Fast"/> is accepted as an alias for priority.
    /// </summary>
    public ChatRequestVendorPerplexityServiceTiers? ServiceTier { get; set; }
    
    /// <summary>
    /// What results to prioritize (Sonar: academic / SEC).
    /// </summary>
    public ChatRequestVendorPerplexitySearchModes? SearchMode { get; set; }
    
    /// <summary>
    /// Sonar Pro Search mode: fast, pro, or auto.
    /// </summary>
    public ChatRequestVendorPerplexitySearchTypes? SearchType { get; set; }
    
    /// <summary>
    /// Search context size (low / medium / high). Used by Sonar <c>web_search_options</c> and the Agent API web_search tool.
    /// </summary>
    public ChatRequestVendorPerplexitySearchContextSizes? SearchContextSize { get; set; }
    
    /// <summary>
    /// Preferred languages for search results (Sonar: <c>language_preference</c>).
    /// </summary>
    public List<string>? LanguagePreference { get; set; }
    
    /// <summary>
    /// Include only results after given date.
    /// </summary>
    public DateTime? SearchAfterDateFilter { get; set; }
    
    /// <summary>
    /// Include only results before given date.
    /// </summary>
    public DateTime? SearchBeforeDateFilter { get; set; }
    
    /// <summary>
    /// Include only results last updated after given date.
    /// </summary>
    public DateTime? LastUpdatedAfterFilter { get; set; }
    
    /// <summary>
    /// Include only results last updated before given date.
    /// </summary>
    public DateTime? LastUpdatedBeforeFilter { get; set; }
    
    /// <summary>
    /// Filters search results based on time (e.g., 'week', 'day', 'month').
    /// </summary>
    public string? SearchRecencyFilter { get; set; }
    
    /// <summary>
    /// Determines whether related questions should be returned.
    /// </summary>
    public bool? ReturnRelatedQuestions { get; set; }
    
    /// <summary>
    /// Determines whether search results should include images.
    /// </summary>
    public bool? ReturnImages { get; set; }
    
    /// <summary>
    /// Domains which will be included in the search.
    /// </summary>
    public List<string>? IncludeDomains { get; set; }
    
    /// <summary>
    /// Domains which will be excluded from the search.
    /// </summary>
    public List<string>? ExcludeDomains { get; set; }
    
    /// <summary>
    /// Filter results based on when the webpage was last modified or updated.
    /// Used inside web_search_options.
    /// </summary>
    public DateTime? LatestUpdated { get; set; }
    
    /// <summary>
    /// When true, the Agent API request includes the hosted <c>web_search</c> tool.
    /// Automatically enabled when search filters are set.
    /// </summary>
    public bool? EnableWebSearch { get; set; }
    
    /// <summary>
    /// When true, the Agent API request includes the hosted <c>fetch_url</c> tool.
    /// </summary>
    public bool? EnableFetchUrl { get; set; }
    
    /// <summary>
    /// When true, the Agent API request includes the hosted <c>finance_search</c> tool.
    /// </summary>
    public bool? EnableFinanceSearch { get; set; }
    
    /// <summary>
    /// When true, the Agent API request includes the hosted <c>people_search</c> tool.
    /// </summary>
    public bool? EnablePeopleSearch { get; set; }
    
    /// <summary>
    /// When true, the Agent API request includes the hosted <c>sandbox</c> tool.
    /// </summary>
    public bool? EnableSandbox { get; set; }
    
    /// <summary>
    /// User location hint for localized search results.
    /// </summary>
    public string? UserLocation { get; set; }
    
    /// <summary>
    /// Previous Agent API response id. Used to continue a conversation without replaying the transcript.
    /// </summary>
    public string? PreviousResponseId { get; set; }
    
    /// <summary>
    /// Stable prompt cache key. Overrides the automatic key used by presets.
    /// </summary>
    public string? PromptCacheKey { get; set; }
}

/// <summary>
/// Agent API presets.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum ChatRequestVendorPerplexityPresets
{
    /// <summary>
    /// Fast grounded answers. Replacement for sonar.
    /// </summary>
    [EnumMember(Value = "fast")]
    Fast,
    
    /// <summary>
    /// Lightweight research. Replacement for sonar-pro.
    /// </summary>
    [EnumMember(Value = "low")]
    Low,
    
    /// <summary>
    /// Multi-step research. Replacement for sonar-reasoning-pro.
    /// </summary>
    [EnumMember(Value = "medium")]
    Medium,
    
    /// <summary>
    /// Exhaustive research. Replacement for sonar-deep-research.
    /// </summary>
    [EnumMember(Value = "high")]
    High,
    
    /// <summary>
    /// Open-ended agentic work beyond Deep Research.
    /// </summary>
    [EnumMember(Value = "xhigh")]
    XHigh,
    
    /// <summary>
    /// Wide-and-deep research for large collections.
    /// </summary>
    [EnumMember(Value = "wide-research")]
    WideResearch
}

/// <summary>
/// Search modes for Perplexity
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum ChatRequestVendorPerplexitySearchModes
{
    /// <summary>
    /// Prioritize results from peer-reviewed papers, journal articles, and research publications.
    /// </summary>
    [EnumMember(Value = "academic")] 
    Academic,
    
    /// <summary>
    /// Prioritize results from SEC filings.
    /// </summary>
    [EnumMember(Value = "sec")]
    Sec
}

/// <summary>
/// Sonar Pro Search classification.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum ChatRequestVendorPerplexitySearchTypes
{
    /// <summary>
    /// Standard Sonar Pro behavior.
    /// </summary>
    [EnumMember(Value = "fast")]
    Fast,
    
    /// <summary>
    /// Multi-step tool usage for complex queries.
    /// </summary>
    [EnumMember(Value = "pro")]
    Pro,
    
    /// <summary>
    /// Automatic classification based on query complexity.
    /// </summary>
    [EnumMember(Value = "auto")]
    Auto
}

/// <summary>
/// Search context size for Sonar and Agent API web search.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum ChatRequestVendorPerplexitySearchContextSizes
{
    /// <summary>
    /// Cost-efficient for straightforward queries.
    /// </summary>
    [EnumMember(Value = "low")]
    Low,
    
    /// <summary>
    /// Balanced approach for moderate complexity.
    /// </summary>
    [EnumMember(Value = "medium")]
    Medium,
    
    /// <summary>
    /// Maximum depth for complex queries.
    /// </summary>
    [EnumMember(Value = "high")]
    High
}

/// <summary>
/// Agent API service tiers. Omit or use default for standard processing.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum ChatRequestVendorPerplexityServiceTiers
{
    /// <summary>
    /// Default processing.
    /// </summary>
    [EnumMember(Value = "default")]
    Default,
    
    /// <summary>
    /// Automatic tier selection.
    /// </summary>
    [EnumMember(Value = "auto")]
    Auto,
    
    /// <summary>
    /// Lower-cost, best-effort capacity at 0.5× token prices.
    /// </summary>
    [EnumMember(Value = "flex")]
    Flex,
    
    /// <summary>
    /// Higher-priority processing at 2× token prices.
    /// </summary>
    [EnumMember(Value = "priority")]
    Priority,
    
    /// <summary>
    /// Alias for <see cref="Priority"/>.
    /// </summary>
    [EnumMember(Value = "fast")]
    Fast
}
