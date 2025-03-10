// ------------------------------------
// Necronomicon Vitae
// ------------------------------------

using NecronomiconVitae.CorpusMaleficarum.Models;

namespace NecronomiconVitae.CorpusMaleficarum;

public class ThemeService : IThemeService
{
    private Theme _currentTheme = Theme.Dark;

    public IEnumerable<Theme> AvailableThemes => Enum.GetValues(typeof(Theme)).Cast<Theme>();

    public Theme CurrentTheme => _currentTheme;

    public Task SetThemeAsync(Theme theme)
    {
        _currentTheme = theme;
        OnThemeChanged?.Invoke();

        return Task.CompletedTask;
    }

    public event Action? OnThemeChanged;
}