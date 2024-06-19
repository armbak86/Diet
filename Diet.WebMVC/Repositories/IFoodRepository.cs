namespace Diet.WebMVC.Repositories;

public interface IFoodRepository
{
    Task<IEnumerable<Food>> GetFoodsAsync();
    Task<Food> GetFoodAsync(int id);
    Task<Food> CreateFoodAsync(Food food);
    Task UpdateFoodAsync(Food food);
    Task DeleteFoodAsync(Food food);
    Task DeleteFoodAsync(int id);
}