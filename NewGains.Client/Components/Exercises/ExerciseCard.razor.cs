using Microsoft.AspNetCore.Components;
using NewGains.DataTransfer.Exercises;

namespace NewGains.Client.Components.Exercises;

public partial class ExerciseCard
{
    [Parameter]
    public ExerciseDto Exercise { get; set; } = default!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = default!;

    private void NavigateToExerciseDetails(int exerciseId)
    {
        NavigationManager.NavigateTo($"/exercises/{exerciseId}");
    }
}
