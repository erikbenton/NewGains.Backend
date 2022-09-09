using System.ComponentModel.DataAnnotations;

namespace NewGains.Core.Entities;

public class Instruction
{
    public int Id { get; set; }

    [Required]
    public int StepNumber { get; set; }

    [Required]
    public string Text { get; set; } = string.Empty;
}
