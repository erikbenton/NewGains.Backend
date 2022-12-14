using Microsoft.AspNetCore.Components;
using NewGains.Client.Enums;
using NewGains.Client.Models;
using NewGains.Core.Entities;

namespace NewGains.Client.Components.Workouts;

public partial class WorkoutSetGroupEdit
{
    [Parameter]
    public WorkoutSetGroup SetGroup { get; set; } = default!;

    public SetUnits WeightUnit { get; set; } = SetUnits.PercentIntensity;

    public SetUnits RepsTimeUnit { get; set; } = SetUnits.Reps;

    public SetUnits TargetWeightUnit { get; set; } = SetUnits.PercentIntensity;

    public SetUnits TargetRepsTimeUnit { get; set; } = SetUnits.Reps;

    public void DeleteSet(int setNumber)
    {
        // Filter out set
        SetGroup.Sets = SetGroup.Sets
            .Where(set => set.SetNumber != setNumber)
            .ToList();

        // Re-number the sets
        for (int i = setNumber - 1; i < SetGroup.Sets.Count; i++)
        {
            SetGroup.Sets[i].SetNumber = i+1;
        }
    }

    private void AddSet()
    {
        WorkoutSet newSet = new(SetGroup.Id, SetGroup.Sets.Count() + 1, new TemplateSet());
        SetGroup.Sets.Add(newSet);
    }


    private void SetWeightUnit(SetUnits weightUnit)
    {
        if (weightUnit == SetUnits.Time || weightUnit == SetUnits.Reps)
            return;

        WeightUnit = weightUnit;
    }

    private void SetRepsTimeUnit(SetUnits repsTimeUnit)
    {
        if (repsTimeUnit != SetUnits.Time && repsTimeUnit != SetUnits.Reps)
            return;

        RepsTimeUnit = repsTimeUnit;
    }

    private void SetTargetWeightUnit(SetUnits weightUnit)
    {
        if (weightUnit == SetUnits.Time || weightUnit == SetUnits.Reps)
            return;

        TargetWeightUnit = weightUnit;
    }

    private void SetTargetRepsTimeUnit(SetUnits repsTimeUnit)
    {
        if (repsTimeUnit != SetUnits.Time && repsTimeUnit != SetUnits.Reps)
            return;

        TargetRepsTimeUnit = repsTimeUnit;
    }
}
