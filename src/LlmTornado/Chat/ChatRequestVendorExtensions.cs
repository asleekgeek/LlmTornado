using LlmTornado.Chat.Vendors.Alibaba;
using LlmTornado.Chat.Vendors.Anthropic;
using LlmTornado.Chat.Vendors.Cohere;
using LlmTornado.Chat.Vendors.Google;
using LlmTornado.Chat.Vendors.Groq;
using LlmTornado.Chat.Vendors.MiniMax;
using LlmTornado.Chat.Vendors.Mistral;
using LlmTornado.Chat.Vendors.Perplexity;
using LlmTornado.Chat.Vendors.XAi;
using LlmTornado.Chat.Vendors.Zai;

namespace LlmTornado.Chat;

/// <summary>
///     Chat outbound features supported only by a single/few providers with no shared equivalent.
/// </summary>
public class ChatRequestVendorExtensions
{
    /// <summary>
    ///     Cohere extensions.
    /// </summary>
    public ChatRequestVendorCohereExtensions? Cohere { get; set; }
    
    /// <summary>
    ///     Anthropic extensions.
    /// </summary>
    public ChatRequestVendorAnthropicExtensions? Anthropic { get; set; }
    
    /// <summary>
    ///     Google extensions.
    /// </summary>
    public ChatRequestVendorGoogleExtensions? Google { get; set; }
    
    /// <summary>
    ///     Mistral extensions.
    /// </summary>
    public ChatRequestVendorMistralExtensions? Mistral { get; set; }
    
    /// <summary>
    ///     Perplexity extensions.
    /// </summary>
    public ChatRequestVendorPerplexityExtensions? Perplexity { get; set; }
    
    /// <summary>
    ///     xAI extensions.
    /// </summary>
    public ChatRequestVendorXAiExtensions? XAi { get; set; }
    
    /// <summary>
    ///     ZAI extensions.
    /// </summary>
    public ChatRequestVendorZaiExtensions? Zai { get; set; }
    
    /// <summary>
    ///     MiniMax extensions.
    /// </summary>
    public ChatRequestVendorMiniMaxExtensions? MiniMax { get; set; }
    
    /// <summary>
    ///     Alibaba Cloud Model Studio (DashScope) extensions.
    /// </summary>
    public ChatRequestVendorAlibabaExtensions? Alibaba { get; set; }
    
    /// <summary>
    ///     Groq extensions.
    /// </summary>
    public ChatRequestVendorGroqExtensions? Groq { get; set; }

    /// <summary>
    ///     Empty extensions.
    /// </summary>
    public ChatRequestVendorExtensions()
    {
        
    }

    /// <summary>
    ///     Cohere extensions.
    /// </summary>
    /// <param name="cohereExtensions"></param>
    public ChatRequestVendorExtensions(ChatRequestVendorCohereExtensions cohereExtensions)
    {
        Cohere = cohereExtensions;
    }
    
    /// <summary>
    ///     Anthropic extensions.
    /// </summary>
    /// <param name="anthropicExtensions"></param>
    public ChatRequestVendorExtensions(ChatRequestVendorAnthropicExtensions anthropicExtensions)
    {
        Anthropic = anthropicExtensions;
    }

    /// <summary>
    ///     Google extensions.
    /// </summary>
    /// <param name="googleExtensions"></param>
    public ChatRequestVendorExtensions(ChatRequestVendorGoogleExtensions googleExtensions)
    {
        Google = googleExtensions;
    }
    
    /// <summary>
    ///     Mistral extensions.
    /// </summary>
    /// <param name="mistralExtensions"></param>
    public ChatRequestVendorExtensions(ChatRequestVendorMistralExtensions mistralExtensions)
    {
        Mistral = mistralExtensions;
    }
    
    /// <summary>
    ///     Perplexity extensions.
    /// </summary>
    /// <param name="perplexityExtensions"></param>
    public ChatRequestVendorExtensions(ChatRequestVendorPerplexityExtensions perplexityExtensions)
    {
        Perplexity = perplexityExtensions;
    }
    
    /// <summary>
    ///     XAi extensions.
    /// </summary>
    /// <param name="xaiExtensions"></param>
    public ChatRequestVendorExtensions(ChatRequestVendorXAiExtensions xaiExtensions)
    {
        XAi = xaiExtensions;
    }
    
    /// <summary>
    ///     ZAI extensions.
    /// </summary>
    /// <param name="zaiExtensions"></param>
    public ChatRequestVendorExtensions(ChatRequestVendorZaiExtensions zaiExtensions)
    {
        Zai = zaiExtensions;
    }
    
    /// <summary>
    ///     Alibaba Cloud Model Studio (DashScope) extensions.
    /// </summary>
    /// <param name="alibabaExtensions"></param>
    public ChatRequestVendorExtensions(ChatRequestVendorAlibabaExtensions alibabaExtensions)
    {
        Alibaba = alibabaExtensions;
    }
    
    /// <summary>
    ///     MiniMax extensions.
    /// </summary>
    /// <param name="miniMaxExtensions"></param>
    public ChatRequestVendorExtensions(ChatRequestVendorMiniMaxExtensions miniMaxExtensions)
    {
        MiniMax = miniMaxExtensions;
    }
    
    /// <summary>
    ///     Groq extensions.
    /// </summary>
    /// <param name="groqExtensions"></param>
    public ChatRequestVendorExtensions(ChatRequestVendorGroqExtensions groqExtensions)
    {
        Groq = groqExtensions;
    }
}