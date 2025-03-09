// ------------------------------------
// Necronomicon Vitae
// ------------------------------------

using NecronomiconVitae.CorpusMaleficarum.Models;

namespace NecronomiconVitae.CorpusMaleficarum;

public interface IProcessor
{
    Task<Dictionary<string, IEnumerable<Image>>> GetImages(string imageType);
}