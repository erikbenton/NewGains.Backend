using NewGains.Core.Enums;

namespace NewGains.Core.Extensions;

public static class CategoryExtensions
{
    public static string GetLabel(this Category category)
    {
        return category switch
        {
            Category.Barbell => "Barbell",
            Category.Dumbbell => "Dumbbell",
            Category.Machine => "Machine",
            Category.WeightedBodyweight => "Bodyweight",
            Category.Cardio => "Cardio",
            Category.Duration => "Duration",
            Category.Other => "Other",
            _ => "N/A"
        };
    }

    public static Category GetCategory(this string label)
    {
        return label switch
        {
            "Barbell" => Category.Barbell,
            "Dumbbell" => Category.Dumbbell,
            "Machine" => Category.Machine,
            "Bodyweight" => Category.WeightedBodyweight,
            "Cardio" => Category.Cardio,
            "Duration" => Category.Duration,
            "Other" => Category.Other,
            _ => Category.NA
        };
    }
}
