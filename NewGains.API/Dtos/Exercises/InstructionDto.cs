using NewGains.Core.Entities;

namespace NewGains.API.Dtos.Exercises;

public record InstructionDto
{
    public int Id { get; }
    public int StepNumber { get; }
    public string Text { get; }

    public InstructionDto(int id, int stepNumber, string text)
    {
        Id = id;
        StepNumber = stepNumber;
        Text = text;
    }

    public InstructionDto(Instruction instruction)
    {
        Id = instruction.Id;
        StepNumber = instruction.StepNumber;
        Text = instruction.Text;
    }
}
