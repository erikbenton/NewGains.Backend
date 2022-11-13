using System.ComponentModel.DataAnnotations;

namespace NewGains.DataTransfer.Templates;

public record TemplateSetGroupCreateDto
{
    [Required]
    public int ExerciseId { get; init; }
    [StringLength(255)]
    public string? Note { get; init; }

    [Required]
    public IEnumerable<TemplateSetCreateDto> Sets { get; init; }

    public TemplateSetGroupCreateDto(
        int exerciseId,
        string? note,
        IEnumerable<TemplateSetCreateDto> sets)
    {
        ExerciseId = exerciseId;
        Note = note;
        Sets = sets;
    }
}
