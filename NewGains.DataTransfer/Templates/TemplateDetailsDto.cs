using System.ComponentModel.DataAnnotations;

namespace NewGains.DataTransfer.Templates;

public record TemplateDetailsDto
{
    [Required]
    public int Id { get; init; }

    [Required]
    [StringLength(100)]
    public string Name { get; init; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; init; }

    [Required]
    public IEnumerable<TemplateSetGroupDetailsDto> SetGroups { get; init; }

    public TemplateDetailsDto(
        int id,
        string name,
        string? description,
        IEnumerable<TemplateSetGroupDetailsDto> setGroups)
    {
        Id = id;
        Name = name;
        Description = description;
        SetGroups = setGroups;
    }
}
