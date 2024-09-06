namespace Diet.WebMVC.Repositories;

public class HistoryRepository : GenericRepository<History>, IHistoryRepository
{
    private readonly AppDbContext _context;

    public HistoryRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<int> GetHistoryIdAsync(string userId) => (await _context.Histories.Where(h => h.AppUserId == userId).FirstAsync()).Id;

    public async Task<History> GetLoadedHistoryAsync(string userId) => await _context.Histories.Include(h => h.FoodHistoryItems).FirstOrDefaultAsync(x => x.AppUserId == userId);

}
