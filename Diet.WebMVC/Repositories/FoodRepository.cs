﻿namespace Diet.WebMVC.Repositories;

public class FoodRepository : IFoodRepository
{
    private readonly AppDbContext _context;

    public FoodRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Food> CreateFoodAsync(Food food)
    {
        _context.Add(food);
        await _context.SaveChangesAsync();

        return food;
    }

    public async Task DeleteFoodAsync(Food food)
    {
        _context.Remove(food);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Food>> GetFoodsAsync() => await _context.Foods.ToListAsync();

    public async Task<Food> GetFoodAsync(int id) => await _context.Foods.FindAsync(id);

    public async Task<bool> UpdateFoodAsync(Food food)
    {
        try
        {
            _context.Foods.Update(food);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await FoodExists(food.Id))
                return false;
            else
                throw;
        }
    }

    public async Task DeleteFoodAsync(int id)
    {
        _context.Remove(await GetFoodAsync(id));
        await _context.SaveChangesAsync();
    }

    public async Task<bool> FoodExists(int id) => await _context.Foods.AnyAsync(e => e.Id == id);
}
