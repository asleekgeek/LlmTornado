namespace LlmTornado.Images.Vendors.XAi;

/// <summary>
/// Extensions to image edit request for xAI.
/// </summary>
public class ImageEditRequestXAiExtensions
{
    /// <summary>
    /// Resolution of the generated image. Defaults to 1k. Grok Imagine Image 2.0 also supports 2k.
    /// Aspect ratio is automatically detected from the first input image unless <see cref="AspectRatio"/> is set.
    /// </summary>
    public ImageResolution? Resolution { get; set; }
    
    /// <summary>
    /// Override the output aspect ratio. When omitted, the first source image's ratio is used.
    /// Imagine editing accepts up to 5 source images.
    /// </summary>
    public ImageAspectRatio? AspectRatio { get; set; }
    
    /// <summary>
    /// Specifies the detail level of the input image. Optional.
    /// </summary>
    public ImageDetail? ImageDetail { get; set; }
    
    /// <summary>
    /// Specifies the detail level of the mask image. Optional.
    /// </summary>
    public ImageDetail? MaskDetail { get; set; }
}
