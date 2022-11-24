using Microsoft.AspNetCore.Components;
using NewGains.Client.Enums;
using NewGains.DataTransfer.Templates;

namespace NewGains.Client.Components.Templates;

public partial class SetGroupDetails
{
    [Parameter]
    public TemplateSetGroupDetailsDto SetGroup { get; set; } = default!;

    public int SetNumber { get; set; } = 1;

    public SetUnits WeightUnit { get; set; } = SetUnits.PercentIntensity;

    public SetUnits RepsTimeUnit { get; set; } = SetUnits.Reps;

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
}
