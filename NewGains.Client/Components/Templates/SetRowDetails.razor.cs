using Microsoft.AspNetCore.Components;
using NewGains.Client.Enums;
using NewGains.DataTransfer.Templates;

namespace NewGains.Client.Components.Templates;

public partial class SetRowDetails
{
    [Parameter]
    public TemplateSetDetailsDto Set { get; set; } = default!;

    [Parameter]
    public int SetNumber { get; set; }

    [Parameter]
    public SetUnits WeightUnit { get; set; } = SetUnits.PercentIntensity;

    [Parameter]
    public SetUnits RepsTimeUnit { get; set; } = SetUnits.Reps;

    public string WeightAmount { get; set; } = string.Empty;

    public string RepsTimeAmount { get; set; } = string.Empty;

    protected override void OnParametersSet()
    {
        FormatWeightAmount();
        FormatRepsTimeAmount();
    }

    private void FormatRepsTimeAmount()
    {
        switch (RepsTimeUnit)
        {
            case SetUnits.PercentIntensity:
                RepsTimeAmount = "?";
                break;

            case SetUnits.Lbs:
                RepsTimeAmount = "?";
                break;

            case SetUnits.Kg:
                RepsTimeAmount = "?";
                break;

            case SetUnits.Reps:
                if (Set.Reps is not null)
                {
                    RepsTimeAmount = Set.Reps.ToString() ?? "?";
                }
                else
                {
                    RepsTimeAmount = "?";
                }
                break;

            case SetUnits.Time:
                if (Set.TimeInSeconds is not null)
                {
                    TimeSpan timeSpan = TimeSpan.FromSeconds(Set.TimeInSeconds.Value);
                    RepsTimeAmount = timeSpan.ToString(@"hh\:mm\:ss");
                }
                else
                {
                    RepsTimeAmount = "?";
                }
                break;

            default:
                RepsTimeAmount = "?";
                break;
        }
    }

    private void FormatWeightAmount()
    {
        switch (WeightUnit)
        {
            case SetUnits.PercentIntensity:
                if (Set.PercentIntensity is not null)
                {
                    WeightAmount = Set.PercentIntensity.ToString() ?? "?";
                }
                else
                {
                    WeightAmount = "?";
                }
                break;

            case SetUnits.Lbs:
                if (Set.WeightInPounds is not null)
                {
                    WeightAmount = Set.WeightInPounds.ToString() ?? "?";
                }
                else
                {
                    WeightAmount = "?";
                }
                break;

            case SetUnits.Kg:
                if (Set.WeightInPounds is not null)
                {
                    WeightAmount = (Set.WeightInPounds / 2.205).ToString() ?? "?";
                }
                else
                {
                    WeightAmount = "?";
                }
                break;

            case SetUnits.Reps:
                WeightAmount = "?";
                break;

            case SetUnits.Time:
                WeightAmount = "?";
                break;

            default:
                WeightAmount = "?";
                break;
        }

        switch (RepsTimeUnit)
        {
            case SetUnits.PercentIntensity:
                break;
            case SetUnits.Lbs:
                break;
            case SetUnits.Kg:
                break;
            case SetUnits.Reps:
                break;
            case SetUnits.Time:
                break;
            default:
                break;
        }
    }
}
