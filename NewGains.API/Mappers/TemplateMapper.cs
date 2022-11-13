using NewGains.API.Dtos.Templates;
using NewGains.Core.Entities;

namespace NewGains.API.Mappers;

public class TemplateMapper
{
    public static TemplateDto MapToTemplateDto(Template template)
    {
        var setGroupDtos = template.SetGroups
            .Select(group => TemplateSetGroupMapper.MapToSetGroupSummaryDto(group));

        return new TemplateDto(
            template.Id,
            template.Name,
            setGroupDtos);
    }

    public static Template MapToTemplate(TemplateCreateDto templateCreateDto)
    {
        var template = new Template()
        {
            Name = templateCreateDto.Name,
            Description = templateCreateDto.Description,
        };

        template.SetGroups = templateCreateDto.SetGroups
            .Select(setGroup => TemplateSetGroupMapper.MapToSetGroup(setGroup, template))
            .ToList();

        if (template.SetGroups is not null)
        {
            int setGroupNumber = 1;
            foreach (var setGroup in template.SetGroups)
            {
                setGroup.SetGroupNumber = setGroupNumber++;
            }
        }

        return template;
    }

    public static TemplateDetailsDto MapToTemplateDetailsDto(Template template)
    {
        var setGroupDtos = template.SetGroups
            .Select(setGroup => TemplateSetGroupMapper.MatpToSetGroupDetailsDto(setGroup));

        return new TemplateDetailsDto(
            template.Id,
            template.Name,
            template.Description,
            setGroupDtos);
    }

    public static Template MapToTemplate(TemplateUpdateDto updatedTemplate)
    {
        var template = new Template()
        {
            Id = updatedTemplate.Id,
            Name = updatedTemplate.Name,
            Description = updatedTemplate.Description
        };

        template.SetGroups = updatedTemplate.SetGroups
            .Select(dto => TemplateSetGroupMapper.MapToSetGroup(dto, template))
            .ToList();

        if (template.SetGroups is not null)
        {
            int setGroupNumber = 1;
            foreach (var setGroup in template.SetGroups)
            {
                setGroup.SetGroupNumber = setGroupNumber++;
            }
        }

        return template;
    }
}