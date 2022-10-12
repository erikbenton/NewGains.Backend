using Microsoft.EntityFrameworkCore;
using NewGains.Core.Entities;
using NewGains.DataAccess.Contexts;

namespace NewGains.DataAccess.Repositories;

public class ExerciseSqlRepository : IExerciseRepository
{
    private readonly NewGainsDbContext context;

    public ExerciseSqlRepository(NewGainsDbContext context)
    {
        this.context = context;
    }

    public async Task<Exercise> Add(Exercise newExercise)
    {
        context.Exercises.Add(newExercise);

        await context.SaveChangesAsync();

        return newExercise;
    }

    public async Task<IEnumerable<Exercise>> GetAllAsync()
    {
        return await context.Exercises.ToListAsync();
    }

    public async Task<Exercise?> GetByIdAsync(int id)
    {
        var exercise = await context.Exercises
            .Include(e => e.Instructions)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (exercise is not null)
        {
            exercise.Instructions = exercise.Instructions?
                .OrderBy(i => i.StepNumber);
        }

        return exercise;
    }

    public async Task<Exercise> Update(Exercise updatedExercise)
    {
        try
        {
            await UpdateInstructions(updatedExercise);
            context.Entry(updatedExercise).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }

        return updatedExercise;
    }

    public async Task<bool> RemoveExercise(int exerciseId)
    {
        var exercise = await context.Exercises.FindAsync(exerciseId);

        if (exercise is null) return false;

        context.Remove(exercise);

        await context.SaveChangesAsync();

        return true;
    }

    private async Task UpdateInstructions(Exercise updatedExercise)
    {
        if (context.Entry(updatedExercise).State != EntityState.Detached)
        {
            throw new ArgumentException(
                "Exercise EntityState must be detached before updating its Instructions.");
        }

        var savedInstructions = await context.Instructions
            .Where(i => i.ExerciseId == updatedExercise.Id)
            .ToListAsync();

        var updatedInstructions = updatedExercise.Instructions is null
            ? new List<Instruction>()
            : updatedExercise.Instructions;

        var deletedInstructions = savedInstructions
            .Except(updatedInstructions, new IdComparer<Instruction>());

        foreach (var instruction in deletedInstructions)
        {
            context.Instructions.Remove(instruction);
        }

        int currentStepNumber = 1;
        foreach (var instruction in updatedInstructions)
        {
            instruction.StepNumber = currentStepNumber++;

            if (instruction.Id > 0)
            {
                context.Entry(instruction).State = EntityState.Modified;
            }
            else
            {
                context.Entry(instruction).State = EntityState.Added;
            }
        }
    }
}
