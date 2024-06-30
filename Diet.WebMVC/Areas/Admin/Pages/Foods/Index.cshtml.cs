namespace Diet.WebMVC.Areas.Admin.Pages.Foods;

public class Index : PageModel
{
    private readonly IFoodRepository _repository;

    public Index(IFoodRepository repostiory)
    {
        _repository = repostiory;
    }

    public IEnumerable<Food> Foods { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Foods = await _repository.GetFoodsAsync();
    }
}
