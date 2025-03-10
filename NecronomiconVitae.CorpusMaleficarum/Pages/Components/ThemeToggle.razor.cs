// ------------------------------------
// Necronomicon Vitae
// ------------------------------------

using Microsoft.AspNetCore.Components;
using NecronomiconVitae.CorpusMaleficarum.Models;

namespace NecronomiconVitae.CorpusMaleficarum.Pages.Components;

public partial class ThemeToggle : ComponentBase
{
    private bool _isInitialized = false;

    private Theme _selectedTheme;

    private Theme SelectedTheme
    {
        get => _selectedTheme;
        set
        {
            if (_selectedTheme != value)
            {
                _selectedTheme = value;
                _ = OnThemeChanged();
            }
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender && !_isInitialized)
        {
            _isInitialized = true;
            await ThemeService.InitializeThemeAsync(JSRuntime);
            _selectedTheme = ThemeService.CurrentTheme;
            StateHasChanged();
        }
    }

    protected override void OnInitialized()
    {
        _selectedTheme = ThemeService.CurrentTheme;
    }

    private async Task OnThemeChanged()
    {
        await ThemeService.SetThemeAsync(SelectedTheme, JSRuntime);
    }
}