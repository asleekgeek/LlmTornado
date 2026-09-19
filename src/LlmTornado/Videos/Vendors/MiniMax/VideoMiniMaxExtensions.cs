using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LlmTornado.Videos.Vendors.MiniMax;

/// <summary>
/// MiniMax-specific extensions for video generation requests.
/// </summary>
public class VideoMiniMaxExtensions
{
    /// <summary>
    /// Video resolution. Options depend on the model and duration.
    /// Defaults to 768P for Hailuo-2.3 and Hailuo-02 models, 720P for legacy models.
    /// </summary>
    public VideoMiniMaxResolution? Resolution { get; set; }
    
    /// <summary>
    /// Whether to automatically optimize the prompt. Defaults to true.
    /// Set to false for more precise control over the prompt.
    /// </summary>
    public bool? PromptOptimizer { get; set; }
    
    /// <summary>
    /// Reduces optimization time when <see cref="PromptOptimizer"/> is enabled.
    /// Defaults to false. Applies only to MiniMax-Hailuo-2.3, MiniMax-Hailuo-2.3-Fast, and MiniMax-Hailuo-02 models.
    /// </summary>
    public bool? FastPretreatment { get; set; }
    
    /// <summary>
    /// A callback URL to receive asynchronous task status updates.
    /// MiniMax sends a POST with a challenge field for validation, then pushes status updates.
    /// </summary>
    public string? CallbackUrl { get; set; }
    
    /// <summary>
    /// Aspect ratio for MiniMax-H3 / H3-Max. Text-to-video requires a concrete ratio
    /// (<c>21:9</c>, <c>16:9</c>, <c>4:3</c>, <c>1:1</c>, <c>3:4</c>, <c>9:16</c>).
    /// Image-to-video is always adaptive. Reference-to-video defaults to adaptive.
    /// </summary>
    public VideoMiniMaxAspectRatio? AspectRatio { get; set; }
    
    /// <summary>
    /// Prompt expansion mode for MiniMax-H3-Max. Defaults to <see cref="VideoMiniMaxPromptExpansionMode.Balanced"/>.
    /// </summary>
    public VideoMiniMaxPromptExpansionMode? PromptExpansionMode { get; set; }
    
    /// <summary>
    /// Reference audio URLs for H3 reference-to-video (up to 3 clips, 2–15s each).
    /// Public URL, <c>mm_file://{file_id}</c>, or data URI.
    /// </summary>
    public List<string>? ReferenceAudios { get; set; }
    
    /// <summary>
    /// Reference video URLs for H3 reference-to-video (up to 3 clips, 2–15s each, total ≤ 15s).
    /// Public URL, <c>mm_file://{file_id}</c>, or data URI.
    /// </summary>
    public List<string>? ReferenceVideos { get; set; }
}

/// <summary>
/// Video resolution options for MiniMax video generation.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum VideoMiniMaxResolution
{
    /// <summary>
    /// 480P resolution. Supported by MiniMax-H3-Max.
    /// </summary>
    [EnumMember(Value = "480P")]
    P480,
    
    /// <summary>
    /// 512P resolution. Supported by MiniMax-Hailuo-02 for image-to-video.
    /// </summary>
    [EnumMember(Value = "512P")]
    P512,
    
    /// <summary>
    /// 720P resolution. Default for legacy models (T2V-01, I2V-01, etc.).
    /// </summary>
    [EnumMember(Value = "720P")]
    P720,
    
    /// <summary>
    /// 768P resolution. Default for MiniMax-Hailuo-2.3 and MiniMax-Hailuo-02 models.
    /// </summary>
    [EnumMember(Value = "768P")]
    P768,
    
    /// <summary>
    /// 1080P resolution. Supported by Hailuo-2.3 and Hailuo-02 models (6s duration only).
    /// </summary>
    [EnumMember(Value = "1080P")]
    P1080,
    
    /// <summary>
    /// 2K resolution. Supported by MiniMax-H3 (not H3-Max).
    /// </summary>
    [EnumMember(Value = "2K")]
    P2K
}

/// <summary>
/// Aspect ratio options for MiniMax-H3 video generation.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum VideoMiniMaxAspectRatio
{
    /// <summary>
    /// Automatically choose the best ratio from the input. Required/forced for image-to-video.
    /// Not valid for text-to-video.
    /// </summary>
    [EnumMember(Value = "adaptive")]
    Adaptive,
    
    /// <summary>
    /// 21:9 cinematic widescreen.
    /// </summary>
    [EnumMember(Value = "21:9")]
    Cinema,
    
    /// <summary>
    /// 16:9 widescreen.
    /// </summary>
    [EnumMember(Value = "16:9")]
    Widescreen,
    
    /// <summary>
    /// 4:3 standard.
    /// </summary>
    [EnumMember(Value = "4:3")]
    Standard,
    
    /// <summary>
    /// 1:1 square.
    /// </summary>
    [EnumMember(Value = "1:1")]
    Square,
    
    /// <summary>
    /// 3:4 portrait.
    /// </summary>
    [EnumMember(Value = "3:4")]
    StandardPortrait,
    
    /// <summary>
    /// 9:16 vertical.
    /// </summary>
    [EnumMember(Value = "9:16")]
    Portrait
}

/// <summary>
/// Prompt expansion mode for MiniMax-H3-Max.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum VideoMiniMaxPromptExpansionMode
{
    /// <summary>
    /// Disable prompt expansion.
    /// </summary>
    [EnumMember(Value = "disabled")]
    Disabled,
    
    /// <summary>
    /// Balanced expansion. Default when omitted.
    /// </summary>
    [EnumMember(Value = "balanced")]
    Balanced,
    
    /// <summary>
    /// Prioritize expansion quality.
    /// </summary>
    [EnumMember(Value = "quality")]
    Quality
}
