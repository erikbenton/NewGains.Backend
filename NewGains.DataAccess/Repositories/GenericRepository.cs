using Microsoft.EntityFrameworkCore;

namespace NewGains.DataAccess.Repositories;

public abstract class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
    where TEntity : class
    where TContext : DbContext
{
    protected readonly TContext Context;

    public GenericRepository(TContext context)
    {
        Context = context;
    }

    public async Task<TEntity> Add(TEntity model)
    {
        Context.Set<TEntity>().Add(model);
        await Context.SaveChangesAsync();
        return model;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await Context.Set<TEntity>().ToListAsync();
    }

    public virtual async Task<TEntity?> GetByIdAsync(int id)
    {
        var result = await Context.Set<TEntity>().FindAsync(id);
        //if (result is null)
        //{
        //    throw new ArgumentException(
        //        $"No Entity: {nameof(TEntity)} was found with Id: {id}");
        //}
        return result;
    }

    public bool HasChanges()
    {
        return Context.ChangeTracker.HasChanges();
    }

    public virtual async void Remove(TEntity model)
    {
        Context.Set<TEntity>().Remove(model);
        await Context.SaveChangesAsync();
    }
}
