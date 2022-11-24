using Microsoft.AspNetCore.Components;
using NewGains.Client.Services;
using NewGains.DataTransfer.Templates;

namespace NewGains.Client.Pages.Templates;

public partial class TemplateDetails
{
    [Parameter]
    public int TemplateId { get; set; }

    [Inject]
    public ITemplateDataService TemplateDataService { get; set; } = default!;

    public TemplateDetailsDto? Template { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var templateDto = await TemplateDataService.GetTemplateDetails(TemplateId);

        if (templateDto is not null)
        {
            Template = templateDto;
        }
    }
}
