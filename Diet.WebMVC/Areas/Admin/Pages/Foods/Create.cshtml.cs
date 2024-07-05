namespace Diet.WebMVC.Areas.Admin.Pages.Foods;

public class CreateModel : PageModel
{
    private readonly IFoodRepository _repository;
    private readonly IMapper _mapper;

    public CreateModel(IFoodRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

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
        

        await _repository.CreateFoodAsync(_mapper.Map<Food>(Food));

        return RedirectToPage("./Index");
    }
}
