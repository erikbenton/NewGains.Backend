using System.ComponentModel.DataAnnotations;

namespace NewGains.API.Dtos.Exercises;

public record ExerciseCreateDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; init; }

    [Required]
    [StringLength(100)]
    public string Category { get; init; }

    [Required]
    [StringLength(100)]
    public string BodyPart { get; init; }

    [Required]
    public IEnumerable<InstructionDto> Instructions { get; init; } 

    public ExerciseCreateDto(
        string name,
        string category,
        string bodyPart,
        IEnumerable<InstructionDto> instructions)
    {
        Name = name;
        Category = category;
        BodyPart = bodyPart;
        Instructions = instructions;
    }
}
