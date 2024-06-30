namespace Diet.WebMVC.Repositories.Interfaces;

public interface IFoodRepository
{
    Task<IEnumerable<Food>> GetFoodsAsync();
    Task<Food> GetFoodAsync(int id);
    Task<Food> CreateFoodAsync(Food food);
    Task<bool> UpdateFoodAsync(Food food);
    Task DeleteFoodAsync(Food food);
    Task DeleteFoodAsync(int id);
    public Task<bool> FoodExists(int id);
}