using System.Linq.Expressions;
using ApplicationCore.Contracts.Repositories;
using ClassLibrary1.Data;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1.Repositories;

//generic constraints: where T: class
public class Repository<T>: IRepository<T> where T:class
{
    protected readonly RecruitingDbContext _dbContext;

    public Repository(RecruitingDbContext dbContext)
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

    public async Task<int> UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}