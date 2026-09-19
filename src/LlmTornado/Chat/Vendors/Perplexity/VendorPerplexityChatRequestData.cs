using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using LlmTornado.Chat.Models.Perplexity;
using LlmTornado.Code;
using LlmTornado.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LlmTornado.Chat.Vendors.Perplexity;

internal class VendorPerplexityChatRequest
{
    public VendorPerplexityChatRequestData? ExtendedRequest { get; set; }
    public ChatRequest? NativeRequest { get; set; }
    
    [JsonIgnore]
    public ChatRequest SourceRequest { get; set; }
    
    public JObject Serialize(JsonSerializerSettings settings)
    {
        JsonSerializer serializer = JsonSerializer.CreateDefault(settings);
        JObject jsonPayload = JObject.FromObject(ExtendedRequest ?? NativeRequest, serializer);

        ChatRequestVendorPerplexityExtensions? extensions = SourceRequest.VendorExtensions?.Perplexity;

        if (extensions?.LatestUpdated is not null || extensions?.SearchContextSize is not null)
        {
            if (jsonPayload["web_search_options"] is not JObject webSearchOptions)
            {
                webSearchOptions = new JObject();
                jsonPayload["web_search_options"] = webSearchOptions;
            }

            if (extensions.LatestUpdated is not null)
            {
                webSearchOptions["latest_updated"] = extensions.LatestUpdated.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            }

            if (extensions.SearchContextSize is not null)
            {
                webSearchOptions["search_context_size"] = extensions.SearchContextSize.Value switch
                {
                    ChatRequestVendorPerplexitySearchContextSizes.Low => "low",
                    ChatRequestVendorPerplexitySearchContextSizes.Medium => "medium",
                    ChatRequestVendorPerplexitySearchContextSizes.High => "high",
                    _ => "medium"
                };
            }
        }
        
        return jsonPayload;
    }
    
    public VendorPerplexityChatRequest(ChatRequest request, IEndpointProvider provider)
    {
        SourceRequest = request;
        ChatRequestVendorPerplexityExtensions? extensions = request.VendorExtensions?.Perplexity;

        if (extensions is not null)
        {
            ExtendedRequest = new VendorPerplexityChatRequestData(request);

            if (extensions.SearchRecencyFilter is not null)
            {
                ExtendedRequest.SearchRecencyFilter = extensions.SearchRecencyFilter;
            }

            if (extensions.SearchMode is not null)
            {
                ExtendedRequest.SearchMode = extensions.SearchMode switch
                {
                    ChatRequestVendorPerplexitySearchModes.Academic => "academic",
                    ChatRequestVendorPerplexitySearchModes.Sec => "sec",
                    _ => null
                };
            }

            if (extensions.SearchType is not null)
            {
                ExtendedRequest.SearchType = extensions.SearchType switch
                {
                    ChatRequestVendorPerplexitySearchTypes.Fast => "fast",
                    ChatRequestVendorPerplexitySearchTypes.Pro => "pro",
                    ChatRequestVendorPerplexitySearchTypes.Auto => "auto",
                    _ => null
                };
            }

            if (extensions.SearchBeforeDateFilter is not null)
            {
                ExtendedRequest.SearchBeforeDateFilter = extensions.SearchBeforeDateFilter.Value.ToString("M/d/yyyy", CultureInfo.InvariantCulture);
            }
            
            if (extensions.SearchAfterDateFilter is not null)
            {
                ExtendedRequest.SearchAfterDateFilter = extensions.SearchAfterDateFilter.Value.ToString("M/d/yyyy", CultureInfo.InvariantCulture);
            }
            
            if (extensions.LastUpdatedBeforeFilter is not null)
            {
                ExtendedRequest.LastUpdatedBeforeFilter = extensions.LastUpdatedBeforeFilter.Value.ToString("M/d/yyyy", CultureInfo.InvariantCulture);
            }
            
            if (extensions.LastUpdatedAfterFilter is not null)
            {
                ExtendedRequest.LastUpdatedAfterFilter = extensions.LastUpdatedAfterFilter.Value.ToString("M/d/yyyy", CultureInfo.InvariantCulture);
            }
            
            if (extensions.ReturnImages is not null)
            {
                ExtendedRequest.ReturnImages = extensions.ReturnImages;
            }
            
            if (extensions.ReturnRelatedQuestions is not null)
            {
                ExtendedRequest.ReturnRelatedQuestions = extensions.ReturnRelatedQuestions;
            }

            if (extensions.LanguagePreference?.Count > 0)
            {
                ExtendedRequest.LanguagePreference = extensions.LanguagePreference;
            }

            if (extensions.IncludeDomains?.Count > 0 || extensions.ExcludeDomains?.Count > 0)
            {
                List<string> domainList = [];

                if (extensions.IncludeDomains is not null)
                {
                    domainList.AddRange(extensions.IncludeDomains);
                }
                
                if (extensions.ExcludeDomains is not null)
                {
                    domainList.AddRange(extensions.ExcludeDomains.Select(x => $"-{x}"));
                }

                ExtendedRequest.SearchDomainFilter = domainList;
            }
        }
        else
        {
            NativeRequest = request;
        }
    }
}

