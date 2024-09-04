namespace Diet.WebMVC.Repositories.Interfaces;

public interface IHistoryRepository
{
    Task<IEnumerable<History>> GetHistoriesAsync();
    Task<History> GetHistoryAsync(int id);
    Task<History> GetHistoryIncludedByUserIdAsync(string userId);
    Task<History> CreateHistoryAsync(History history);
    Task UpdateHistoryAsync(History history);
    Task DeleteHistoryAsync(History history);
    Task DeleteHistoryAsync(int id);
    Task<int> GetHistoryIdAsync(string userId);
}