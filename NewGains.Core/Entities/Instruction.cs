using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewGains.Core.Entities;

public class Instruction : IIdEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [ForeignKey(nameof(Exercise))]
    public int ExerciseId { get; set; }

    public Exercise? Exercise { get; set; }

    [Required]
    public int StepNumber { get; set; }

    [Required]
    [StringLength(500)]
    public string Text { get; set; } = string.Empty;
}
