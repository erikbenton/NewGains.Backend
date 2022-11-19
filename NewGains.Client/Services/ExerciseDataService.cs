using NewGains.DataTransfer.Exercises;
using System.Text.Json;

namespace NewGains.Client.Services;

public class ExerciseDataService : IExerciseDataService
{
	private readonly HttpClient client;

	public ExerciseDataService(HttpClient client)
	{
		this.client = client;
	}

	public async Task<IEnumerable<ExerciseDto>?> GetAllExercises()
	{
		var exercises = await JsonSerializer.DeserializeAsync<IEnumerable<ExerciseDto>>(
			await client.GetStreamAsync($"api/exercises"),
			new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

		return exercises;
	}

	public async Task<ExerciseDetailsDto?> GetExerciseDetails(int exerciseId)
	{
        var exercise = await JsonSerializer.DeserializeAsync<ExerciseDetailsDto>(
            await client.GetStreamAsync($"api/exercises/{exerciseId}"),
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

		return exercise;
    }
}
