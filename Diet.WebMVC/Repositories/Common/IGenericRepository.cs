namespace Diet.WebMVC.Repositories.Common;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<T> GetByIdWithIncludesAsync(int id);
    Task Remove(int id);
    Task Add(T entity);
    Task Update(T entity);
    public Task<IEnumerable<T>> SelectAsync(Expression<Func<T, bool>> predicate);
}
