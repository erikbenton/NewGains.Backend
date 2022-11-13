using System.ComponentModel.DataAnnotations;

namespace NewGains.DataTransfer.Templates;

public record TemplateDto
{
    [Required]
    public int Id { get; init; }

    [Required]
    [StringLength(100)]
    public string Name { get; init; } = string.Empty;

    [Required]
    public IEnumerable<TemplateSetGroupSummaryDto> SetGroups { get; init; }

    public TemplateDto(int id, string name, IEnumerable<TemplateSetGroupSummaryDto> setGroups)
    {
        Id = id;
        Name = name;
        SetGroups = setGroups;
    }
}
