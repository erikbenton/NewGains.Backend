using Microsoft.EntityFrameworkCore;
using NewGains.Core.Entities;
using NewGains.DataAccess.Contexts;

namespace NewGains.DataAccess.Repositories;

public class TemplatesSqlRepository : ITemplatesRepository
{
    private readonly NewGainsDbContext context;

    public TemplatesSqlRepository(NewGainsDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Template>> GetAllTemplatesAsync()
    {
        return await context.Templates
            .Include(t => t.SetGroups)
            .ThenInclude(setGroup => setGroup.Exercise)
            .Include(t => t.SetGroups)
            .ThenInclude(setGroup => setGroup.Sets)
            .ToArrayAsync();
    }
}
