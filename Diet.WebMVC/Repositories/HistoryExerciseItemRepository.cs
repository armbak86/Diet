using Diet.WebMVC.Repositories.Interfaces;

namespace Diet.WebMVC.Repositories;

public class HistoryExerciseItemRepository : IHistoryExerciseItemRepository
{
    private readonly AppDbContext _context;

    public HistoryExerciseItemRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<HistoryExerciseItem> CreateHistoryExerciseItemAsync(HistoryExerciseItem item)
    {
        _context.Add(item);
        await _context.SaveChangesAsync();

        return item;
    }

    public async Task DeleteHistoryExerciseItemAsync(HistoryExerciseItem item)
    {
        _context.Remove(item);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<HistoryExerciseItem>> GetHistoryExerciseItemsAsync(int historyId) => await _context.HistoryExerciseItems.ToListAsync();

    public async Task<HistoryExerciseItem> GetHistoryExerciseItemAsync(int id) => await _context.HistoryExerciseItems.FindAsync(id);

    public async Task UpdateHistoryExerciseItemAsync(HistoryExerciseItem item)
    {
        _context.HistoryExerciseItems.Update(item);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteHistoryExerciseItemAsync(int id)
    {
        _context.Remove(await GetHistoryExerciseItemAsync(id));
        await _context.SaveChangesAsync();
    }
}
