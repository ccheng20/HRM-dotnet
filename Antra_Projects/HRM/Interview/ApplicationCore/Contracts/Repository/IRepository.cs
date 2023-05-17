namespace ApplicationCore.Contracts.Repository;
using System.Linq.Expressions;
public interface IRepository<T> where T: class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<bool> GetExistsAsync(Expression<Func<T, bool>>? filter = null);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<int> DeleteAsync(int id);

}