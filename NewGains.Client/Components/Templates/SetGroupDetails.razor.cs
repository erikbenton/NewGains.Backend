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

    protected override void OnInitialized()
    {
        DetermineUnitsToDisplay();
    }

    private void DetermineUnitsToDisplay()
    {
        // If any times are specified in the Sets
        var anyTimesSpecified = SetGroup.Sets.Any(set => set.TimeInSeconds is not null);
        if (anyTimesSpecified)
        {
            // Display the time
            RepsTimeUnit = SetUnits.Time;
        }

        var anyWeightsSpecified = SetGroup.Sets.Any(set => set.WeightInPounds is not null);
        var anyPercentIntensitiesSpecified = SetGroup.Sets.Any(set => set.PercentIntensity is not null);

        // If any weights are specified AND there are NO % PRs specified
        if (anyWeightsSpecified && !anyPercentIntensitiesSpecified)
        {
            // Display weights
            WeightUnit = SetUnits.Lbs;
        }
    }

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
