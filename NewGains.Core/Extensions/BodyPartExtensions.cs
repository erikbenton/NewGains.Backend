using NewGains.Core.Enums;

namespace NewGains.Core.Extensions;

public static class BodyPartExtensions
{
    public static string GetLabel(this BodyPart bodyPart)
    {
        return bodyPart switch
        {
            BodyPart.Arms => "Arms",
            BodyPart.Back => "Back",
            BodyPart.Chest => "Chest",
            BodyPart.Core => "Core",
            BodyPart.Legs => "Legs",
            BodyPart.Shoulders => "Shoulders",
            BodyPart.Other => "Other",
            _ => "N/A",
        };
    }

    public static BodyPart GetBodyPart(this string label)
    {
        return label switch
        {
            "Arms" => BodyPart.Arms,
            "Back" => BodyPart.Back,
            "Chest" => BodyPart.Chest,
            "Core" => BodyPart.Core,
            "Legs" => BodyPart.Legs,
            "Shoulders" => BodyPart.Shoulders,
            "Other" => BodyPart.Other,
            _ => BodyPart.NA,
        };
    }
}
