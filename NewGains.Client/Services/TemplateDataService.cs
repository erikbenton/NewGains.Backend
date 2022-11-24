using NewGains.DataTransfer.Templates;
using System.Net.Http.Json;
using System.Text.Json;

namespace NewGains.Client.Services;

public class TemplateDataService : ITemplateDataService
{
	private readonly HttpClient client;

	public TemplateDataService(HttpClient client)
	{
		this.client = client;
	}

	public async Task<IEnumerable<TemplateDto>?> GetAllTemplates()
	{
		var response = await client.GetStreamAsync("api/templates");
		var templates = await JsonSerializer.DeserializeAsync<IEnumerable<TemplateDto>>(
			response,
			new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

		return templates;
	}

    public async Task<TemplateDetailsDto?> GetTemplateDetails(int templateId)
    {
        var response = await client.GetStreamAsync($"api/templates/{templateId}");
        var template = await JsonSerializer.DeserializeAsync<TemplateDetailsDto>(
            response,
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        return template;
    }

	public async Task<HttpResponseMessage> PostNewTemplate(TemplateCreateDto templateDto)
	{
		return await client.PostAsJsonAsync("api/templates", templateDto);
	}

    public async Task<HttpResponseMessage> PutUpdatedTemplate(TemplateUpdateDto templateDto)
    {
        return await client.PutAsJsonAsync($"api/templates/{templateDto.Id}", templateDto);
    }

	public async Task<HttpResponseMessage> DeleteTemplate(int templateId)
	{
		return await client.DeleteAsync($"api/templates/{templateId}");
	}
}
