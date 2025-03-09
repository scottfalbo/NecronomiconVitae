// ------------------------------------
// Necronomicon Vitae
// ------------------------------------

using Microsoft.AspNetCore.Components;
using NecronomiconVitae.CorpusMaleficarum.Models;

namespace NecronomiconVitae.CorpusMaleficarum.Pages;

public partial class Grimoire : ComponentBase
{
    private Dictionary<string, IEnumerable<Image>> Images = [];

    [Parameter]
    public string ImageType { get; set; } = default!;

    [Inject]
    private IProcessor _processor { get; set; } = default!;

    protected override async Task OnParametersSetAsync()
    {
        var images = await _processor.GetImages(ImageType);

        if (images != null)
        {
            Images = images;
        }
    }
}