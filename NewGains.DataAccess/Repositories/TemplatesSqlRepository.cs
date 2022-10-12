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
        try
        {
            context.Templates.Add(newTemplate);

            await context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }

        return (await GetTemplateByIdAsync(newTemplate.Id))!;
    }

    public async Task<Template> UpdateTemplate(Template updatedTemplate)
    {
        try
        {
            if (updatedTemplate.SetGroups is not null)
            {
                foreach (var setGroup in updatedTemplate.SetGroups)
                {
                    await UpdateSets(setGroup);
                }
            }
            await UpdateSetGroups(updatedTemplate);
            context.Entry(updatedTemplate).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }

        return updatedTemplate;
    }

    public async Task<bool> RemoveTemplate(int templateId)
    {
        var template = await context.Templates.FindAsync(templateId);

        if (template is null) return false;

        context.Remove(template);

        await context.SaveChangesAsync();

        return true;
    }

    private async Task UpdateSetGroups(Template updatedTemplate)
    {
        if (context.Entry(updatedTemplate).State != EntityState.Detached)
        {
            throw new ArgumentException(
                "Template EntityState must be detached before updating its Set Groups.");
        }

        var savedSetGroups = await context.TemplateSetGroups
            .Where(setGroup => setGroup.TemplateId == updatedTemplate.Id)
            .ToListAsync();

        var updatedSetGroups = updatedTemplate.SetGroups is null
            ? new List<TemplateSetGroup>()
            : updatedTemplate.SetGroups;

        var deletedInstructions = savedSetGroups
            .Except(updatedSetGroups, new IdComparer<TemplateSetGroup>());

        foreach (var instruction in deletedInstructions)
        {
            context.TemplateSetGroups.Remove(instruction);
        }

        int currentGroupNumber = 1;
        foreach (var setGroup in updatedSetGroups)
        {
            setGroup.SetGroupNumber = currentGroupNumber++;

            if (setGroup.Id > 0)
            {
                context.Entry(setGroup).State = EntityState.Modified;
            }
            else
            {
                context.Entry(setGroup).State = EntityState.Added;
            }
        }
    }

    private async Task UpdateSets(TemplateSetGroup updatedSetGroup)
    {
        if (context.Entry(updatedSetGroup).State != EntityState.Detached)
        {
            throw new ArgumentException(
                "TemplateSetGroup EntityState must be detached before updating its Sets.");
        }

        var savedSets = await context.TemplateSets
            .Where(setGroup => setGroup.SetGroupId == updatedSetGroup.Id)
            .ToListAsync();

        var updatedSets = updatedSetGroup.Sets is null
            ? new List<TemplateSet>()
            : updatedSetGroup.Sets;

        var deletedSets = savedSets
            .Except(updatedSets, new IdComparer<TemplateSet>());

        foreach (var set in deletedSets)
        {
            context.TemplateSets.Remove(set);
        }

        int currentSetNumber = 1;
        foreach (var setGroup in updatedSets)
        {
            setGroup.SetNumber = currentSetNumber++;

            if (setGroup.Id > 0)
            {
                context.Entry(setGroup).State = EntityState.Modified;
            }
            else
            {
                context.Entry(setGroup).State = EntityState.Added;
            }
        }
    }
}