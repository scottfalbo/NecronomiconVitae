// ------------------------------------
// Necronomicon Vitae
// ------------------------------------

using Microsoft.AspNetCore.Components;
using NecronomiconVitae.CorpusMaleficarum.Models;

namespace NecronomiconVitae.CorpusMaleficarum.Pages;

public partial class Grimoire : ComponentBase
{
    private IList<Image> Images = [];

    [Inject]
    private IProcessor _processor { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        var images = await _processor.GetImages();

        if (images != null)
        {
            Images = images.ToList();
        }
    }
}