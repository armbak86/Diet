namespace Diet.WebMVC.Repositories;

public class RegimenRepository : IRegimenRepository
{
    private readonly AppDbContext _context;

    public RegimenRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Regimen> CreateRegimenAsync(Regimen regimen)
    {
        _context.Add(regimen);
        await _context.SaveChangesAsync();

        return regimen;
    }

    public async Task DeleteRegimenAsync(Regimen regimen)
    {
        _context.Remove(regimen);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Regimen>> GetRegimensAsync() => await _context.Regimens.ToListAsync();

    public async Task<Regimen> GetRegimenAsync(int id) => await _context.Regimens.FindAsync(id);

    public async Task<bool> UpdateRegimenAsync(Regimen regimen)
    {
        try
        {
            _context.Regimens.Update(regimen);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await RegimenExists(regimen.Id))
                return false;
            else
                throw;
        }
    }

    public async Task DeleteRegimenAsync(int id)
    {
        _context.Remove(await GetRegimenAsync(id));
        await _context.SaveChangesAsync();
    }

    public async Task<bool> RegimenExists(int id) => await _context.Regimens.AnyAsync(e => e.Id == id);
}
