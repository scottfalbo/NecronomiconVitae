// ------------------------------------
// Necronomicon Vitae
// ------------------------------------

using NecronomiconVitae.CorpusMaleficarum.Models;

namespace NecronomiconVitae.CorpusMaleficarum;

public interface IThemeService
{
    IEnumerable<Theme> AvailableThemes { get; }

    Theme CurrentTheme { get; }

    Task SetThemeAsync(Theme theme);

    event Action? OnThemeChanged;
}