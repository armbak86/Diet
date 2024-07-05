namespace Diet.WebMVC.Areas.Admin.Pages.Foods;

public class FoodIndex : PageModel
{
    private readonly IFoodRepository _repository;

    public FoodIndex(IFoodRepository repostiory)
    {
        _repository = repostiory;
    }

    public IEnumerable<Food> Foods { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Foods = await _repository.GetFoodsAsync();
    }
}
