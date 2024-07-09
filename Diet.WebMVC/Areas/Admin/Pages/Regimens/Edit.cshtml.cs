namespace Diet.WebMVC.Areas.Admin.Pages.Regimens;

public class EditRegimenModel : PageModel
{
    private readonly IRegimenRepository _repository;
    private readonly IMapper _mapper;

    public EditRegimenModel(IRegimenRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [BindProperty]
    public RegimenViewModel Regimen { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
            return NotFound();


        var regimen = await _repository.GetRegimenAsync((int)id);
        if (regimen == null)
            return NotFound();

        Regimen = _mapper.Map<RegimenViewModel>(regimen);
        return Page();
    }


    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        await _repository.UpdateRegimenAsync(_mapper.Map<Regimen>(Regimen));

        return RedirectToPage("./Index");
    }
}
