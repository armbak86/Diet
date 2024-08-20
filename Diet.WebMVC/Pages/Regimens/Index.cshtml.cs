using Diet.WebMVC.Services;
namespace Diet.WebMVC.Pages.Regimens;

public class IndexModel : PageModel
{
    private readonly IRegimenRepository _repository;
    private readonly IPaginationService<Regimen> _paginationService;

    public IndexModel(IRegimenRepository repository, IPaginationService<Regimen> paginationService)
    {
        _repository = repository;
        _paginationService = paginationService;
    }

    [BindProperty(SupportsGet = true)]
    public int? CurrentPage { get; set; } 
    public PaginatedResult<Regimen> Regimens { get;set; }

    public async Task OnGetAsync() => Regimens = _paginationService.GetPaginatedList(await _repository.GetRegimensAsync(),CurrentPage ?? 1,6);
}
