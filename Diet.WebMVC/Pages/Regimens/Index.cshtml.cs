using Diet.WebMVC.Services;
namespace Diet.WebMVC.Pages.Regimens;

public class IndexModel : PageModel
{
    private readonly IGenericRepository<Regimen> _repository;
    private readonly IPaginationService<Regimen> _paginationService;

    public IndexModel(IGenericRepository<Regimen> repository, IPaginationService<Regimen> paginationService)
    {
        _repository = repository;
        _paginationService = paginationService;
    }

    [BindProperty(SupportsGet = true)]
    public int? CurrentPage { get; set; } 
    public PaginatedResult<Regimen> Regimens { get;set; }

    public async Task OnGetAsync() => Regimens = _paginationService.GetPaginatedList(await _repository.GetAllAsync(),CurrentPage ?? 1,6);
}
