// ------------------------------------
// Necronomicon Vitae
// ------------------------------------

using NecronomiconVitae.CorpusMaleficarum.Models;

namespace NecronomiconVitae.CorpusMaleficarum;

public interface IProcessor
{
    Task<IEnumerable<Image>> GetImages();
}