using NewGains.Core.Entities;

namespace NewGains.Client.Models;

public class WorkoutSet
{
    public int Id { get; set; }

    public int SetGroupId { get; set; }

    public int SetNumber { get; set; }

    public double? TargetPercentIntensity { get; set; }
    
    public double? TargetWeightInPounds { get; set; }
    
    public int? TargetReps { get; set; }

    public TimeSpan? TargetTime { get; set; }

    public double? LoggedPercentIntensity { get; set; }

    public double? LoggedWeightInPounds { get; set; }

    public int? LoggedReps { get; set; }

    public TimeSpan? LoggedTime { get; set; }

    public bool Completed { get; set; } = false;

    public WorkoutSet(int setGroupId, int setNumber, TemplateSet set)
    {
        SetGroupId = setGroupId;
        SetNumber = setNumber;
        TargetPercentIntensity = set.PercentIntensity;
        TargetWeightInPounds = set.WeightInPounds;
        TargetReps = set.Reps;
        TargetTime = set.TimeInSeconds.HasValue
            ? new TimeSpan(0, 0, set.TimeInSeconds.Value)
            : null;
    }
}
