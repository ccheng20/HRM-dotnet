using System.Linq.Expressions;
using ApplicationCore.Contracts.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class Repository<T>: IRepository<T> where T : class
{
    private readonly InterviewDbContext _dbContext;

    public Repository(InterviewDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }
    
    public async Task<bool> GetExistsAsync(Expression<Func<T, bool>>? filter = null)
    {
        if (filter == null)
        {
            return false;
        }
        return await Queryable.Where(_dbContext.Set<T>(), filter).AnyAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        await _dbContext.SaveChangesAsync(); // actually change the database
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var entity = await _dbContext.Set<T>().FindAsync(id);
        if (entity != null)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        return id;
    }
}