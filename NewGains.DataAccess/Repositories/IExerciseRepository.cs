using NewGains.Core.Entities;

namespace NewGains.DataAccess.Repositories;

public interface IExerciseRepository
{
    Task<IEnumerable<Exercise>> GetAllAsync();

    Task<Exercise?> GetByIdAsync(int id);
}