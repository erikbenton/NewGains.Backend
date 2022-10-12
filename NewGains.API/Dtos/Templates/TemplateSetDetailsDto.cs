using System.ComponentModel.DataAnnotations;

namespace NewGains.API.Dtos.Templates;

public record TemplateSetDetailsDto
{
    [Required]
    public int Id { get; init; }

    [Range(0, 100)]
    public double? PercentIntensity { get; init; }

    [Range(0, 10000)]
    public double? WeightInPounds { get; init; }

    [Range(0, int.MaxValue)]
    public int? TimeInSeconds { get; init; }

    [Range(0, int.MaxValue)]
    public int? Reps { get; init; }

    public TemplateSetDetailsDto(
        int id,
        double? percentIntensity,
        double? weightInPounds,
        int? timeInSeconds,
        int? reps)
    {
        Id = id;
        PercentIntensity = percentIntensity;
        WeightInPounds = weightInPounds;
        TimeInSeconds = timeInSeconds;
        Reps = reps;
    }
}
