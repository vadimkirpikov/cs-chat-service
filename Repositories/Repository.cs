using ChatService.Data;
using Microsoft.EntityFrameworkCore;

namespace ChatService.Repositories;


public interface IRepository<T> where T : class
{
    Task CreateAsync(T entity);
    Task<T?> GetAsync(int id);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
public class Repository<T> (ApplicationDbContext context): IRepository<T> where T : class
{
    protected readonly ApplicationDbContext Context = context;
    protected readonly DbSet<T> Entities = context.Set<T>();
    public async Task CreateAsync(T entity)
    {
        await Context.AddAsync(entity);
        await Context.SaveChangesAsync();
    }

    public async Task<T?> GetAsync(int id)
    {
        return await Entities.FindAsync(id);
    }

    public async Task UpdateAsync(T entity)
    {
        Entities.Update(entity);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        Entities.Remove(entity);
        await Context.SaveChangesAsync();
    }
}