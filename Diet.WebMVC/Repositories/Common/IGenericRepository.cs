namespace Diet.WebMVC.Repositories.Common;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task RemoveAsync(int id);
    Task RemoveAsync(T entity);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    public IQueryable<T> Queryable();
    public Task<IEnumerable<T>> SelectAsync(Expression<Func<T, bool>> predicate);
    public Task<bool> Exists(int id);
}
