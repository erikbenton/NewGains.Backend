using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewGains.Core.Entities;

public class Instruction
{
    public int Id { get; set; }

    [Required]
    [ForeignKey(nameof(Exercise))]
    public int ExerciseId { get; set; }

    public Exercise? Exercise { get; set; }

    [Required]
    public int StepNumber { get; set; }

    [Required]
    public string Text { get; set; } = string.Empty;
}
