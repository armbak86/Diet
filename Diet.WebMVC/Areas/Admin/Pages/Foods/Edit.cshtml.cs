namespace Diet.WebMVC.Areas.Admin.Pages.Foods;

public class EditModel : PageModel
{
    private readonly IFoodRepository _repository;
    private readonly IMapper _mapper;

    public EditModel(IFoodRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [BindProperty]
    public FoodViewModel Food { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
            return NotFound();


        var food = await _repository.GetFoodAsync((int)id);
        if (food == null)
            return NotFound();

        Food = _mapper.Map<FoodViewModel>(food);
        return Page();
    }


    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        await _repository.UpdateFoodAsync(_mapper.Map<Food>(Food));

        return RedirectToPage("./Index");
    }
}
