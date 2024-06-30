namespace Diet.WebMVC.Areas.Admin.Pages.Foods;

public class EditModel : PageModel
{
    private readonly IFoodRepository _repository;

    public EditModel(IFoodRepository repository)
    {
        _repository = repository;
    }

    [BindProperty]
    public Food Food { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
            return NotFound();


        var food = await _repository.GetFoodAsync((int)id);
        if (food == null)
            return NotFound();

        Food = food;
        return Page();
    }


    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        await _repository.UpdateFoodAsync(Food);

        return RedirectToPage("./Index");
    }
}
