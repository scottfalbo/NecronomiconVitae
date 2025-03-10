// ------------------------------------
// Necronomicon Vitae
// ------------------------------------

using Microsoft.JSInterop;
using NecronomiconVitae.CorpusMaleficarum.Models;

namespace NecronomiconVitae.CorpusMaleficarum;

public interface IThemeService
{
    IEnumerable<Theme> AvailableThemes { get; }

    Theme CurrentTheme { get; }

    Task InitializeThemeAsync(IJSRuntime jsRuntime);

    Task SetThemeAsync(Theme theme, IJSRuntime jsRuntime);

    event Action? OnThemeChanged;
}