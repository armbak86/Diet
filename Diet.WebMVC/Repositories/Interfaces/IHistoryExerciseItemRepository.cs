namespace Diet.WebMVC.Repositories.Interfaces;

public interface IHistoryExerciseItemRepository
{
    Task<IEnumerable<HistoryExerciseItem>> GetHistoryExerciseItemsAsync(int historyId);
    Task<HistoryExerciseItem> GetHistoryExerciseItemAsync(int id);
    Task<HistoryExerciseItem> CreateHistoryExerciseItemAsync(HistoryExerciseItem item);
    Task UpdateHistoryExerciseItemAsync(HistoryExerciseItem item);
    Task DeleteHistoryExerciseItemAsync(HistoryExerciseItem item);
    Task DeleteHistoryExerciseItemAsync(int id);
}