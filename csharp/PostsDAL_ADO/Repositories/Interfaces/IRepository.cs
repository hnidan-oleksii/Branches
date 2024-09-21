namespace PostsDAL_ADO.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<int> AddAsync(T t);
    Task<int> UpdateAsync(T t);
    Task<int> DeleteAsync(int id);
}