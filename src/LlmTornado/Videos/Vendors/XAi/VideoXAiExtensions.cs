using System.Collections.Generic;
using LlmTornado.Images;

namespace LlmTornado.Videos.Vendors.XAi;

/// <summary>
/// xAI-specific extensions for video generation requests.
/// </summary>
public class VideoXAiExtensions
{
    /// <summary>
    /// A unique identifier representing your end-user.
    /// Can be used for tracking and rate limiting purposes.
    /// </summary>
    public string? User { get; set; }
    
    /// <summary>
    /// Optional signed URL to upload the generated video via HTTP PUT.
    /// If provided, the video will be uploaded to this URL instead of being returned via the API.
    /// </summary>
    public string? UploadUrl { get; set; }
    
    /// <summary>
    /// Specifies the detail level of the input image for image-to-video generation.
    /// </summary>
    public ImageDetail? ImageDetail { get; set; }
    
    /// <summary>
    /// Files API IDs for reference-to-video on Imagine Video 1.5.
    /// </summary>
    public List<string>? ReferenceImageFileIds { get; set; }
    
    /// <summary>
    /// Optional preset voice for reference-to-video on Imagine Video 1.5.
    /// </summary>
    public string? Voice { get; set; }
}
