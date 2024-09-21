namespace Diet.WebMVC.Areas.Admin.Pages.Foods;

[Authorize(Roles = "Admin")]
public class CreateFoodModel : PageModel
{
    private readonly IGenericRepository<Food> _repository;
    private readonly IMapper _mapper;

    public CreateFoodModel(IGenericRepository<Food> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    // BUG: OnGet not being invoked
    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public FoodViewModel Food { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();
        

        await _repository.AddAsync(_mapper.Map<Food>(Food));

        return RedirectToPage("./Index");
    }
}
