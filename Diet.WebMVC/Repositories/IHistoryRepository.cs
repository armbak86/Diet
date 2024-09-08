namespace Diet.WebMVC.Repositories;

public interface IHistoryRepository : IGenericRepository<History>
{
    // To get specific history with it's FoodItems loaded
    Task<History> GetFoodsLoadedHistoryAsync(string userId);
    // To get specific history with it's ExerciseItems loaded
    Task<History> GetExercisesLoadedHistoryAsync(string userId);
    Task<int> GetHistoryIdAsync(string userId);
}