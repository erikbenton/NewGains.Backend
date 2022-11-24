using NewGains.DataTransfer.Templates;

namespace NewGains.Client.Services
{
    public interface ITemplateDataService
    {
        Task<HttpResponseMessage> DeleteTemplate(int templateId);
        Task<IEnumerable<TemplateDto>?> GetAllTemplates();
        Task<TemplateDetailsDto?> GetTemplateDetails(int templateId);
        Task<HttpResponseMessage> PostNewTemplate(TemplateCreateDto templateDto);
        Task<HttpResponseMessage> PutUpdatedTemplate(TemplateUpdateDto templateDto);
    }
}