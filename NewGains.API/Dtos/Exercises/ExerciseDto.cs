using System.ComponentModel.DataAnnotations;

namespace NewGains.API.Dtos.Exercises;

public record ExerciseDto
{
    [Required]
    public int Id { get; init; }

    [Required]
    [StringLength(100)]
    public string Name { get; init; }

    [Required]
    [StringLength(100)]
    public string Category { get; init; }

    [Required]
    [StringLength(100)]
    public string BodyPart { get; init; }

    public ExerciseDto(int id, string name, string category, string bodyPart)
    {
        Id = id;
        Name = name;
        Category = category;
        BodyPart = bodyPart;
    }
}
