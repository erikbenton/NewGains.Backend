using Microsoft.AspNetCore.Components;
using NewGains.Client.Services;
using NewGains.DataTransfer.Exercises;

namespace NewGains.Client.Pages.Exercises;

public partial class ExerciseOverview
{
    [Inject]
    public IExerciseDataService ExerciseDataService { get; set; } = default!;

    public IEnumerable<ExerciseDto>? Exercises { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Exercises = await ExerciseDataService.GetAllExercises();
    }
}
