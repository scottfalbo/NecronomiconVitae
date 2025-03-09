// ------------------------------------
// Necronomicon Vitae
// ------------------------------------

namespace NecronomiconVitae.CorpusMaleficarum;

public interface IBlobStorageService
{
    Task<string> GetJsonBlob();
}