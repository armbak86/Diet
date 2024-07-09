namespace Diet.WebMVC.Areas.Admin.Pages.Exercises;

public class ExerciseIndex : PageModel
{
    private readonly IExerciseRepository _repository;

    public ExerciseIndex(IExerciseRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Exercise> Exercises { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Exercises = await _repository.GetExercisesAsync();
    }
}
