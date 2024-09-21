namespace Diet.WebMVC.Areas.Admin.Pages.Foods;

[Authorize(Roles = "Admin")]
public class DeleteFoodModel : PageModel
{
    private readonly IGenericRepository<Food> _repository;

    public DeleteFoodModel(IGenericRepository<Food> repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
            return NotFound();

        var food = await _repository.GetByIdAsync((int)id);

        if (food != null)
            await _repository.UpdateAsync(food);
        else
            return NotFound();

        return RedirectToPage("./Index");
    }
}
