// ------------------------------------
// Necronomicon Vitae
// ------------------------------------

using NecronomiconVitae.CorpusMaleficarum.Models;
using System.Text.Json;

namespace NecronomiconVitae.CorpusMaleficarum;

public class Processor(IBlobStorageService blobStorageService) : IProcessor
{
    private readonly IBlobStorageService _blobStorageService = blobStorageService;

    public async Task<IEnumerable<Image>> GetImages()
    {
        var metadataJson = await _blobStorageService.GetMetadataJson();

        var metadata = JsonSerializer.Deserialize<IEnumerable<Image>>(metadataJson) ?? [];

        return metadata;
    }
}