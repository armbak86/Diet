namespace Diet.WebMVC.Areas.Admin.Pages.Foods;

public class DeleteFoodModel : PageModel
{
    private readonly IFoodRepository _repository;

    public DeleteFoodModel(IFoodRepository repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
            return NotFound();

        var food = await _repository.GetFoodAsync((int)id);

        if (food != null)
            await _repository.DeleteFoodAsync(food);
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

    //    var food = await _repository.GetFoodAsync((int)id);
    //    if (food != null)
    //    {
    //        Food = food;
    //        _repository.Foods.Remove(Food);
    //        await _repository.SaveChangesAsync();
    //    }

    //    return RedirectToPage("./IndexModel");
    //}
}
