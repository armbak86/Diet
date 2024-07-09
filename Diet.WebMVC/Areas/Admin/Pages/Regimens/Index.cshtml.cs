namespace Diet.WebMVC.Areas.Admin.Pages.Regimens;

public class RegimenIndex : PageModel
{
    private readonly IRegimenRepository _repository;

    public RegimenIndex(IRegimenRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Regimen> Regimens { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Regimens = await _repository.GetRegimensAsync();
    }
}
