using NewGains.Core.Entities;

namespace NewGains.DataAccess.Repositories;

public interface ITemplatesRepository
{
    Task<Template> AddTemplateAsync(Template newTemplate);
    Task<IEnumerable<Template>> GetAllTemplatesAsync();
    Task<Template?> GetTemplateByIdAsync(int id);
    Task<bool> RemoveTemplate(int templateId);
    Task<Template> UpdateTemplate(Template updatedTemplate);
}