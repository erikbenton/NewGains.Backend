using System.ComponentModel.DataAnnotations;

namespace NewGains.API.Dtos.Templates;

public record TemplateUpdateDto
{
    [Required]
    public int Id { get; init; }

    [Required]
    [StringLength(100)]
    public string Name { get; init; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; init; }

    [Required]
    public IEnumerable<TemplateSetGroupUpdateDto> SetGroups { get; init; }

    public TemplateUpdateDto(
        int id,
        string name,
        string? description,
        IEnumerable<TemplateSetGroupUpdateDto> setGroups)
    {
        Id = id;
        Name = name;
        Description = description;
        SetGroups = setGroups;
    }
}
