namespace Diet.WebMVC.Areas.Admin.Pages.Exercises;

public class DeleteExerciseModel : PageModel
{
    private readonly IGenericRepository<Exercise> _repository;

    public DeleteExerciseModel(IGenericRepository<Exercise> repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
            return NotFound();

        var exercise = await _repository.GetByIdAsync((int)id);

        if (exercise != null)
            await _repository.RemoveAsync(exercise);
        else
            return NotFound();

        return RedirectToPage("./Index");
    }
}
