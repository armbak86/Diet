namespace Diet.WebMVC.Areas.Admin.Pages.Regimens;

[Authorize(Roles = "Admin")]
public class RegimenIndex : PageModel
{
    private readonly IGenericRepository<Regimen> _repository;

    public RegimenIndex(IGenericRepository<Regimen> repository)
    {
        _repository = repository;
    }

    public IEnumerable<Regimen> Regimens { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Regimens = await _repository.GetAllAsync();
    }
}
