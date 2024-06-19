namespace Diet.WebMVC.Repositories.Interfaces;

public interface IExerciseRepository
{
    Task<IEnumerable<Exercise>> GetExercisesAsync();
    Task<Exercise> GetExerciseAsync(int id);
    Task<Exercise> CreateExerciseAsync(Exercise exercise);
    Task UpdateExerciseAsync(Exercise exercise);
    Task DeleteExerciseAsync(Exercise exercise);
    Task DeleteExerciseAsync(int id);
}