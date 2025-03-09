// ------------------------------------
// Necronomicon Vitae
// ------------------------------------

namespace NecronomiconVitae.CorpusMaleficarum.Models;

public class Image
{
    public string? Description { get; set; }

    public string? Id { get; set; }

    public string ImageType { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public List<string>? Tags { get; set; }

    public string ThumbnailUrl { get; set; } = string.Empty;
}