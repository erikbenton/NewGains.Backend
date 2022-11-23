using Microsoft.AspNetCore.Components;
using NewGains.Client.Services;
using NewGains.Core.Entities;
using NewGains.DataTransfer.Exercises;
using NewGains.DataTransfer.Mappers;
using NewGains.DataTransfer.Templates;

namespace NewGains.Client.Pages.Templates;

public partial class TemplateEdit
{
    [Inject]
    public ITemplateDataService TemplateDataService { get; set; } = default!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = default!;

    [Parameter]
    public int? TemplateId { get; set; }

    public Template Template { get; set; } = new();

    public bool SelectingExercises { get; set; } = false;

    public string OriginalName { get; set; } = "New";

    protected override async Task OnInitializedAsync()
    {
        if (TemplateId.HasValue)
        {
            var template = await TemplateDataService
                .GetTemplateDetails(TemplateId.Value);

            if (template is not null)
            {
                Template = TemplateMapper.MapToTemplate(template);
                OriginalName = Template.Name;
            }
        }
    }

    private void SelectExercises()
    {
        SelectingExercises = true;
    }

    private void RemoveSetGroup(int setGroupNumber)
    {
        var setGroups = Template.SetGroups
            .Where(setGroup => setGroup.SetGroupNumber != setGroupNumber)
            .ToList();

        for (int i = 0; i < setGroups.Count; i++)
        {
            setGroups[i].SetGroupNumber = i+1;
        }

        Template.SetGroups = setGroups;
    }

    public void AddAllSelectedExercises(List<ExerciseDto> selectedExercises)
    {
        // Convert DTOs to Exercise Entities
        var exercisesToAdd = selectedExercises
            .Select(e => ExerciseMapper.MapToExercise(e))
            .ToList();

        // Map each Exercise to new Set Group with empty Set
        var newSetGroups = exercisesToAdd.Select(e => new TemplateSetGroup()
        {
            Exercise = e,
            ExerciseId = e.Id,
            TemplateId = Template.Id,
            Sets = new List<TemplateSet>() { new() { ExerciseId = e.Id, SetNumber = 1 } }
        });

        // Add the new Set Groups to the saved ones
        var allSetGroups = Template.SetGroups.ToList();
        allSetGroups.AddRange(newSetGroups);

        // Re-order the Set Group Numbers
        for (int i = 0; i < allSetGroups.Count; i++)
        {
            allSetGroups[i].SetGroupNumber = i + 1;
        }

        Template.SetGroups = allSetGroups;

        SelectingExercises = false;
    }

    public void CancelSelection()
    {
        SelectingExercises = false;
    }

    private async Task HandleValidSubmit()
    {
        if (TemplateId.HasValue)
        {
            TemplateUpdateDto updatedTemplateDto = TemplateMapper
                .MapToTemplateUpdateDto(Template);

            var updateResponse = await TemplateDataService.PutUpdatedTemplate(updatedTemplateDto);

            if (updateResponse.IsSuccessStatusCode)
            {
                NavigationManager.NavigateTo("/templates");
            }
        }
        else
        {
            TemplateCreateDto createdTemplateDto = TemplateMapper
                .MapToTemplateCreateDto(Template);

            var createdResponse = await TemplateDataService.PostNewTemplate(createdTemplateDto);

            if (createdResponse.IsSuccessStatusCode)
            {
                NavigationManager.NavigateTo("/templates");
            }
        }
    }
}
