using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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

    public string TextAreaId => $"instruction{Instruction.StepNumber}TextArea";

    [Inject]
    public IJSRuntime JSRuntime { get; set; } = default!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await JSRuntime.InvokeVoidAsync("formUtilities.resizeTextArea", TextAreaId);
    }
}
