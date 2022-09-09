using NewGains.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace NewGains.Core.Entities;

public class Exercise
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public Category Category { get; set; }

    [Required]
    public BodyPart BodyPart { get; set; }

    public IEnumerable<Instruction>? Instructions { get; set; }
}