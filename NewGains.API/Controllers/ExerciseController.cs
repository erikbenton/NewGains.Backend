using Microsoft.AspNetCore.Mvc;
using NewGains.API.Dtos.Exercises;
using NewGains.API.Mappers;
using NewGains.DataAccess.Repositories;
using System.Xml.Linq;

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
    public async Task<ActionResult<IEnumerable<ExerciseDto>>> GetAllExercises()
	{
		var exercises = await exerciseRepository.GetAllAsync();

		var dtos = exercises.Select(e => ExerciseMapper.MapToExerciseDetailsDto(e));

        return Ok(dtos);
	}

	[HttpGet("{id:int}", Name = nameof(GetExerciseById))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ExerciseDetailsDto>> GetExerciseById(int id)
	{
		var exercise = await exerciseRepository.GetByIdAsync(id);

		if (exercise is null) return NotFound();

		var dto = ExerciseMapper.MapToExerciseDetailsDto(exercise);

		return Ok(dto);
	}

	[HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<ExerciseCreateDto>> CreateExercise(
		[FromBody] ExerciseCreateDto newDto)
	{
		var newExercise = ExerciseMapper.MapToExercise(newDto);

		var savedExercise = await exerciseRepository.Add(newExercise);

		var savedDto = ExerciseMapper.MapToExerciseDetailsDto(savedExercise);

		return CreatedAtRoute(
            nameof(GetExerciseById),
			new { id = savedExercise.Id },
			savedDto);
	}

	[HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateExercise(
		int id,
		[FromBody] ExerciseUpdateDto updatedDto)
	{
		if (id != updatedDto.Id) return BadRequest("Exercise ID does not match request ID.");

		var updatedExercise = ExerciseMapper.MapToExercise(updatedDto);

		try
		{
			await exerciseRepository.Update(updatedExercise);
		}
		catch(ArgumentException e)
		{
			Console.WriteLine(e.Message);
		}
		catch
		{
            return BadRequest("Error updating with supplied data.");
        }

        return NoContent();
    }

	[HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteExercise(int id)
	{
		if (await exerciseRepository.RemoveExercise(id))
		{
			return NoContent();
		}
		else
		{
			return NotFound($"Unable to find Exercise with Id: {id}.");
		}
	}
}
