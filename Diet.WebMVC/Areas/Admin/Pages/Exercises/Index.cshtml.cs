namespace Diet.WebMVC.Areas.Admin.Pages.Exercises;

public class ExerciseIndex : PageModel
{
    private readonly IGenericRepository<Exercise> _repository;

    public ExerciseIndex(IGenericRepository<Exercise> repository)
    {
        _repository = repository;
    }

    public IEnumerable<Exercise> Exercises { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Exercises = await _repository.GetAllAsync();
    }
}
