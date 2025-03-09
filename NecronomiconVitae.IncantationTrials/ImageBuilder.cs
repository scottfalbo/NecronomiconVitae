// ------------------------------------
// Necronomicon Vitae
// ------------------------------------

using NecronomiconVitae.CorpusMaleficarum.Models;

namespace NecronomiconVitae.IncantationTrials;

public class ImageBuilder
{
    private string? _description = null;
    private string? _id = null;
    private string _imageType = ImageType.Illustration.ToString();
    private string _imageUrl = "https://image.jpg";
    private List<string>? _tags = null;
    private string _thumbnailUrl = "https://image_thumb.jpg";

    public Image Build()
    {
        var image = new Image()
        {
            Description = _description,
            Id = _id,
            ImageType = _imageType,
            ImageUrl = _imageUrl,
            Tags = _tags,
            ThumbnailUrl = _thumbnailUrl
        };

        return image;
    }

    public ImageBuilder WithDefaultTags(string tag)
    {
        _tags!.Add(ImageTag.Image.ToString());
        return this;
    }
}