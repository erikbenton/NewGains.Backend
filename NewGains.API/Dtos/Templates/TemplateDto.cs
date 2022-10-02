using System.ComponentModel.DataAnnotations;

namespace NewGains.API.Dtos.Templates;

public record TemplateDto
{
    [Required]
    public int Id { get; init; }

    [Required]
    [StringLength(100)]
    public string Name { get; init; } = string.Empty;

    public IEnumerable<TemplateSetGroupSummaryDto>? SetGroups { get; set; }

    public TemplateDto(int id, string name, IEnumerable<TemplateSetGroupSummaryDto>? setGroups)
    {
        Id = id;
        Name = name;
        SetGroups = setGroups;
    }
}
