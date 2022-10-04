using NewGains.Core.Entities;

namespace NewGains.DataAccess.Repositories;

public interface ITemplatesRepository
{
    Task<IEnumerable<Template>> GetAllTemplatesAsync();
}