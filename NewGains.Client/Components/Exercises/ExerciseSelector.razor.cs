using Microsoft.AspNetCore.Components;
using NewGains.Client.Services;
using NewGains.DataTransfer.Exercises;

namespace NewGains.Client.Components.Exercises;

public partial class ExerciseSelector
{
    [Inject]
    public IExerciseDataService ExerciseDataService { get; set; } = default!;

    [Parameter]
    public EventCallback<List<ExerciseDto>> AddAllSelectedExercises { get; set; } = default;

    [Parameter]
    public EventCallback CancelSelection { get; set; } = default;

    public IEnumerable<ExerciseDto> Exercises { get; set; } = default!;

    public List<ExerciseDto> SelectedExercises { get; set; } = new();

    public bool IsLoading { get; set; } = true;

    protected override async Task OnInitializedAsync()
    {
        var exercises = await ExerciseDataService.GetAllExercises();

        Exercises = exercises ?? new List<ExerciseDto>();

        IsLoading = false;
    }

    public void AddSelectedExercise(ExerciseDto exercise)
    {
        SelectedExercises.Add(exercise);
    }

    public void RemoveSelectedExercise(int exerciseId)
    {
        SelectedExercises = SelectedExercises
            .Where(e => e.Id != exerciseId)
            .ToList();
    }
}
