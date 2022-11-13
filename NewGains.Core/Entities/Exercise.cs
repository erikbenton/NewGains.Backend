using NewGains.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewGains.Core.Entities;

public class Exercise : IIdEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public Category Category { get; set; }

    [Required]
    public BodyPart BodyPart { get; set; }

    public IEnumerable<Instruction> Instructions { get; set; } = new List<Instruction>();
}