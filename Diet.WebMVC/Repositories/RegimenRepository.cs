namespace Diet.WebMVC.Repositories;

public class RegimenRepository : GenericRepository<History>, IRegimenRepository
{
    private readonly AppDbContext _context;

    public RegimenRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task BuyRegimen(string userId,int regimenId)
    {
        var user = await _context.Users.Include(u => u.Regimens).FirstAsync(u => u.Id == userId);
        user.Regimens.Add(await _context.Regimens.FindAsync(regimenId));
        await _context.SaveChangesAsync();
    }

    public async Task<bool> RegimenBought(string userId, int regimenId)
    {
        var regimensForUser = await _context.Users.Where(u => u.Id == userId).Include(u => u.Regimens).Select(u => u.Regimens).FirstAsync();
        return regimensForUser?.Any(r => r.Id == regimenId) ?? false;
    }
}
