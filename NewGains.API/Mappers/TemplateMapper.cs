using NewGains.API.Dtos.Templates;
using NewGains.Core.Entities;

namespace NewGains.API.Mappers;

public class TemplateMapper
{
    public static TemplateDto MapToTemplateDto(Template template)
    {
        var setGroupDtos = template.SetGroups?
            .Select(group => TemplateSetGroupMapper.MapToSetGroupSummaryDto(group));

        return new TemplateDto(
            template.Id,
            template.Name,
            setGroupDtos);
    }
}
