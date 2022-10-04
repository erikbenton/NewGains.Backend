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
}
