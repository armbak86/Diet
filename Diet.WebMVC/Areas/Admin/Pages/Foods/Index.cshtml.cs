namespace Diet.WebMVC.Areas.Admin.Pages.Foods;

[Authorize(Roles = "Admin")]
public class FoodIndex : PageModel
{
    private readonly IGenericRepository<Food> _repository;

    public FoodIndex(IGenericRepository<Food> repository)
    {
        _repository = repository;
    }

    public IEnumerable<Food> Foods { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Foods = await _repository.GetAllAsync();
    }
}
