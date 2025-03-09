// ------------------------------------
// Necronomicon Vitae
// ------------------------------------

using Azure.Storage.Blobs;
using NecronomiconVitae.CorpusMaleficarum.Models;
using System.Text;

namespace NecronomiconVitae.CorpusMaleficarum;

public class BlobStorageService(BlobServiceClient blobServiceClient) : IBlobStorageService
{
    private readonly BlobServiceClient _blobServiceClient = blobServiceClient;

    public async Task<string> GetMetadataJson()
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(BlobStorage.ContainerName);
        var blobClient = containerClient.GetBlobClient(BlobStorage.MetadataPath);

        using var stream = await blobClient.OpenReadAsync();
        using var reader = new StreamReader(stream, Encoding.UTF8);
        var json = await reader.ReadToEndAsync();

        return json;
    }
}