using Microsoft.AspNetCore.Components;

namespace NewGains.Client.Components;

public partial class InstructionEditOptions
{
    [Parameter]
    public int StepNumber { get; set; }

    [Parameter]
    public EventCallback<int> ShiftInstructionUp { get; set; }

    [Parameter]
    public EventCallback<int> ShiftInstructionDown { get; set; }

    [Parameter]
    public EventCallback<int> InsertInstructionBelow { get; set; }

    [Parameter]
    public EventCallback<int> DeleteInstruction { get; set; }
}
