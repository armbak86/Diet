namespace Diet.WebMVC.Areas.Admin.Pages.Regimens;

public class CreateRegimenModel : PageModel
{
    private readonly IRegimenRepository _repository;
    private readonly IMapper _mapper;

    public CreateRegimenModel(IRegimenRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public RegimenViewModel Regimen { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();
        

        await _repository.CreateRegimenAsync(_mapper.Map<Regimen>(Regimen));

        return RedirectToPage("./Index");
    }
}