/// <summary>
/// https://docs.perplexity.ai/api-reference/sonar-post
/// </summary>
internal class VendorPerplexityChatRequestData : ChatRequest
{
    /// <summary>
    /// %m/%d/%Y
    /// </summary>
    [JsonProperty("search_after_date_filter")]
    public string? SearchAfterDateFilter { get; set; }
    
    /// <summary>
    /// %m/%d/%Y
    /// </summary>
    [JsonProperty("search_before_date_filter")]
    public string? SearchBeforeDateFilter { get; set; }

    /// <summary>
    /// %m/%d/%Y
    /// </summary>
    [JsonProperty("last_updated_after_filter")]
    public string? LastUpdatedAfterFilter { get; set; }
    
    /// <summary>
    /// %m/%d/%Y
    /// </summary>
    [JsonProperty("last_updated_before_filter")]
    public string? LastUpdatedBeforeFilter { get; set; }
    
    /// <summary>
    /// "week", "day", "month"
    /// </summary>
    [JsonProperty("search_recency_filter")]
    public string? SearchRecencyFilter { get; set; }
    
    /// <summary>
    /// "academic" or "sec"
    /// </summary>
    [JsonProperty("search_mode")]
    public string? SearchMode { get; set; }
    
    /// <summary>
    /// Sonar Pro Search: "fast", "pro", or "auto".
    /// </summary>
    [JsonProperty("search_type")]
    public string? SearchType { get; set; }
    
    /// <summary>
    /// Preferred languages for search results.
    /// </summary>
    [JsonProperty("language_preference")]
    public List<string>? LanguagePreference { get; set; }
    
    /// <summary>
    /// Determines whether related questions should be returned.
    /// </summary>
    [JsonProperty("return_related_questions")]
    public bool? ReturnRelatedQuestions { get; set; }
    
    /// <summary>
    /// Determines whether search results should include images.
    /// </summary>
    [JsonProperty("return_images")]
    public bool? ReturnImages { get; set; }
    
    /// <summary>
    /// The search_domain_filter parameter allows you to control which websites are included in or excluded from the search results used by the Sonar models.
    /// Enabling domain filtering can be done by adding a search_domain_filter field in the request:
    /// "domain1" (include)
    /// "-domain1" (exclude)
    /// </summary>
    [JsonProperty("search_domain_filter")]
    public List<string>? SearchDomainFilter { get; set; }
    
    public VendorPerplexityChatRequestData(ChatRequest request) : base(request)
    {
            
    }
}

