using NewGains.Client.Enums;

namespace NewGains.Client.Extensions;

public static class SetUnitsExtensions
{
    public static string GetLabel(this SetUnits setUnit)
    {
        return setUnit switch
        {
            SetUnits.PercentIntensity => "% PR",
            SetUnits.Lbs => "lbs",
            SetUnits.Kg => "kg",
            SetUnits.Reps => "Reps",
            SetUnits.Time => "Time",
            _ => "n/a"
        };
    }
}
