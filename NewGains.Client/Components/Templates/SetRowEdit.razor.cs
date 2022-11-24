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

    private double? weightInKg;

    public double? WeightInKg
    { 
        get
        {
            return weightInKg.HasValue
                ? Math.Floor(weightInKg.Value * 10000) / 10000
                : null;
        }
        set
        {
            weightInKg = value;
            if (Set.WeightInPounds != weightInKg * 2.205)
            {
                Set.WeightInPounds = weightInKg * 2.205;
                WeightInLbs = Set.WeightInPounds;
            }
        }
    }

    private double? weightInLbs;

    public double? WeightInLbs
    {
        get { return weightInLbs; }
        set
        {
            weightInLbs = value;
            if (WeightInKg != weightInLbs / 2.205)
            {
                WeightInKg = weightInLbs / 2.205;
            }
            Set.WeightInPounds = weightInLbs;
        }
    }
}
