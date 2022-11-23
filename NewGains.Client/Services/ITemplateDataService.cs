using NewGains.DataTransfer.Templates;

namespace NewGains.Client.Services
{
    public interface ITemplateDataService
    {
        Task<IEnumerable<TemplateDto>?> GetAllTemplates();
        Task<TemplateDetailsDto?> GetTemplateDetails(int templateId);
        Task<HttpResponseMessage> PostNewTemplate(TemplateCreateDto templateDto);
        Task<HttpResponseMessage> PutUpdatedTemplate(TemplateUpdateDto templateDto);
    }
}