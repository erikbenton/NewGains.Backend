using Microsoft.AspNetCore.Mvc;
using NewGains.API.Dtos.Exercises;
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ExerciseDto>>> GetAll()
	{
		var exercises = await exerciseRepository.GetAllAsync();

		var dtos = exercises.Select(e => new ExerciseDto(e));

        return Ok(dtos);
	}

	[HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ExerciseDetailsDto>> GetById(int id)
	{
		var exercise = await exerciseRepository.GetByIdAsync(id);

		if (exercise is null) return NotFound();

		var dto = new ExerciseDetailsDto(exercise);

		return Ok(dto);
	}
}
