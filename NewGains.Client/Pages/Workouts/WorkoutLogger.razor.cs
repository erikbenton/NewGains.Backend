using Microsoft.AspNetCore.Components;
using NewGains.Client.Models;
using NewGains.Client.Services;
using NewGains.DataTransfer.Mappers;

namespace NewGains.Client.Pages.Workouts;

public partial class WorkoutLogger
{
    [Parameter]
    public int? TemplateId { get; set; }

    public WorkoutProgram Workout { get; set; } = new();

    [Inject]
    public ITemplateDataService TemplateDataService { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        var pushTemplateDto = await TemplateDataService.GetTemplateDetails(TemplateId ?? 1);
        if (pushTemplateDto is not null)
        {
            var pushTemplate = TemplateMapper.MapToTemplate(pushTemplateDto);
            Workout = new(pushTemplate);
        }
    }
}
