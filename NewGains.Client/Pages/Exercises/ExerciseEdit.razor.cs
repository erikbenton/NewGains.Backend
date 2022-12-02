using Microsoft.AspNetCore.Components;
using NewGains.Client.Services;
using NewGains.Core.Entities;
using NewGains.Core.Enums;
using NewGains.DataTransfer.Exercises;
using NewGains.DataTransfer.Mappers;
using System.Net.Http.Json;

namespace NewGains.Client.Pages.Exercises;

public partial class ExerciseEdit
{
    [Parameter]
    public int? ExerciseId { get; set; }

    [Inject]
    public IExerciseDataService ExerciseDataService { get; set; } = default!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = default!;

    public Exercise? Exercise { get; set; }

    public string OriginalName { get; set; } = "New";

    public IEnumerable<Category> Categories = Enum.GetValues(typeof(Category))
        .Cast<Category>();

    public IEnumerable<BodyPart> BodyParts = Enum.GetValues(typeof(BodyPart))
        .Cast<BodyPart>();

    protected override async Task OnInitializedAsync()
    {
        if (ExerciseId.HasValue)
        {
            var exerciseDetails = await ExerciseDataService
                .GetExerciseDetails(ExerciseId.Value);

            if (exerciseDetails is not null)
            {
                Exercise = ExerciseMapper.MapToExercise(exerciseDetails);
                OriginalName = Exercise.Name;
            }
        }

        if (Exercise is null)
        {
            Exercise = new();
        }
    }

    private void AddInstruction()
    {
        if (Exercise is null) return;

        var instructions = Exercise.Instructions.ToList();
        instructions.Add(new Instruction()
        {
            StepNumber = Exercise.Instructions.Count() + 1,
            Text = ""
        });

        Exercise.Instructions = instructions;
    }

    public void DeleteInstruction(int deleteStepNumber)
    {
        if (Exercise is null) return;

        var instructions = Exercise.Instructions
            .Where(i => i.StepNumber != deleteStepNumber)
            .ToList();

        for (int i = 0; i < instructions.Count; i++)
        {
            instructions[i].StepNumber = i + 1;
        }

        Exercise.Instructions = instructions;
    }

    public void ShiftInstructionDown(int instructionStepNumber)
    {
        if (Exercise is null) return;

        if (instructionStepNumber < 1) return;
        if (instructionStepNumber > Exercise.Instructions.Count() - 1) return;

        var instructions = Exercise.Instructions.ToArray();
        
        var tempInstruction = instructions[instructionStepNumber];
        instructions[instructionStepNumber] = instructions[instructionStepNumber - 1];
        instructions[instructionStepNumber - 1] = tempInstruction;

        for (int i = 0; i < instructions.Count(); i++)
        {
            instructions[i].StepNumber = i + 1;
        }

        Exercise.Instructions = instructions;
    }

    public void ShiftInstructionUp(int stepNumber)
    {
        if (Exercise is null) return;

        if (stepNumber < 2) return;
        if (stepNumber > Exercise.Instructions.Count()) return;

        var instructions = Exercise.Instructions.ToArray();

        var tempInstruction = instructions[stepNumber - 2];
        instructions[stepNumber - 2] = instructions[stepNumber - 1];
        instructions[stepNumber - 1] = tempInstruction;

        for (int i = 0; i < instructions.Length; i++)
        {
            instructions[i].StepNumber = i + 1;
        }

        Exercise.Instructions = instructions;
    }

    public void InsertInstructionBelow(int stepNumber)
    {
        if (Exercise is null) return;

        if (stepNumber < 1) return;
        if (stepNumber > Exercise.Instructions.Count()) return;

        var instructions = Exercise.Instructions.ToList();

        instructions.Insert(stepNumber, new Instruction() { Text = "" });

        for (int i = 0; i < instructions.Count(); i++)
        {
            instructions[i].StepNumber = i + 1;
        }

        Exercise.Instructions = instructions;
    }

    private async Task HandleValidSubmit()
    {
        if (Exercise is null) return;

        if (ExerciseId.HasValue)
        {
            ExerciseUpdateDto exerciseUpdateDto = ExerciseMapper.MapToExerciseUpdateDto(Exercise);
            var response = await ExerciseDataService.PutUpdatedExercise(exerciseUpdateDto);
            
            if (response.IsSuccessStatusCode)
            {
                OriginalName = Exercise.Name;
            }
        }
        else
        {
            ExerciseCreateDto exerciseCreateDto = ExerciseMapper.MapToExerciseCreateDto(Exercise);
            var response = await ExerciseDataService.PostNewExercise(exerciseCreateDto);

            if (response.IsSuccessStatusCode)
            {
                var createdExerciseDetails = await response.Content.ReadFromJsonAsync<ExerciseDetailsDto>();
                if (createdExerciseDetails is not null)
                {
                    NavigationManager.NavigateTo($"exercises/{createdExerciseDetails.Id}");
                }
            }
        }
    }

    private async Task DeleteExercise(int exerciseId)
    {
        if (Exercise is null) return;

        var response = await ExerciseDataService.DeleteExercise(exerciseId);

        if (response.IsSuccessStatusCode)
        {
            NavigationManager.NavigateTo("exercises/");
        }
    }
}
