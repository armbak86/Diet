namespace Diet.WebMVC.Repositories.Interfaces;

public interface IHistoryFoodItemRepository
{
    Task<IEnumerable<HistoryFoodItem>> GetHistoryFoodItemsAsync(int historyId);
    Task<HistoryFoodItem> GetHistoryFoodItemAsync(int id);
    Task<HistoryFoodItem> CreateHistoryFoodItemAsync(HistoryFoodItem item);
    Task UpdateHistoryFoodItemAsync(HistoryFoodItem item);
    Task DeleteHistoryFoodItemAsync(HistoryFoodItem item);
    Task DeleteHistoryFoodItemAsync(int id);
}