using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepoitory<T> where T : class
{
    private readonly SchoolDbContext _context;
    private readonly DbSet<T> _dbSet;
    public GenericRepository(SchoolDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();

    }

    public async Task<T> AddAsync(T entity)
    {
       _dbSet.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var deleteEntity = await _dbSet.FindAsync(id);
        if (deleteEntity != null) {
        
                _dbSet.Remove(deleteEntity);
            await _context.SaveChangesAsync();
        
        }
    }

    public async Task<IEnumerable<T>> GetAll()
    {
      return  await _dbSet.ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();

    }

    public async Task<T?> GetByIdAsync(int id)
    {
       return await _dbSet.FindAsync(id);
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }
}
