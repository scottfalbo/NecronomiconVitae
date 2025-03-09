// ------------------------------------
// Necronomicon Vitae
// ------------------------------------

using NecronomiconVitae.CorpusMaleficarum.Models;
using System.Text.Json;

namespace NecronomiconVitae.CorpusMaleficarum;

public class Processor(IBlobStorageService blobStorageService) : IProcessor
{
    private readonly IBlobStorageService _blobStorageService = blobStorageService;

    public async Task<Dictionary<string, IEnumerable<Image>>> GetImages(string imageType)
    {
        var metadataJson = await _blobStorageService.GetMetadataJson();

        var images = JsonSerializer.Deserialize<IEnumerable<Image>>(metadataJson) ?? [];

        images.AssignIds();
        images.AddDefaultTags();

        var filteredImages = images.Where(x => x.ImageType == imageType);

        var imagesByTags = filteredImages.GetImagesByTags();

        return imagesByTags;
    }
}