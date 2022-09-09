using Microsoft.AspNetCore.Mvc;
using NewGains.Core.Entities;
using NewGains.DataAccess.Repositories;

namespace NewGains.API.Controllers;

[ApiController]
[Route("exercises")]
public class ExerciseController : ControllerBase
{
	private readonly IExerciseRepository exerciseRepository;

	public ExerciseController(IExerciseRepository exerciseRepository)
	{
		this.exerciseRepository = exerciseRepository;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Exercise>>> GetAll()
	{
		var exercises = await exerciseRepository.GetAllAsync();

        return Ok(exercises);
	}
}
