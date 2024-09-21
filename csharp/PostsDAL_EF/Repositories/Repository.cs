using Microsoft.EntityFrameworkCore;
using PostsDAL_EF.Context;
using PostsDAL_EF.Exceptions;
using PostsDAL_EF.Repositories.Interfaces;

namespace PostsDAL_EF.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly PostsContext _context;
    protected readonly DbSet<T> _table;

    public Repository(PostsContext context)
    {
        _context = context;
        _table = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _table.ToListAsync()
               ?? throw new EntityNotFoundException($"Couldn't retrieve entities from {nameof(T)}");
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _table.FindAsync(id)
               ?? throw new KeyNotFoundException($"{typeof(T).Name} with id {id} could not be found.");
    }

    public async Task<T> AddAsync(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException($"{typeof(T).Name} entity cannot be null");
        }

        var newEntity = await _table.AddAsync(entity);
        return newEntity.Entity;
    }

    public async Task UpdateAsync(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException($"{typeof(T).Name} entity cannot be null");
        }

        await Task.Run(() => _table.Update(entity));
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id)
                     ?? throw new KeyNotFoundException($"Couldn't retrieve entities from {nameof(T)}");
        await Task.Run(() => _table.Remove(entity));
    }
}