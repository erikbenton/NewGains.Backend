using NewGains.API.Dtos.Exercises;
using NewGains.Core.Entities;

namespace NewGains.API.Mappers;

public class InstructionMapper
{
    public static Instruction MapToInstruction(InstructionDto instructionDto, Exercise exercise)
    {
        return new Instruction()
        {
            Id = instructionDto.Id.HasValue ? instructionDto.Id.Value : 0,
            Exercise = exercise,
            ExerciseId = exercise.Id,
            Text = instructionDto.Text
        };
    }

    public static InstructionDto MapToInstructionDto(Instruction instruction)
    {
        return new InstructionDto(instruction.Id, instruction.Text);
    }
}
