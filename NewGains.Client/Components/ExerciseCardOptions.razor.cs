using Microsoft.AspNetCore.Components;

namespace NewGains.Client.Components;

public partial class ExerciseCardOptions
{
    [Parameter]
    public int ExerciseId { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; } = default!;

    private void NavigateToExerciseDetails(int exerciseId)
    {
        NavigationManager.NavigateTo($"/exercises/{exerciseId}");
    }
}