internal static class VendorPerplexityAgentSerialization
{
    public static void Apply(ResponseRequest request, ChatRequest chatRequest)
    {
        ChatRequestVendorPerplexityExtensions? extensions = chatRequest.VendorExtensions?.Perplexity;

        if (chatRequest.Model?.Name is not null && ChatModelPerplexity.PresetNames.Contains(chatRequest.Model.Name))
        {
            request.Preset = chatRequest.Model.Name;
            request.Model = null;
        }

        if (extensions?.Preset is not null)
        {
            request.Preset = extensions.Preset.Value switch
            {
                ChatRequestVendorPerplexityPresets.Fast => "fast",
                ChatRequestVendorPerplexityPresets.Low => "low",
                ChatRequestVendorPerplexityPresets.Medium => "medium",
                ChatRequestVendorPerplexityPresets.High => "high",
                ChatRequestVendorPerplexityPresets.XHigh => "xhigh",
                ChatRequestVendorPerplexityPresets.WideResearch => "wide-research",
                _ => request.Preset
            };
        }

        if (extensions?.FallbackModels?.Count > 0)
        {
            request.Models = extensions.FallbackModels;
        }

        if (extensions?.ServiceTier is not null)
        {
            request.ServiceTier = extensions.ServiceTier.Value switch
            {
                ChatRequestVendorPerplexityServiceTiers.Flex => ChatRequestServiceTiers.Flex,
                ChatRequestVendorPerplexityServiceTiers.Priority or ChatRequestVendorPerplexityServiceTiers.Fast => ChatRequestServiceTiers.Priority,
                ChatRequestVendorPerplexityServiceTiers.Auto => ChatRequestServiceTiers.Auto,
                _ => ChatRequestServiceTiers.Default
            };
        }

        if (extensions?.PreviousResponseId is not null)
        {
            request.PreviousResponseId = extensions.PreviousResponseId;
        }

        if (extensions?.PromptCacheKey is not null)
        {
            request.PromptCacheKey = extensions.PromptCacheKey;
        }

        if (request.Reasoning is null && chatRequest.ReasoningEffort is not null)
        {
            request.Reasoning = new ReasoningConfiguration
            {
                Effort = chatRequest.ReasoningEffort.Value switch
                {
                    ChatReasoningEfforts.None => ResponseReasoningEfforts.None,
                    ChatReasoningEfforts.Minimal => ResponseReasoningEfforts.Minimal,
                    ChatReasoningEfforts.Low => ResponseReasoningEfforts.Low,
                    ChatReasoningEfforts.Medium => ResponseReasoningEfforts.Medium,
                    ChatReasoningEfforts.High => ResponseReasoningEfforts.High,
                    ChatReasoningEfforts.XHigh => ResponseReasoningEfforts.XHigh,
                    ChatReasoningEfforts.Max => ResponseReasoningEfforts.Max,
                    _ => ResponseReasoningEfforts.Medium
                }
            };
        }

        if (chatRequest.Model?.Name is not null && ChatModelPerplexity.AnthropicModelNames.Contains(chatRequest.Model.Name) && request.MaxOutputTokens is null)
        {
            request.MaxOutputTokens = chatRequest.MaxTokens ?? 8192;
        }

        ApplyTools(request, extensions);
    }

