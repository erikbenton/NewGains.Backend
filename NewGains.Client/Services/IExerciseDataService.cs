using NewGains.DataTransfer.Exercises;
using System.Net;

namespace NewGains.Client.Services
{
    public interface IExerciseDataService
    {
        Task<HttpResponseMessage> DeleteExercise(int exerciseId);
        Task<IEnumerable<ExerciseDto>?> GetAllExercises();
        Task<ExerciseDetailsDto?> GetExerciseDetails(int exerciseId);
        Task<HttpResponseMessage> PostNewExercise(ExerciseCreateDto exerciseDto);
        Task<HttpResponseMessage> PutUpdatedExercise(ExerciseUpdateDto exerciseDto);
    }
}