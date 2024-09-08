namespace Diet.WebMVC.Pages.UserHistory.Exercises;
public class DeleteExerciseItemModel : PageModel
{
    private readonly IGenericRepository<HistoryExerciseItem> _repository;

    public DeleteExerciseItemModel(IGenericRepository<HistoryExerciseItem> repository)
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

        return RedirectToPage("../Index");
    }
}
