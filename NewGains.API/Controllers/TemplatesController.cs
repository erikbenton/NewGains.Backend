using Microsoft.AspNetCore.Mvc;
using NewGains.API.Dtos.Templates;
using NewGains.API.Mappers;
using NewGains.DataAccess.Repositories;

namespace NewGains.API.Controllers;

[ApiController]
[Route("templates")]
public class TemplatesController : ControllerBase
{
	private readonly ITemplatesRepository templatesRepository;

	public TemplatesController(ITemplatesRepository templatesRepository)
	{
		this.templatesRepository = templatesRepository;
	}

	[HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<TemplateDto>>> GetAllTemplates()
	{
		var templates = await templatesRepository.GetAllTemplatesAsync();

		var templateDtos = templates.Select(template => TemplateMapper.MapToTemplateDto(template));

		return Ok(templateDtos);
	}

	[HttpGet("{id:int}", Name = nameof(GetTemplateById))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TemplateDto>> GetTemplateById(int id)
	{
		var template = await templatesRepository.GetTemplateByIdAsync(id);

		if (template is null) return NotFound();

		var templateDto = TemplateMapper.MapToTemplateDetailsDto(template);

		return Ok(templateDto);
	}

	[HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<TemplateCreateDto>> CreateTemplate([FromBody] TemplateCreateDto newTemplateDto)
	{
		var template = TemplateMapper.MapToTemplate(newTemplateDto);

		var savedTemplate = await templatesRepository.AddTemplateAsync(template);

		var savedDto = TemplateMapper.MapToTemplateDto(savedTemplate);

		return CreatedAtRoute(
            nameof(GetTemplateById),
            new { id = savedTemplate.Id },
            savedDto);
    }

	[HttpPut("{templateId:int}")]
	public async Task<ActionResult<TemplateDto>> UpdateTemplate(int templateId, [FromBody] TemplateUpdateDto updatedTemplateDto)
	{
		if (templateId != updatedTemplateDto.Id) return BadRequest("Template ID does not match with request.");

		var updatedTemplate = TemplateMapper.MapToTemplate(updatedTemplateDto);

        try
        {
            await templatesRepository.UpdateTemplate(updatedTemplate);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
        catch
        {
            return BadRequest("Error updating with supplied data.");
        }

        return NoContent();
    }

	[HttpDelete("{templateId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteTemplate(int templateId)
	{
		if (await templatesRepository.RemoveTemplate(templateId))
		{
			return NoContent();
		}
		else
		{
            return NotFound($"Unable to find Template with Id: {templateId}.");
        }
	}
}
