namespace Diet.WebMVC.Pages.UserHistory.Foods;

public class EditFoodItemModel : PageModel
{
    private readonly IGenericRepository<HistoryFoodItem> _repository;
    private readonly IGenericRepository<Food> _foodRepository;
    private readonly IMapper _mapper;

    public EditFoodItemModel(IGenericRepository<HistoryFoodItem> repository, IGenericRepository<Food> foodRepository, IMapper mapper)
    {
        _repository = repository;
        _foodRepository = foodRepository;
        _mapper = mapper;
    }

    public List<SelectListItem> FoodDropdownItems { get; set; }

    [BindProperty]
    public FoodItemViewModel FoodItem { get; set; } = default!;

    public async Task<IActionResult> OnGet(int id)
    {
        var item = await _repository.GetByIdAsync(id);
        if (item == null)
            return NotFound();

        FoodDropdownItems = await _foodRepository.Queryable().Select(f => new SelectListItem
        {
            Value = f.Id.ToString(),
            Text = f.Name,
            Selected = item.FoodId == f.Id,
        }).ToListAsync();

        FoodItem = _mapper.Map<FoodItemViewModel>(item);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var item = _mapper.Map<HistoryFoodItem>(FoodItem);
        item.HistoryId = int.Parse(User.FindFirst("HistoryId")?.Value);
        var his = User.FindFirst("HistoryId")?.Value;

        await _repository.UpdateAsync(item);

        return RedirectToPage("../Index");
    }
}
