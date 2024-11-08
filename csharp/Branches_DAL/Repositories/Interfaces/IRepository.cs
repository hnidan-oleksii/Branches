using System.Linq.Expressions;

namespace Branches_DAL.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<T> AddAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<int> DeleteAsync(int id);
}