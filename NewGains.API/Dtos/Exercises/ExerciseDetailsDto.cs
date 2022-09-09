using NewGains.Core.Entities;
using NewGains.Core.Enums;

namespace NewGains.API.Dtos.Exercises;

public record ExerciseDetailsDto : ExerciseDto
{
    public IEnumerable<InstructionDto>? Instructions { get; }

    public ExerciseDetailsDto(Exercise exercise)
        : base(exercise)
    {
        Instructions = exercise.Instructions?.Select(i => new InstructionDto(i));
    }

    public ExerciseDetailsDto(
        int id,
        string name,
        Category category,
        BodyPart bodyPart,
        IEnumerable<Instruction>? instructions)
        : base(id, name, category, bodyPart)
    {
        Instructions = instructions?.Select(i => new InstructionDto(i));
    }
}
