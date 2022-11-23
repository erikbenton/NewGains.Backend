using Microsoft.AspNetCore.Components;
using NewGains.Core.Entities;

namespace NewGains.Client.Components.Exercises;

public partial class InstructionEditCard
{
    [Parameter]
    public Instruction Instruction { get; set; } = default!;

    [Parameter]
    public EventCallback<int> ShiftInstructionUp { get; set; }

    [Parameter]
    public EventCallback<int> ShiftInstructionDown { get; set; }

    [Parameter]
    public EventCallback<int> InsertInstructionBelow { get; set; }

    [Parameter]
    public EventCallback<int> DeleteInstruction { get; set; }
}
