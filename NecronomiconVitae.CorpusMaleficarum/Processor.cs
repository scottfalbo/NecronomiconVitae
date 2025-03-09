// ------------------------------------
// Necronomicon Vitae
// ------------------------------------

using NecronomiconVitae.CorpusMaleficarum.Models;
using System.Text.Json;

namespace NecronomiconVitae.CorpusMaleficarum;

public class Processor(IBlobStorageService blobStorageService) : IProcessor
{
    private readonly IBlobStorageService _blobStorageService = blobStorageService;

    public async Task<IEnumerable<Image>> GetImages(string imageType)
    {
        var metadataJson = await _blobStorageService.GetMetadataJson();

        var metadata = JsonSerializer.Deserialize<IEnumerable<Image>>(metadataJson) ?? [];

        var filteredMetadata = metadata.Where(x => x.ImageType == imageType);

        return filteredMetadata;
    }
}