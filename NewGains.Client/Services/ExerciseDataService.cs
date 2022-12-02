using Blazored.LocalStorage;
using NewGains.Client.Helper;
using NewGains.DataTransfer.Exercises;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace NewGains.Client.Services;

public class ExerciseDataService : IExerciseDataService
{
	private readonly HttpClient client;
	private readonly ILocalStorageService localStorageService;

	public ExerciseDataService(HttpClient client, ILocalStorageService localStorageService)
	{
		this.client = client;
		this.localStorageService = localStorageService;
	}

	public async Task<IEnumerable<ExerciseDto>?> GetAllExercises(bool refreshRequired = false)
	{
		// if we aren't refreshing
		if (!refreshRequired)
		{
			// Check if there's exercises possibly stored in local storage
			bool exercisesExpirationInLocalStorage = await localStorageService
				.ContainKeyAsync(LocalStorageConstants.ExerciseListExpirationKey);


			if (exercisesExpirationInLocalStorage)
			{
				// make sure they haven't expired
				DateTime exerciseListExpirationTime = await localStorageService
					.GetItemAsync<DateTime>(LocalStorageConstants.ExerciseListExpirationKey);

				// if the data isn't expired
				if (exerciseListExpirationTime > DateTime.Now)
				{
					// check the data does exist
					bool exerciseDataInLocalStorage = await localStorageService
						.ContainKeyAsync(LocalStorageConstants.ExerciseListKey);

					if (exerciseDataInLocalStorage)
					{
						// return the cached data
						return await localStorageService
							.GetItemAsync<IEnumerable<ExerciseDto>?>(
								LocalStorageConstants.ExerciseListKey);
					}
				}

			}
		}

		// get the exercises from api
		var exercises = await JsonSerializer.DeserializeAsync<IEnumerable<ExerciseDto>>(
			await client.GetStreamAsync($"api/exercises"),
			new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

		// set the exercises in local storage
		await localStorageService
			.SetItemAsync(LocalStorageConstants.ExerciseListKey, exercises);

		// set 1 min expiration time
		await localStorageService
			.SetItemAsync(LocalStorageConstants.ExerciseListExpirationKey, DateTime.Now.AddMinutes(1));

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
