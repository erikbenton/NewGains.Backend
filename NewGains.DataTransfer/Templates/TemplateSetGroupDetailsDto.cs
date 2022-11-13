using NewGains.DataTransfer.Exercises;
using System.ComponentModel.DataAnnotations;

namespace NewGains.DataTransfer.Templates;

public record TemplateSetGroupDetailsDto
{
    [Required]
    public int Id { get; init; }

    [Required]
    public ExerciseDto Exercise { get; init; }

    [StringLength(255)]
    public string? Note { get; init; }

    [Required]
    public IEnumerable<TemplateSetDetailsDto> Sets { get; init; }

    public TemplateSetGroupDetailsDto(
        int id,
        ExerciseDto exercise,
        string? note,
        IEnumerable<TemplateSetDetailsDto> sets)
    {
        Id = id;
        Exercise = exercise;
        Note = note;
        Sets = sets;
    }
}
