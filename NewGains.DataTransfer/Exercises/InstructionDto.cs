using System.ComponentModel.DataAnnotations;

namespace NewGains.DataTransfer.Exercises;

public record InstructionDto
{
    public int? Id { get; init; }

    [Required]
    public string Text { get; init; }

    public InstructionDto(int? id, string text)
    {
        Id = id;
        Text = text;
    }
}
