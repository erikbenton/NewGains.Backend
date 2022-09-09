using NewGains.Core.Entities;
using NewGains.Core.Enums;
using NewGains.Core.Extensions;

namespace NewGains.API.Dtos.Exercises;

public record ExerciseDto
{
    public int Id { get; }

    public string Name { get; }

    public string Category { get; }

    public string BodyPart { get; }

    public ExerciseDto(int id, string name, Category category, BodyPart bodyPart)
    {
        Id = id;
        Name = name;
        Category = category.GetLabel();
        BodyPart = bodyPart.GetLabel();
    }

    public ExerciseDto(Exercise exercise)
    {
        Id = exercise.Id;
        Name = exercise.Name;
        Category = exercise.Category.GetLabel();
        BodyPart = exercise.BodyPart.GetLabel();
    }
}
