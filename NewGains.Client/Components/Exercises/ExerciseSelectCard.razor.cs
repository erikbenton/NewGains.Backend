using Microsoft.AspNetCore.Components;
using NewGains.DataTransfer.Exercises;

namespace NewGains.Client.Components.Exercises;

public partial class ExerciseSelectCard
{
    [Parameter]
    public ExerciseDto Exercise { get; set; } = default!;

    [Parameter]
    public EventCallback<ExerciseDto> AddSelectedExercise { get; set; }

    [Parameter]
    public EventCallback<int> RemoveSelectedExercise { get; set; }

    public bool IsSelected { get; set; } = false;

    private async Task HandleClick(ExerciseDto exercise)
    {
        if (IsSelected)
        {
            await RemoveExerciseFromSelection(exercise.Id);
        }
        else
        {
            await AddExerciseToSelection(exercise);
        }
    }

    private async Task AddExerciseToSelection(ExerciseDto exerciseId)
    {
        IsSelected = true;
        await AddSelectedExercise.InvokeAsync(exerciseId);
    }

    private async Task RemoveExerciseFromSelection(int exerciseId)
    {
        IsSelected = false;
        await RemoveSelectedExercise.InvokeAsync(exerciseId);
    }
}
