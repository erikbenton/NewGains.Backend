using NewGains.API.Dtos.Templates;
using NewGains.Core.Entities;

namespace NewGains.API.Mappers;

public class TemplateSetGroupMapper
{
    public static TemplateSetGroupSummaryDto MapToSetGroupSummaryDto(TemplateSetGroup setGroup)
    {
        if (setGroup.Exercise is null) throw new ArgumentException(nameof(setGroup));

        var exerciseDto = ExerciseMapper.MapToExerciseDto(setGroup.Exercise);

        var numberOfSets = setGroup.Sets is null ? 0 : setGroup.Sets.Count();

        return new TemplateSetGroupSummaryDto(exerciseDto, numberOfSets);
    }

    public static TemplateSetGroup MapToSetGroup(TemplateSetGroupCreateDto setGroupCreateDto, Template template)
    {
        var templateSetGroup = new TemplateSetGroup()
        {
            TemplateId = template.Id,
            ExerciseId = setGroupCreateDto.ExerciseId,
            Note = setGroupCreateDto.Note
        };

        templateSetGroup.Sets = setGroupCreateDto.Sets?
            .Select(set => TemplateSetMapper.MapToSet(set, templateSetGroup))
            .ToList();

        if (templateSetGroup.Sets is not null)
        {
            int setNumber = 1;
            foreach (var set in templateSetGroup.Sets)
            {
                set.SetNumber = setNumber++;
            }
        }

        return templateSetGroup;
    }
}
