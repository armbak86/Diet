namespace Diet.WebMVC.Areas.Admin.Pages.Foods;

public class CreateModel : PageModel
{
    private readonly IFoodRepository _repository;

    public CreateModel(IFoodRepository repository)
    {
        _repository = repository;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Food Food { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();
        

        await _repository.CreateFoodAsync(Food);

        return RedirectToPage("./Index");
    }
}
