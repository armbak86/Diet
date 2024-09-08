namespace Diet.WebMVC.Pages.UserHistory.Foods;

public class CreateFoodItemModel : PageModel
{
    private readonly IGenericRepository<HistoryFoodItem> _repository;
    private readonly IGenericRepository<Food> _foodRepository;
    private readonly IMapper _mapper;

    public CreateFoodItemModel(IGenericRepository<HistoryFoodItem> repository, IGenericRepository<Food> foodRepository, IMapper mapper)
    {
        _repository = repository;
        _foodRepository = foodRepository;
        _mapper = mapper;
    }

    public List<SelectListItem> FoodDropdownItems { get; set; }

    [BindProperty]
    public FoodItemViewModel FoodItem { get; set; } = default!;

    public async Task<IActionResult> OnGet()
    {
        FoodDropdownItems = await _foodRepository.Queryable().Select(f => new SelectListItem
        {
            Value = f.Id.ToString(),
            Text = f.Name
        }).ToListAsync();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var item = _mapper.Map<HistoryFoodItem>(FoodItem);
        item.HistoryId = int.Parse(User.FindFirst("HistoryId")?.Value);
        var his = User.FindFirst("HistoryId")?.Value;

        await _repository.AddAsync(item);

        return RedirectToPage("../Index");
    }
}
