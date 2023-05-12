using System.Linq.Expressions;

namespace ApplicationCore.Contracts.Repositories;

public interface IRepository<T> where T: class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<bool> GetExistsAsync(Expression<Func<T, bool>>? filter = null);
    Task<T> AddAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<int> DeleteAsync(int id);

}