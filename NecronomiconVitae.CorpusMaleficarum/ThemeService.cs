// ------------------------------------
// Necronomicon Vitae
// ------------------------------------

using Microsoft.JSInterop;
using NecronomiconVitae.CorpusMaleficarum.Models;

namespace NecronomiconVitae.CorpusMaleficarum;

public class ThemeService : IThemeService
{
    private Theme _currentTheme = Theme.Dark;

    public IEnumerable<Theme> AvailableThemes => Enum.GetValues(typeof(Theme)).Cast<Theme>();

    public Theme CurrentTheme => _currentTheme;

    public async Task SetThemeAsync(Theme theme, IJSRuntime jsRuntime)
    {
        _currentTheme = theme;
        await jsRuntime.InvokeVoidAsync("localStorage.setItem", "selectedTheme", theme.ToString());
        OnThemeChanged?.Invoke();
    }

    public event Action? OnThemeChanged;
}