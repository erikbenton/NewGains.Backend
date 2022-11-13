using System.ComponentModel.DataAnnotations;

namespace NewGains.DataTransfer.Exercises;

public record ExerciseDetailsDto
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

    [Required]
    public IEnumerable<InstructionDto> Instructions { get; init; }

    public ExerciseDetailsDto(
        int id,
        string name,
        string category,
        string bodyPart,
        IEnumerable<InstructionDto> instructions)
    {
        Id = id;
        Name = name;
        Category = category;
        BodyPart = bodyPart;
        Instructions = instructions;
    }
}
