using Microsoft.AspNetCore.Components;
using NewGains.Core.Entities;

namespace NewGains.Client.Components.Templates;

public partial class TemplateSetGroupEdit
{
    [Parameter]
    public TemplateSetGroup SetGroup { get; set; } = default!;

    [Parameter]
    public EventCallback<int> RemoveSetGroup { get; set; }

    private void AddEmptySet()
    {
        var newSets = SetGroup.Sets.ToList();
        newSets.Add(new TemplateSet()
        {
            SetGroupId = SetGroup.Id,
            ExerciseId = SetGroup.Exercise!.Id,
            SetNumber = newSets.Count + 1,
        });
        SetGroup.Sets = newSets;
    }

    private void DeleteSet(int setNumber)
    {
        var sets = SetGroup.Sets
            .Where(set => set.SetNumber != setNumber)
            .ToList();

        for (int i = 0; i < sets.Count; i++)
        {
            sets[i].SetNumber = i+1;
        }

        SetGroup.Sets = sets;
    }
}
