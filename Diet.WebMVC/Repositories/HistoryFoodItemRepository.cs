using Diet.WebMVC.Repositories.Interfaces;

namespace Diet.WebMVC.Repositories;

public class HistoryFoodItemRepository : IHistoryFoodItemRepository
{
    private readonly AppDbContext _context;

    public HistoryFoodItemRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<HistoryFoodItem> CreateHistoryFoodItemAsync(HistoryFoodItem item)
    {
        _context.Add(item);
        await _context.SaveChangesAsync();

        return item;
    }

    public async Task DeleteHistoryFoodItemAsync(HistoryFoodItem item)
    {
        _context.Remove(item);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<HistoryFoodItem>> GetHistoryFoodItemsAsync(int historyId) => await _context.HistoryFoodItems.ToListAsync();

    public async Task<HistoryFoodItem> GetHistoryFoodItemAsync(int id) => await _context.HistoryFoodItems.FindAsync(id);

    public async Task UpdateHistoryFoodItemAsync(HistoryFoodItem item)
    {
        _context.HistoryFoodItems.Update(item);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteHistoryFoodItemAsync(int id)
    {
        _context.Remove(await GetHistoryFoodItemAsync(id));
        await _context.SaveChangesAsync();
    }
}
