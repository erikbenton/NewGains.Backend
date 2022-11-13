using NewGains.DataTransfer.Exercises;

namespace NewGains.Client.Services
{
    public interface IExerciseDataService
    {
        Task<IEnumerable<ExerciseDto>?> GetAllExercises();
    }
}