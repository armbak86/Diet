using Diet.WebMVC.Repositories.Interfaces;

namespace Diet.WebMVC.Repositories;

public class HistoryRepository : IHistoryRepository
{
    private readonly AppDbContext _context;

    public HistoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<History> CreateHistoryAsync(History history)
    {
        _context.Add(history);
        await _context.SaveChangesAsync();

        return history;
    }

    public async Task DeleteHistoryAsync(History history)
    {
        _context.Remove(history);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteHistoryAsync(int id)
    {
        _context.Remove(await GetHistoryAsync(id));
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<History>> GetHistoriesAsync() => await _context.Histories.ToListAsync();

    public async Task<History> GetHistoryAsync(int id) => await _context.Histories.FindAsync(id);

    public Task<History> GetHistoryByUserIdAsync(string userId) => _context.Histories.FirstOrDefaultAsync(x => x.AppUserId == userId);

    public async Task UpdateHistoryAsync(History history)
    {
        _context.Histories.Update(history);
        await _context.SaveChangesAsync();
    }
}
