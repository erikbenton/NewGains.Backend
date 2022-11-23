using NewGains.Core.Entities;
using NewGains.DataTransfer.Templates;

namespace NewGains.DataTransfer.Mappers;

public class TemplateSetGroupMapper
{
    public static TemplateSetGroupSummaryDto MapToSetGroupSummaryDto(TemplateSetGroup setGroup)
    {
        if (setGroup.Exercise is null) throw new ArgumentException(nameof(setGroup));

        var exerciseDto = ExerciseMapper.MapToExerciseDto(setGroup.Exercise);

        var numberOfSets = setGroup.Sets is null ? 0 : setGroup.Sets.Count();

        return new TemplateSetGroupSummaryDto(exerciseDto, numberOfSets);
    }

    public static TemplateSetGroupDetailsDto MapToSetGroupDetailsDto(TemplateSetGroup setGroup)
    {
        if (setGroup.Exercise is null) throw new ArgumentException(nameof(setGroup));

        var exerciseDto = ExerciseMapper.MapToExerciseDto(setGroup.Exercise);

        var setDtos = setGroup.Sets
            .Select(set => TemplateSetMapper.MapToSetDetailsDto(set))
            .ToList();

        return new TemplateSetGroupDetailsDto(
            setGroup.Id,
            exerciseDto,
            setGroup.Note,
            setDtos);
    }

    public static TemplateSetGroupUpdateDto MapToSetGroupUpdateDto(TemplateSetGroup setGroup)
    {
        if (setGroup.Exercise is null) throw new ArgumentException(nameof(setGroup));

        var setDtos = setGroup.Sets
            .Select(set => TemplateSetMapper.MapToSetUpdateDto(set))
            .ToList();

        return new TemplateSetGroupUpdateDto(
            setGroup.Id,
            setGroup.Exercise.Id,
            setGroup.Note,
            setDtos);
    }

    public static TemplateSetGroupCreateDto MapToSetGroupCreateDto(TemplateSetGroup setGroup)
    {
        if (setGroup.Exercise is null) throw new ArgumentException(nameof(setGroup));

        var setDtos = setGroup.Sets
            .Select(set => TemplateSetMapper.MapToSetCreateDto(set))
            .ToList();

        return new TemplateSetGroupCreateDto(
            setGroup.Exercise.Id,
            setGroup.Note,
            setDtos);
    }

    public static TemplateSetGroup MapToSetGroup(
        TemplateSetGroupCreateDto setGroupCreateDto, Template template)
    {
        var templateSetGroup = new TemplateSetGroup()
        {
            TemplateId = template.Id,
            ExerciseId = setGroupCreateDto.ExerciseId,
            Note = setGroupCreateDto.Note
        };

        templateSetGroup.Sets = setGroupCreateDto.Sets
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

    public static TemplateSetGroup MapToSetGroup(
        TemplateSetGroupDetailsDto setGroupDetailsDto, Template template)
    {
        var templateSetGroup = new TemplateSetGroup()
        {
            Id = setGroupDetailsDto.Id,
            TemplateId = template.Id,
            ExerciseId = setGroupDetailsDto.Exercise.Id,
            Exercise = ExerciseMapper.MapToExercise(setGroupDetailsDto.Exercise),
            Note = setGroupDetailsDto.Note
        };

        templateSetGroup.Sets = setGroupDetailsDto.Sets
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

    public static TemplateSetGroup MapToSetGroup(
        TemplateSetGroupUpdateDto setGroupUpdateDto, Template template)
    {
        var templateSetGroup = new TemplateSetGroup()
        {
            Id = setGroupUpdateDto.Id.HasValue ? setGroupUpdateDto.Id.Value : 0,
            TemplateId = template.Id,
            ExerciseId = setGroupUpdateDto.ExerciseId,
            Note = setGroupUpdateDto.Note
        };

        templateSetGroup.Sets = setGroupUpdateDto.Sets
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
