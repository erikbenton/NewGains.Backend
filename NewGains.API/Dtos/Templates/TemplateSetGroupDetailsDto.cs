using NewGains.API.Dtos.Exercises;
using NewGains.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewGains.API.Dtos.Templates;

public record TemplateSetGroupDetailsDto
{
    [Required]
    public int Id { get; init; }

    [Required]
    public ExerciseDto Exercise { get; init; }

    [StringLength(255)]
    public string? Note { get; init; }

    public IEnumerable<TemplateSetDetailsDto>? Sets { get; init; }

    public TemplateSetGroupDetailsDto(
        int id,
        ExerciseDto exercise,
        string? note,
        IEnumerable<TemplateSetDetailsDto>? sets)
    {
        Id = id;
        Exercise = exercise;
        Note = note;
        Sets = sets;
    }
}
