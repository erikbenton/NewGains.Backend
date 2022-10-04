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
}
