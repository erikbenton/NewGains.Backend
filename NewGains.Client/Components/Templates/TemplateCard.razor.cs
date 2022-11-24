using Microsoft.AspNetCore.Components;
using NewGains.DataTransfer.Templates;

namespace NewGains.Client.Components.Templates;

public partial class TemplateCard
{
    [Parameter]
    public TemplateDto Template { get; set; } = default!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = default!;

    public void NavigateToTemplateDetails(int templateId)
    {
        NavigationManager.NavigateTo($"templates/{templateId}");
    }
}