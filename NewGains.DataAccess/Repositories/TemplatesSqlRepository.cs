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
            .ToListAsync();
    }

    public async Task<Template?> GetTemplateByIdAsync(int id)
    {
        var template = await context.Templates
            .Include(t => t.SetGroups)
                .ThenInclude(setGroup => setGroup.Exercise)
            .Include(t => t.SetGroups)
                .ThenInclude(setGroup => setGroup.Sets)
            .FirstOrDefaultAsync(t => t.Id == id);


        if (template?.SetGroups is not null)
        {
            template.SetGroups.OrderBy(setGroup => setGroup.SetGroupNumber);
            foreach (var setGroup in template.SetGroups)
            {
                setGroup.Sets?.OrderBy(set => set.SetNumber);
            }
        }

        return template;
    }

    public async Task<Template> AddTemplateAsync(Template newTemplate)
    {
        context.Templates.Add(newTemplate);

        await context.SaveChangesAsync();

        return await GetTemplateByIdAsync(newTemplate.Id);
    }
}
