using System.ComponentModel.DataAnnotations;

namespace NewGains.DataTransfer.Templates;

public record TemplateSetCreateDto
{
    [Range(0, 100)]
    public double? PercentIntensity { get; init; }

    [Range(0, 10000)]
    public double? WeightInPounds { get; init; }

    [Range(0, int.MaxValue)]
    public int? TimeInSeconds { get; init; }

    [Range(0, int.MaxValue)]
    public int? Reps { get; init; }

    public TemplateSetCreateDto(
        double? percentIntensity,
        double? weightInPounds,
        int? timeInSeconds,
        int? reps)
    {
        PercentIntensity = percentIntensity;
        WeightInPounds = weightInPounds;
        TimeInSeconds = timeInSeconds;
        Reps = reps;
    }
}
