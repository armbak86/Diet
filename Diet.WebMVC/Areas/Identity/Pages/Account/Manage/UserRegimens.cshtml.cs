namespace Diet.WebMVC.Areas.Identity.Pages.Account.Manage;

public class UserRegimensModel : PageModel
{
    private readonly IGenericRepository<Regimen> _repository;

    public UserRegimensModel(IGenericRepository<Regimen> repository)
    {
        _repository = repository;
    }

    public IEnumerable<Regimen> UserRegimens { get; set; } = default!;

    public async Task OnGetAsync()
    {
        UserRegimens = await _repository.Queryable().Where(r => r.AppUserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToListAsync();
    }
}
