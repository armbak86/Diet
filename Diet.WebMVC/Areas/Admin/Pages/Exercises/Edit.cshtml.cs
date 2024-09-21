namespace Diet.WebMVC.Areas.Admin.Pages.Exercises;

[Authorize(Roles = "Admin")]
public class EditExerciseModel : PageModel
{
    private readonly IGenericRepository<Exercise> _repository;
    private readonly IMapper _mapper;

    public EditExerciseModel(IGenericRepository<Exercise> repository, IMapper mapper)
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


        var exercise = await _repository.GetByIdAsync((int)id);
        if (exercise == null)
            return NotFound();

        Exercise = _mapper.Map<ExerciseViewModel>(exercise);
        return Page();
    }


    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        await _repository.UpdateAsync(_mapper.Map<Exercise>(Exercise));

        return RedirectToPage("./Index");
    }
}
