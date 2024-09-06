namespace Diet.WebMVC.Areas.Admin.Pages.Regimens;

public class CreateRegimenModel : PageModel
{
    private readonly IGenericRepository<Regimen> _repository;
    private readonly IMapper _mapper;

    public CreateRegimenModel(IGenericRepository<Regimen> repository, IMapper mapper)
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
        

        await _repository.AddAsync(_mapper.Map<Regimen>(Regimen));

        return RedirectToPage("./Index");
    }
}
