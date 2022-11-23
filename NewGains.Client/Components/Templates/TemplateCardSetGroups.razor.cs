using Microsoft.AspNetCore.Components;
using NewGains.DataTransfer.Templates;

namespace NewGains.Client.Components.Templates;

public partial class TemplateCardSetGroups
{
    [Parameter]
    public IEnumerable<TemplateSetGroupSummaryDto> SetGroups { get; set; } = default!;
}
