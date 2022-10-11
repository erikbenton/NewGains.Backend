using NewGains.API.Dtos.Templates;
using NewGains.Core.Entities;

namespace NewGains.API.Mappers;

public class TemplateSetMapper
{
    public static TemplateSet MapToSet(TemplateSetCreateDto setCreateDto, TemplateSetGroup setGroup)
    {
        return new TemplateSet()
        {
            SetGroupId = setGroup.Id,
            ExerciseId = setGroup.ExerciseId,
            PercentIntensity = setCreateDto.PercentIntensity,
            WeightInPounds = setCreateDto.WeightInPounds,
            TimeInSeconds = setCreateDto.TimeInSeconds,
            Reps = setCreateDto.Reps
        };
    }
}
