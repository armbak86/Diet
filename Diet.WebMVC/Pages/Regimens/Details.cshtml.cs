namespace Diet.WebMVC.Pages.Regimens;

[Authorize]
public class DetailsModel : PageModel
{
    private readonly IGenericRepository<Regimen> _repository;


    public DetailsModel(IGenericRepository<Regimen> repository)
    {
        _repository = repository;
    }

    [BindProperty]
    public Regimen Regimen { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
            return NotFound();

        Regimen = await _repository.GetByIdAsync((int)id);

        if (Regimen == null)
            return NotFound();

        return Page();
    }
}
