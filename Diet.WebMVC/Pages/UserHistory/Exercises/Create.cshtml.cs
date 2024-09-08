namespace Diet.WebMVC.Pages.UserHistory.Exercises;

public class CreateExerciseItemModel : PageModel
{
    private readonly IGenericRepository<HistoryExerciseItem> _repository;
    private readonly IGenericRepository<Exercise> _exerciseRepository;
    private readonly IMapper _mapper;

    public CreateExerciseItemModel(IGenericRepository<HistoryExerciseItem> repository, IGenericRepository<Exercise> exerciseRepository, IMapper mapper)
    {
        _repository = repository;
        _exerciseRepository = exerciseRepository;
        _mapper = mapper;
    }

    public List<SelectListItem> ExerciseDropdownItems { get; set; }

    [BindProperty]
    public ExerciseItemViewModel ExerciseItem { get; set; } = default!;

    public async Task<IActionResult> OnGet()
    {
        ExerciseDropdownItems = await _exerciseRepository.Queryable().Select(f => new SelectListItem
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

        var item = _mapper.Map<HistoryExerciseItem>(ExerciseItem);
        item.HistoryId = int.Parse(User.FindFirst("HistoryId")?.Value);
        var his = User.FindFirst("HistoryId")?.Value;

        await _repository.AddAsync(item);

        return RedirectToPage("../Index");
    }
}
