using Microsoft.AspNetCore.Components;
using NewGains.Client.Services;
using NewGains.DataTransfer.Exercises;

namespace NewGains.Client.Pages;

public partial class ExerciseDetails
{
    [Parameter]
    public int? ExerciseId { get; set; }

    [Inject]
    public IExerciseDataService ExerciseDataService { get; set; } = default!;

    public ExerciseDetailsDto? Exercise { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        if (ExerciseId.HasValue)
        {
            Exercise = await ExerciseDataService.GetExerciseDetails(ExerciseId.Value);
        }
    }

    private void NavigateToExerciseEdit(int exerciseId)
    {
        NavigationManager.NavigateTo($"/exercises/edit/{exerciseId}");
    }
}
