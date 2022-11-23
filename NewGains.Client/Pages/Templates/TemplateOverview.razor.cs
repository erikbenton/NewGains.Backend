using Microsoft.AspNetCore.Components;
using NewGains.Client.Services;
using NewGains.DataTransfer.Templates;

namespace NewGains.Client.Pages.Templates;

public partial class TemplateOverview
{
    public IEnumerable<TemplateDto>? Templates { get; set; }

    [Inject]
    public ITemplateDataService TemplateDataService { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        Templates = await TemplateDataService.GetAllTemplates();

        if (Templates is null)
        {
            Templates = new List<TemplateDto>();
        }
    }
}
