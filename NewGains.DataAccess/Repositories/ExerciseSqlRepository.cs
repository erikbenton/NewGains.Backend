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

    public async Task<IEnumerable<Exercise>> GetAllAsync()
    {
        return await context.Exercises.ToListAsync();
    }

    public async Task<Exercise?> GetByIdAsync(int id)
    {
        return await context.Exercises
            .Include(e => e.Instructions)
            .FirstOrDefaultAsync(e => e.Id == id);
    }
}
