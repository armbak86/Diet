namespace Diet.WebMVC.Repositories.Interfaces;

public interface IHistoryRepository:IGenericRepository<History>
{
    Task<History> GetLoadedHistoryAsync(string userId);
    Task<int> GetHistoryIdAsync(string userId);
}