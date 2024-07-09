namespace Diet.WebMVC.Repositories.Interfaces;

public interface IRegimenRepository
{
    Task<IEnumerable<Regimen>> GetRegimensAsync();
    Task<Regimen> GetRegimenAsync(int id);
    Task<Regimen> CreateRegimenAsync(Regimen regimen);
    Task<bool> UpdateRegimenAsync(Regimen regimen);
    Task DeleteRegimenAsync(Regimen regimen);
    Task DeleteRegimenAsync(int id);
    public Task<bool> RegimenExists(int id);
}