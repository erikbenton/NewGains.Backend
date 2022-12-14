using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewGains.Core.Entities;

public class TemplateSetGroup : IIdEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int SetGroupNumber { get; set; }

    [Required]
    [ForeignKey(nameof(Template))]
    public int TemplateId { get; set; }

    public Template? Template { get; set; }

    [Required]
    [ForeignKey(nameof(Exercise))]
    public int ExerciseId { get; set; }

    public Exercise? Exercise { get; set; }

    [StringLength(255)]
    public string? Note { get; set; }

    public IEnumerable<TemplateSet> Sets { get; set; } = new List<TemplateSet>();
}
