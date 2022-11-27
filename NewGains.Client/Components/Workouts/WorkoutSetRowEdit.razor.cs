using Microsoft.AspNetCore.Components;
using NewGains.Client.Enums;
using NewGains.Client.Models;

namespace NewGains.Client.Components.Workouts;

public partial class WorkoutSetRowEdit
{
    [Parameter]
    public WorkoutSet Set { get; set; } = default!;

    [Parameter]
    public SetUnits WeightUnit { get; set; } = SetUnits.PercentIntensity;

    [Parameter]
    public SetUnits RepsTimeUnit { get; set; } = SetUnits.Reps;

    [Parameter]
    public SetUnits TargetWeightUnit { get; set; } = SetUnits.PercentIntensity;

    [Parameter]
    public SetUnits TargetRepsTimeUnit { get; set; } = SetUnits.Reps;

    private double? TargetWeightInKg;

    private const double LbsPerKgFactor = 2.205;

    private double? weightInKg;

    /// <summary>
    /// Weight in Kilograms for display/edit.
    /// Used for converting Lbs to Kg.
    /// </summary>
    public double? WeightInKg
    {
        get
        {
            // Truncate to just 2 digits
            return weightInKg.HasValue
                ? Math.Floor(weightInKg.Value * 100) / 100
                : null;
        }
        set
        {
            weightInKg = value;

            // Update the Set if the values are different
            // Conversion needed
            if (Set.LoggedWeightInPounds != weightInKg * LbsPerKgFactor)
            {
                Set.LoggedWeightInPounds = weightInKg * LbsPerKgFactor;
                WeightInLbs = Set.LoggedWeightInPounds;
            }
        }
    }

    private double? weightInLbs;

    /// <summary>
    /// Weight in Pounds for display/edit.
    /// Used for converting Lbs to Kg.
    /// </summary>
    public double? WeightInLbs
    {
        get { return weightInLbs; }
        set
        {
            weightInLbs = value;

            // Update the Set
            Set.LoggedWeightInPounds = weightInLbs;

            // Update the Kg Weight if the values are different
            // Conversion needed
            if (WeightInKg != weightInLbs / LbsPerKgFactor)
            {
                WeightInKg = weightInLbs / LbsPerKgFactor;
            }
        }
    }

    protected override void OnInitialized()
    {
        if (Set.TargetWeightInPounds is not null)
        {
            var targetKgWeight = Set.TargetWeightInPounds.Value / LbsPerKgFactor;
            TargetWeightInKg = Math.Floor(targetKgWeight * 100) / 100;
        }
    }
}
