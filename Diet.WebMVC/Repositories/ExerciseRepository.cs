namespace Diet.WebMVC.Repositories;

public class ExerciseRepository : IExerciseRepository
{
    private readonly AppDbContext _context;

    public ExerciseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Exercise> CreateExerciseAsync(Exercise exercise)
    {
        _context.Add(exercise);
        await _context.SaveChangesAsync();

        return exercise;
    }

    public async Task DeleteExerciseAsync(Exercise exercise)
    {
        _context.Remove(exercise);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Exercise>> GetExercisesAsync() => await _context.Exercises.ToListAsync();

    public async Task<Exercise> GetExerciseAsync(int id) => await _context.Exercises.FindAsync(id);

    public async Task UpdateExerciseAsync(Exercise exercise)
    {
        _context.Exercises.Update(exercise);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteExerciseAsync(int id)
    {
        _context.Remove(await GetExerciseAsync(id));
        _context.SaveChanges();
    }
}
