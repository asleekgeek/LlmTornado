using System;
using LlmTornado.Images.Models;

namespace LlmTornado.Images;

/// <summary>
/// Helpers for GPT Image model families, including gpt-image-2-specific API constraints.
/// </summary>
internal static class GptImageModelHelper
{
	/// <summary>
	/// Returns true for gpt-image-* and chatgpt-image-* models.
	/// </summary>
	public static bool IsGptImageModel(ImageModel? model)
	{
		string? name = model?.GetApiName;
		return name is not null && (name.StartsWith("gpt-image", StringComparison.OrdinalIgnoreCase) || name.StartsWith("chatgpt-image", StringComparison.OrdinalIgnoreCase));
	}

	/// <summary>
	/// Returns true for gpt-image-2 and dated snapshots (e.g. gpt-image-2-2026-04-21),
	/// but not GPT Image 2.5 models.
	/// </summary>
	public static bool IsGptImage2Model(ImageModel? model)
	{
		string? name = model?.GetApiName;
		return name is not null && (
			name.Equals("gpt-image-2", StringComparison.OrdinalIgnoreCase) ||
			name.StartsWith("gpt-image-2-", StringComparison.OrdinalIgnoreCase));
	}

	/// <summary>
	/// Applies gpt-image rules: no response_format.
	/// Transparent backgrounds are supported for gpt-image-2 (preview as of August 20, 2026) and GPT Image 2.5.
	/// </summary>
	public static ImageGenerationRequest SanitizeGenerationRequest(ImageGenerationRequest request)
	{
		if (!IsGptImageModel(request.Model) || request.ResponseFormat is null)
		{
			return request;
		}

		ImageGenerationRequest clone = new ImageGenerationRequest(request)
		{
			ResponseFormat = null
		};

		return clone;
	}

	/// <summary>
	/// Applies gpt-image-2 rules: input_fidelity must be omitted (high fidelity is automatic).
	/// Transparent backgrounds are supported as of August 20, 2026.
	/// </summary>
	public static ImageEditRequest SanitizeEditRequest(ImageEditRequest request)
	{
		if (!IsGptImage2Model(request.Model) || request.InputFidelity is null)
		{
			return request;
		}

		ImageEditRequest clone = new ImageEditRequest(request)
		{
			InputFidelity = null
		};

		return clone;
	}
}
