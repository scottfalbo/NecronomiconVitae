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

    public async Task InitializeThemeAsync(IJSRuntime jsRuntime)
    {
        var storedTheme = await jsRuntime.InvokeAsync<string>("localStorage.getItem", "selectedTheme");

        if (!string.IsNullOrEmpty(storedTheme) && Enum.TryParse(storedTheme, out Theme loadedTheme))
        {
            _currentTheme = loadedTheme;
            OnThemeChanged?.Invoke();
        }
    }

    public async Task SetThemeAsync(Theme theme, IJSRuntime jsRuntime)
    {
        if (theme != _currentTheme)
        {
            _currentTheme = theme;
            await jsRuntime.InvokeVoidAsync("localStorage.setItem", "selectedTheme", theme.ToString());
            OnThemeChanged?.Invoke();
        }
    }

    public event Action? OnThemeChanged;
}