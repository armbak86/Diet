namespace Diet.WebMVC.Areas.Admin.Pages.Foods;

[Authorize(Roles = "Admin")]
public class EditFoodModel : PageModel
{
    private readonly IGenericRepository<Food> _repository;
    private readonly IMapper _mapper;

    public EditFoodModel(IGenericRepository<Food> repository, IMapper mapper)
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


        var food = await _repository.GetByIdAsync((int)id);
        if (food == null)
            return NotFound();

        Food = _mapper.Map<FoodViewModel>(food);
        return Page();
    }


    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        await _repository.UpdateAsync(_mapper.Map<Food>(Food));

        return RedirectToPage("./Index");
    }
}
