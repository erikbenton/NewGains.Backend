using Microsoft.AspNetCore.Components;
using NewGains.Client.Enums;
using NewGains.Core.Entities;

namespace NewGains.Client.Components.Templates;

public partial class TemplateSetGroupEdit
{
    [Parameter]
    public TemplateSetGroup SetGroup { get; set; } = default!;

    [Parameter]
    public EventCallback<int> RemoveSetGroup { get; set; }

    [Parameter]
    public EventCallback<int> MoveSetGroupUp { get; set; }
    
    [Parameter]
    public EventCallback<int> MoveSetGroupDown { get; set; }

    public SetUnits WeightUnit { get; set; } = SetUnits.PercentIntensity;

    public SetUnits RepsTimeUnit { get; set; } = SetUnits.Reps;

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

    private void AddEmptySet()
    {
        var newSets = SetGroup.Sets.ToList();
        newSets.Add(new TemplateSet()
        {
            SetGroupId = SetGroup.Id,
            ExerciseId = SetGroup.Exercise!.Id,
            SetNumber = newSets.Count + 1,
        });

        SetGroup.Sets = newSets;
    }

    private void DeleteSet(int setNumber)
    {
        var sets = SetGroup.Sets
            .Where(set => set.SetNumber != setNumber)
            .ToList();

        for (int i = 0; i < sets.Count; i++)
        {
            sets[i].SetNumber = i+1;
        }

        SetGroup.Sets = sets;
    }
}
