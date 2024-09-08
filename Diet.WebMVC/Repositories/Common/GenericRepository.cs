
namespace Diet.WebMVC.Repositories.Common;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _context;

    public GenericRepository(AppDbContext context) => _context = context;

    public async Task<T> AddAsync(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

    public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);


    public async Task RemoveAsync(int id)
    {
        _context.Set<T>().Remove(await GetByIdAsync(id));
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> SelectAsync(Expression<Func<T, bool>> predicate) => await _context.Set<T>().Where(predicate).ToListAsync();

    public IQueryable<T> Queryable() => _context.Set<T>();

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> Exists(int id) => await _context.Set<T>().AnyAsync(x => x.Id == id);
}
