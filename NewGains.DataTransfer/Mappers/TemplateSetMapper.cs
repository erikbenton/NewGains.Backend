using NewGains.Core.Entities;
using NewGains.DataTransfer.Templates;

namespace NewGains.DataTransfer.Mappers;

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

    public static TemplateSet MapToSet(TemplateSetDetailsDto setDetailsDto, TemplateSetGroup setGroup)
    {
        return new TemplateSet()
        {
            SetGroupId = setGroup.Id,
            ExerciseId = setGroup.ExerciseId,
            Id = setDetailsDto.Id,
            PercentIntensity = setDetailsDto.PercentIntensity,
            WeightInPounds = setDetailsDto.WeightInPounds,
            TimeInSeconds = setDetailsDto.TimeInSeconds,
            Reps = setDetailsDto.Reps
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

    public static TemplateSetUpdateDto MapToSetUpdateDto(TemplateSet templateSet)
    {
        return new TemplateSetUpdateDto(
            templateSet.Id,
            templateSet.PercentIntensity,
            templateSet.WeightInPounds,
            templateSet.TimeInSeconds,
            templateSet.Reps);
    }

    public static TemplateSetCreateDto MapToSetCreateDto(TemplateSet templateSet)
    {
        return new TemplateSetCreateDto(
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
            Id = setUpdateDto.Id.HasValue ? setUpdateDto.Id.Value : 0,
            PercentIntensity = setUpdateDto.PercentIntensity,
            WeightInPounds = setUpdateDto.WeightInPounds,
            TimeInSeconds = setUpdateDto.TimeInSeconds,
            Reps = setUpdateDto.Reps
        };
    }
}
