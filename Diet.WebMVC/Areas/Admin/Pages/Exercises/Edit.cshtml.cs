namespace Diet.WebMVC.Areas.Admin.Pages.Exercises;

public class EditExerciseModel : PageModel
{
    private readonly IExerciseRepository _repository;
    private readonly IMapper _mapper;

    public EditExerciseModel(IExerciseRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [BindProperty]
    public ExerciseViewModel Exercise { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
            return NotFound();


        var exercise = await _repository.GetExerciseAsync((int)id);
        if (exercise == null)
            return NotFound();

        Exercise = _mapper.Map<ExerciseViewModel>(exercise);
        return Page();
    }


    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        await _repository.UpdateExerciseAsync(_mapper.Map<Exercise>(Exercise));

        return RedirectToPage("./Index");
    }
}
