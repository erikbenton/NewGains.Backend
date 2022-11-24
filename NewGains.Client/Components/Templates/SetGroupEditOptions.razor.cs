using Microsoft.AspNetCore.Components;

namespace NewGains.Client.Components.Templates;

public partial class SetGroupEditOptions
{
    [Parameter]
    public int SetGroupNumber { get; set; }

    [Parameter]
    public EventCallback<int> RemoveSetGroup { get; set; }

    [Parameter]
    public EventCallback<int> MoveSetGroupUp { get; set; }

    [Parameter]
    public EventCallback<int> MoveSetGroupDown { get; set; }
}
