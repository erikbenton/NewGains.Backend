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

    public static TemplateSetDetailsDto MapToSetDetailsDto(TemplateSet templateSet)
    {
        return new TemplateSetDetailsDto(
            templateSet.Id,
            templateSet.PercentIntensity,
            templateSet.WeightInPounds,
            templateSet.TimeInSeconds,
            templateSet.Reps);
    }

    public static TemplateSet MapToSet(TemplateSetUpdateDto setUpdateDto, TemplateSetGroup setGroup)
    {
        return new TemplateSet()
        {
            SetGroupId = setGroup.Id,
            ExerciseId = setGroup.ExerciseId,
            Id = setUpdateDto.Id,
            PercentIntensity = setUpdateDto.PercentIntensity,
            WeightInPounds = setUpdateDto.WeightInPounds,
            TimeInSeconds = setUpdateDto.TimeInSeconds,
            Reps = setUpdateDto.Reps
        };
    }
}
