using Microsoft.AspNetCore.Components;
using NewGains.Client.Enums;
using NewGains.Client.Models;

namespace NewGains.Client.Components.Workouts;

public partial class WorkoutSetGroupEdit
{
    [Parameter]
    public WorkoutSetGroup SetGroup { get; set; } = default!;

    public SetUnits WeightUnit { get; set; } = SetUnits.PercentIntensity;

    public SetUnits RepsTimeUnit { get; set; } = SetUnits.Reps;

    public SetUnits TargetWeightUnit { get; set; } = SetUnits.PercentIntensity;

    public SetUnits TargetRepsTimeUnit { get; set; } = SetUnits.Reps;

    private void SetWeightUnit(SetUnits weightUnit)
    {
        if (weightUnit == SetUnits.Time || weightUnit == SetUnits.Reps)
            return;

        WeightUnit = weightUnit;
        StateHasChanged();
    }

    private void SetRepsTimeUnit(SetUnits repsTimeUnit)
    {
        if (repsTimeUnit != SetUnits.Time && repsTimeUnit != SetUnits.Reps)
            return;

        RepsTimeUnit = repsTimeUnit;
        StateHasChanged();
    }

    private void SetTargetWeightUnit(SetUnits weightUnit)
    {
        if (weightUnit == SetUnits.Time || weightUnit == SetUnits.Reps)
            return;

        TargetWeightUnit = weightUnit;
        StateHasChanged();
    }

    private void SetTargetRepsTimeUnit(SetUnits repsTimeUnit)
    {
        if (repsTimeUnit != SetUnits.Time && repsTimeUnit != SetUnits.Reps)
            return;

        TargetRepsTimeUnit = repsTimeUnit;
        StateHasChanged();
    }
}
