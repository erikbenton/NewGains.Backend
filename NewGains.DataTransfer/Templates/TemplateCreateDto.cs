using System.ComponentModel.DataAnnotations;

namespace NewGains.DataTransfer.Templates;

public record TemplateCreateDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; init; }

    [StringLength(500)]
    public string? Description { get; init; }

    [Required]
    public IEnumerable<TemplateSetGroupCreateDto> SetGroups { get; init; }

    public TemplateCreateDto(
        string name,
        string? description,
        IEnumerable<TemplateSetGroupCreateDto> setGroups)
    {
        Name = name;
        Description = description;
        SetGroups = setGroups;
    }
}
