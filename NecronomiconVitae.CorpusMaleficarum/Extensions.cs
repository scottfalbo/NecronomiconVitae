// ------------------------------------
// Necronomicon Vitae
// ------------------------------------

using NecronomiconVitae.CorpusMaleficarum.Models;

namespace NecronomiconVitae.CorpusMaleficarum;

public static class Extensions
{
    public static void AddDefaultTags(this IEnumerable<Image> images)
    {
        foreach (var image in images)
        {
            image.Tags ??= [];
            image.Tags.Add(ImageTag.Image.ToString());
        }
    }

    public static void AssignIds(this IEnumerable<Image> images)
    {
        foreach (var image in images)
        {
            image.Id = $"image_{Guid.NewGuid()}";
        }
    }

    public static Dictionary<string, IEnumerable<Image>> GetImagesByTags(this IEnumerable<Image> images)
    {
        var imagesByTag = images
            .SelectMany(img => img.Tags!, (img, tag) => new { img, tag })
            .GroupBy(x => x.tag)
            .ToDictionary(g => g.Key, g => g.Select(x => x.img));

        return imagesByTag;
    }
}