    private static void ApplyTools(ResponseRequest request, ChatRequestVendorPerplexityExtensions? extensions)
    {
        bool enableWebSearch = extensions?.EnableWebSearch is true || HasSearchFilters(extensions);
        bool enableFetchUrl = extensions?.EnableFetchUrl is true;
        bool enableFinanceSearch = extensions?.EnableFinanceSearch is true;
        bool enablePeopleSearch = extensions?.EnablePeopleSearch is true;
        bool enableSandbox = extensions?.EnableSandbox is true;

        if (!enableWebSearch && !enableFetchUrl && !enableFinanceSearch && !enablePeopleSearch && !enableSandbox)
        {
            return;
        }

        request.Tools ??= [];

        if (enableWebSearch && request.Tools.All(x => x is not ResponseWebSearchTool))
        {
            ResponseWebSearchTool webSearch = new ResponseWebSearchTool
            {
                WebSearchToolType = ResponseWebSearchToolType.WebSearch
            };

            if (extensions?.SearchContextSize is not null)
            {
                webSearch.SearchContextSize = extensions.SearchContextSize.Value switch
                {
                    ChatRequestVendorPerplexitySearchContextSizes.Low => ResponseSearchContextSize.Low,
                    ChatRequestVendorPerplexitySearchContextSizes.High => ResponseSearchContextSize.High,
                    _ => ResponseSearchContextSize.Medium
                };
            }

            JObject? filters = BuildWebSearchFilters(extensions);
            if (filters is not null)
            {
                webSearch.Filters = filters;
            }

            request.Tools.Add(webSearch);
        }

        if (enableFetchUrl && request.Tools.All(x => x is not ResponseHostedTool hosted || hosted.Type != "fetch_url"))
        {
            request.Tools.Add(new ResponseHostedTool("fetch_url"));
        }

        if (enableFinanceSearch && request.Tools.All(x => x is not ResponseHostedTool hosted || hosted.Type != "finance_search"))
        {
            request.Tools.Add(new ResponseHostedTool("finance_search"));
        }

        if (enablePeopleSearch && request.Tools.All(x => x is not ResponseHostedTool hosted || hosted.Type != "people_search"))
        {
            request.Tools.Add(new ResponseHostedTool("people_search"));
        }

        if (enableSandbox && request.Tools.All(x => x is not ResponseHostedTool hosted || hosted.Type != "sandbox"))
        {
            request.Tools.Add(new ResponseHostedTool("sandbox"));
        }
    }

    private static bool HasSearchFilters(ChatRequestVendorPerplexityExtensions? extensions)
    {
        if (extensions is null)
        {
            return false;
        }

        return extensions.SearchRecencyFilter is not null
               || extensions.SearchAfterDateFilter is not null
               || extensions.SearchBeforeDateFilter is not null
               || extensions.LastUpdatedAfterFilter is not null
               || extensions.LastUpdatedBeforeFilter is not null
               || extensions.LatestUpdated is not null
               || extensions.IncludeDomains?.Count > 0
               || extensions.ExcludeDomains?.Count > 0
               || extensions.SearchMode is not null
               || extensions.LanguagePreference?.Count > 0
               || extensions.UserLocation is not null;
    }

    private static JObject? BuildWebSearchFilters(ChatRequestVendorPerplexityExtensions? extensions)
    {
        if (extensions is null)
        {
            return null;
        }

        JObject filters = new JObject();

        if (extensions.SearchRecencyFilter is not null)
        {
            filters["search_recency_filter"] = extensions.SearchRecencyFilter;
        }

        if (extensions.IncludeDomains?.Count > 0 || extensions.ExcludeDomains?.Count > 0)
        {
            List<string> domainList = [];

            if (extensions.IncludeDomains is not null)
            {
                domainList.AddRange(extensions.IncludeDomains);
            }

            if (extensions.ExcludeDomains is not null)
            {
                domainList.AddRange(extensions.ExcludeDomains.Select(x => $"-{x}"));
            }

            filters["search_domain_filter"] = new JArray(domainList);
        }

        if (extensions.SearchAfterDateFilter is not null)
        {
            filters["published_after"] = extensions.SearchAfterDateFilter.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        if (extensions.SearchBeforeDateFilter is not null)
        {
            filters["published_before"] = extensions.SearchBeforeDateFilter.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        if (extensions.LatestUpdated is not null)
        {
            filters["latest_updated"] = extensions.LatestUpdated.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        if (extensions.SearchMode is ChatRequestVendorPerplexitySearchModes.Academic)
        {
            filters["search_domain"] = "academic";
        }
        else if (extensions.SearchMode is ChatRequestVendorPerplexitySearchModes.Sec)
        {
            filters["search_domain"] = "sec";
        }

        if (extensions.LanguagePreference?.Count > 0)
        {
            filters["language_preference"] = new JArray(extensions.LanguagePreference);
        }

        if (extensions.UserLocation is not null)
        {
            filters["user_location"] = extensions.UserLocation;
        }

        return filters.Count > 0 ? filters : null;
    }
}
