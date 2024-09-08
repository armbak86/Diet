namespace Diet.WebMVC.Pages.UserHistory.Foods;
public class DeleteFoodItemModel : PageModel
{
    private readonly IGenericRepository<HistoryFoodItem> _repository;

    public DeleteFoodItemModel(IGenericRepository<HistoryFoodItem> repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
            return NotFound();

        var food = await _repository.GetByIdAsync((int)id);

        if (food != null)
            await _repository.RemoveAsync(food);
        else
            return NotFound();

        return RedirectToPage("../Index");
    }
}
