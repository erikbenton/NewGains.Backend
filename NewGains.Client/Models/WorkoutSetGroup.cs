using NewGains.Core.Entities;

namespace NewGains.Client.Models;

public class WorkoutSetGroup
{
    public int Id { get; set; }

    public int WorkoutId { get; set; }

    public int SetGroupNumber { get; set; }

    public Exercise Exercise { get; set; }

    public string Note { get; set; } = string.Empty;

    public TimeSpan RestBetweenSets { get; set; }
    
    public List<WorkoutSet> Sets { get; set; } = new();

    public WorkoutSetGroup(int workoutId, int setGroupNumber, TemplateSetGroup setGroup)
    {
        WorkoutId = workoutId;
        SetGroupNumber = setGroupNumber;
        Exercise = setGroup.Exercise ?? throw new ArgumentNullException();

        int setNumber = 1;
        Sets = setGroup.Sets
            .Select(set => new WorkoutSet(Id, setNumber++, set))
            .ToList();
    }
}
