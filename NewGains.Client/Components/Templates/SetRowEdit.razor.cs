using Microsoft.AspNetCore.Components;
using NewGains.Client.Enums;
using NewGains.Core.Entities;

namespace NewGains.Client.Components.Templates;

public partial class SetRowEdit
{
    [Parameter]
    public TemplateSet Set { get; set; } = default!;

    [Parameter]
    public EventCallback<int> DeleteSet { get; set; }

    [Parameter]
    public SetUnits WeightUnit { get; set; } = SetUnits.PercentIntensity;

    [Parameter]
    public SetUnits RepsTimeUnit { get; set; } = SetUnits.Reps;

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
            if (Set.WeightInPounds != weightInKg * LbsPerKgFactor)
            {
                Set.WeightInPounds = weightInKg * LbsPerKgFactor;
                WeightInLbs = Set.WeightInPounds;
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
            Set.WeightInPounds = weightInLbs;

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
        WeightInLbs = Set.WeightInPounds;
    }
}
