using System;
using LlmTornado.Chat.Vendors.Anthropic;
using LlmTornado.Files;
using Newtonsoft.Json;

namespace LlmTornado.Chat;

/// <summary>
/// A content block that represents a file to be uploaded to the container. Files uploaded via this block will be available in the container's input directory.
/// </summary>
public class ChatMessagePartContainerUpload
{
    /// <summary>
    /// File ID.
    /// </summary>
    [JsonProperty("file_id")]
    public string FileId { get; set; }
    
    /// <summary>
    /// Cache control settings.
    /// </summary>
    [JsonProperty("cache_control")]
    public AnthropicCacheSettings? Cache { get; set; }
    
    /// <summary>
    /// Creates a new container upload data.<br/>
    /// </summary>
    public ChatMessagePartContainerUpload(string fileId)
    {
        FileId = fileId;
    }
    
    /// <summary>
    /// Creates a new container upload data.<br/>
    /// </summary>
    public ChatMessagePartContainerUpload(TornadoFile file)
    {
        FileId = file.Uri ?? file.Id;
    }
}

/// <summary>
/// URI-based file data.
/// </summary>
public class ChatMessagePartFileLinkData
{
    /// <summary>
    /// MIME type of the file. For OpenAI <c>input_file</c>, use types listed in <see cref="OpenAiInputFileTypes"/>.
    /// </summary>
    [JsonProperty("mimeType")]
    public string? MimeType { get; set; }
    
    /// <summary>
    /// URI of the file.
    /// </summary>
    [JsonProperty("fileUri")]
    public string FileUri { get; set; }
    
    /// <summary>
    /// State of the file
    /// </summary>
    [JsonIgnore]
    public FileLinkStates? State { get; set; }
    
    /// <summary>
    /// File from which this part was created.
    /// </summary>
    [JsonIgnore]
    public TornadoFile? File { get; set; }

    /// <summary>
    /// Gemini video processing mode. <see cref="ChatVideoProcessingMode.Agentic"/> is supported on Gemini 3.6 / 3.7 / 3.8 Flash and 3.5 Flash-Lite.
    /// </summary>
    [JsonIgnore]
    public ChatVideoProcessingMode? VideoProcessing { get; set; }

    /// <summary>
    /// Optional start offset when clipping a video. Only used with <see cref="ChatVideoProcessingMode.Static"/>.
    /// </summary>
    [JsonIgnore]
    public TimeSpan? VideoStartOffset { get; set; }

    /// <summary>
    /// Optional end offset when clipping a video. Only used with <see cref="ChatVideoProcessingMode.Static"/>.
    /// </summary>
    [JsonIgnore]
    public TimeSpan? VideoEndOffset { get; set; }

    /// <summary>
    /// Optional frame-rate sampling when reading a video. Range: (0.0, 24.0]. Only used with <see cref="ChatVideoProcessingMode.Static"/>.
    /// </summary>
    [JsonIgnore]
    public double? VideoFps { get; set; }

    /// <summary>
    /// Creates a new file link data, which can be used for constructing a message part.<br/>
    /// Supported URIs for Gemini: Files API upload URIs, registered GCS objects (<c>gs://</c> via register),
    /// public HTTPS URLs, and pre-signed URLs (S3 presigned, Azure SAS, etc.) up to 100 MB per request.
    /// YouTube URLs are supported on Gemini 2.0+.
    /// </summary>
    /// <param name="fileUri"></param>
    /// <param name="mimeType"></param>
    public ChatMessagePartFileLinkData(string fileUri, string? mimeType = null)
    {
        FileUri = fileUri;
        MimeType = mimeType;
    }
    
    /// <summary>
    /// Creates a new file link data from a file. This passes the state of the file, as well as the link and mime type.
    /// Supported URIs for Gemini: Files API upload URIs, registered GCS objects, public HTTPS URLs, and pre-signed URLs up to 100 MB per request.
    /// YouTube URLs are supported on Gemini 2.0+.
    /// </summary>
    /// <param name="file"></param>
    public ChatMessagePartFileLinkData(TornadoFile file)
    {
        FileUri = file.Reference;
        MimeType = file.MimeType ?? string.Empty;
        State = file.State;
        File = file;
    }
}

/// <summary>
/// How Gemini reads video inputs.
/// </summary>
public enum ChatVideoProcessingMode
{
    /// <summary>
    /// Extract frames at a fixed rate (default 1 FPS). Required for custom <c>fps</c> / clip offsets.
    /// </summary>
    Static,

    /// <summary>
    /// The model dynamically navigates the timeline, loading transcripts, frames, or audio on demand.
    /// Supported on Gemini 3.6 / 3.7 / 3.8 Flash and 3.5 Flash-Lite.
    /// </summary>
    Agentic
}

/// <summary>
/// States of file link data
/// </summary>
public enum FileLinkStates
{
    /// <summary>
    /// 	The default value. This value is used if the state is omitted.
    /// </summary>
    Unknown,
    
    /// <summary>
    ///     File is being processed and cannot be used for inference yet.
    /// </summary>
    Processing,
    
    /// <summary>
    /// 	File is processed and available for inference.
    /// </summary>
    Active,
    
    /// <summary>
    ///     File failed processing.
    /// </summary>
    Failed
}