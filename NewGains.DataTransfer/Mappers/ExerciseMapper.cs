using NewGains.Core.Entities;
using NewGains.Core.Extensions;
using NewGains.DataTransfer.Exercises;

namespace NewGains.DataTransfer.Mappers;

public class ExerciseMapper
{
    public static Exercise MapToExercise(ExerciseCreateDto exerciseCreateDto)
    {
        var exercise = new Exercise()
        {
            Name = exerciseCreateDto.Name,
            Category = exerciseCreateDto.Category.GetCategory(),
            BodyPart = exerciseCreateDto.BodyPart.GetBodyPart(),
        };

        exercise.Instructions = exerciseCreateDto.Instructions
            .Select(iDto => InstructionMapper.MapToInstruction(iDto, exercise))
            .ToList();

        OrderInstructions(exercise);

        return exercise;
    }

    public static Exercise MapToExercise(ExerciseUpdateDto updateDto)
    {
        var exercise = new Exercise()
        {
            Id = updateDto.Id,
            Name = updateDto.Name,
            Category = updateDto.Category.GetCategory(),
            BodyPart = updateDto.BodyPart.GetBodyPart(),
        };

        exercise.Instructions = updateDto.Instructions
            .Select(iDto => InstructionMapper.MapToInstruction(iDto, exercise))
            .ToList();

        OrderInstructions(exercise);

        return exercise;
    }

    public static Exercise MapToExercise(ExerciseDto exerciseDto)
    {
        return new Exercise()
        {
            Id = exerciseDto.Id,
            Name = exerciseDto.Name,
            Category = exerciseDto.Category.GetCategory(),
            BodyPart = exerciseDto.BodyPart.GetBodyPart()
        };
    }

    public static Exercise MapToExercise(ExerciseDetailsDto detailsDto)
    {
        var exercise = new Exercise()
        {
            Id = detailsDto.Id,
            Name = detailsDto.Name,
            BodyPart = detailsDto.BodyPart.GetBodyPart(),
            Category = detailsDto.Category.GetCategory(),
        };

        exercise.Instructions = detailsDto.Instructions
            .Select(iDto => InstructionMapper.MapToInstruction(iDto, exercise))
            .ToList();

        OrderInstructions(exercise);

        return exercise;
    }

    public static ExerciseDto MapToExerciseDto(Exercise exercise)
    {
        return new ExerciseDto(
            exercise.Id,
            exercise.Name,
            exercise.Category.GetLabel(),
            exercise.BodyPart.GetLabel());
    }


    public static ExerciseDetailsDto MapToExerciseDetailsDto(Exercise exercise)
    {
        var instructionDtos = exercise.Instructions
            .Select(i => InstructionMapper.MapToInstructionDto(i));

        return new ExerciseDetailsDto(
            exercise.Id,
            exercise.Name,
            exercise.Category.GetLabel(),
            exercise.BodyPart.GetLabel(),
            instructionDtos);
    }

    public static ExerciseCreateDto MapToExerciseCreateDto(Exercise exercise)
    {
        var instructionDtos = exercise.Instructions
            .Select(i => InstructionMapper.MapToInstructionDto(i));

        return new ExerciseCreateDto(
            exercise.Name,
            exercise.Category.GetLabel(),
            exercise.BodyPart.GetLabel(),
            instructionDtos);
    }

    public static ExerciseUpdateDto MapToExerciseUpdateDto(Exercise exercise)
    {
        var instructionDtos = exercise.Instructions
            .Select(i => InstructionMapper.MapToInstructionDto(i));

        return new ExerciseUpdateDto(
            exercise.Id,
            exercise.Name,
            exercise.Category.GetLabel(),
            exercise.BodyPart.GetLabel(),
            instructionDtos);
    }

    private static void OrderInstructions(Exercise exercise)
    {
        if (exercise.Instructions is null) return;

        int instructionStepNumber = 1;
        foreach (var instruction in exercise.Instructions)
        {
            instruction.StepNumber = instructionStepNumber++;
        }
    }
}
