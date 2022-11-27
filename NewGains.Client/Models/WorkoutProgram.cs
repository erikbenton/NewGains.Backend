using NewGains.Core.Entities;

namespace NewGains.Client.Models;

public class WorkoutProgram
{
    public int Id { get; set; }

    public int? TemplateId { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string Note {  get; set; } = string.Empty;

    public DateTime StartTime { get; set; } = DateTime.Now;

    public TimeSpan WorkoutLength { get; set; }

    public List<WorkoutSetGroup> SetGroups { get; set; } = new();

    public WorkoutProgram()
    {

    }

    public WorkoutProgram(Template template)
    {
        TemplateId = template.Id;
        Name = template.Name;

        int setGroupNumber = 1;
        SetGroups = template.SetGroups
            .Select(setGroup => new WorkoutSetGroup(Id, setGroupNumber++, setGroup))
            .ToList();
    }
}
