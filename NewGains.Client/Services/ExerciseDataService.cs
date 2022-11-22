using NewGains.DataTransfer.Exercises;
using System.Net;
using System.Net.Http.Json;
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

	public async Task<HttpResponseMessage> PostNewExercise(ExerciseCreateDto exerciseDto)
	{
		return await client.PostAsJsonAsync("api/exercises", exerciseDto);
    }

    public async Task<HttpResponseMessage> PutUpdatedExercise(ExerciseUpdateDto exerciseDto)
    {
        return await client.PutAsJsonAsync($"api/exercises/{exerciseDto.Id}", exerciseDto);
    }

	public async Task<HttpResponseMessage> DeleteExercise(int exerciseId)
	{
        return await client.DeleteAsync($"api/exercises/{exerciseId}");
    }
}
