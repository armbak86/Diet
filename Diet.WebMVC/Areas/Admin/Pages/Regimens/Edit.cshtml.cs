namespace Diet.WebMVC.Areas.Admin.Pages.Regimens;

public class EditRegimenModel : PageModel
{
    private readonly IGenericRepository<Regimen> _repository;
    private readonly IMapper _mapper;

    public EditRegimenModel(IGenericRepository<Regimen> repository, IMapper mapper)
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


        var regimen = await _repository.GetByIdAsync((int)id);
        if (regimen == null)
            return NotFound();

        Regimen = _mapper.Map<RegimenViewModel>(regimen);
        return Page();
    }


    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        await _repository.UpdateAsync(_mapper.Map<Regimen>(Regimen));

        return RedirectToPage("./Index");
    }
}
