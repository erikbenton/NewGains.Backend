using System.ComponentModel.DataAnnotations;
using NewGains.API.Dtos.Exercises;

namespace NewGains.API.Dtos.Templates;

public record TemplateSetGroupSummaryDto
{
    [Required]
    public ExerciseDto Exercise { get; set; }

    [Required]
    public int NumberOfSets { get; set; }

    public TemplateSetGroupSummaryDto(ExerciseDto exercise, int numberOfSets)
    {
        Exercise = exercise;
        NumberOfSets = numberOfSets;
    }
}
