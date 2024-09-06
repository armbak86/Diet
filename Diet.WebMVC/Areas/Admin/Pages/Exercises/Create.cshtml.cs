namespace Diet.WebMVC.Areas.Admin.Pages.Exercises;

public class CreateExerciseModel : PageModel
{
    private readonly IGenericRepository<Exercise> _repository;
    private readonly IMapper _mapper;

    public CreateExerciseModel(IGenericRepository<Exercise> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public ExerciseViewModel Exercise { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();
        

        await _repository.AddAsync(_mapper.Map<Exercise>(Exercise));

        return RedirectToPage("./Index");
    }
}
