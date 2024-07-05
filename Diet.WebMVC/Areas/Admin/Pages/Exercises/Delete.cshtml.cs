namespace Diet.WebMVC.Areas.Admin.Pages.Exercises;

public class DeleteExerciseModel : PageModel
{
    private readonly IExerciseRepository _repository;

    public DeleteExerciseModel(IExerciseRepository repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
            return NotFound();

        var exercise = await _repository.GetExerciseAsync((int)id);

        if (exercise != null)
            await _repository.DeleteExerciseAsync(exercise);
        else
            return NotFound();

        return RedirectToPage("./Index");
    }

    //public async Task<IActionResult> OnPostAsync(int? id)
    //{
    //    if (id == null)
    //    {
    //        return NotFound();
    //    }

    //    var exercise = await _repository.GetExerciseAsync((int)id);
    //    if (exercise != null)
    //    {
    //        Exercise = exercise;
    //        _repository.Exercises.Remove(Exercise);
    //        await _repository.SaveChangesAsync();
    //    }

    //    return RedirectToPage("./IndexModel");
    //}
}
