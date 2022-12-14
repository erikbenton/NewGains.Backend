using NewGains.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewGains.DataTransfer.Templates;

public record TemplateSetGroupUpdateDto
{
    public int? Id { get; init; }

    [Required]
    [ForeignKey(nameof(Exercise))]
    public int ExerciseId { get; init; }

    [StringLength(255)]
    public string? Note { get; init; }

    [Required]
    public IEnumerable<TemplateSetUpdateDto> Sets { get; init; }

    public TemplateSetGroupUpdateDto(
        int? id,
        int exerciseId,
        string? note,
        IEnumerable<TemplateSetUpdateDto> sets)
    {
        Id = id;
        ExerciseId = exerciseId;
        Note = note;
        Sets = sets;
    }
}
