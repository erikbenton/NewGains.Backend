using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewGains.Core.Entities;

public class TemplateSet
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int SetNumber { get; set; }

    [Required]
    [ForeignKey(nameof(Exercise))]
    public int ExerciseId { get; set; }

    public Exercise? Exercise { get; set; }

    [Required]
    [ForeignKey(nameof(SetGroup))]
    public int SetGroupId { get; set; }

    public TemplateSetGroup? SetGroup { get; set; }

    [Range(0, 100)]
    public double? PercentIntensity { get; set; }

    [Range(0, 10000)]
    public double? WeightInPounds { get; set; }

    [Range(0, int.MaxValue)]
    public int? TimeInSeconds { get; set; }

    [Range(0, int.MaxValue)]
    public int? Reps { get; set; }
}