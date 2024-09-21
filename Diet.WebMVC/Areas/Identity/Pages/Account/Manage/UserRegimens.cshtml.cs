namespace Diet.WebMVC.Areas.Identity.Pages.Account.Manage;

public class UserRegimensModel : PageModel
{
    private readonly UserManager<AppUser> _userManager;

    public UserRegimensModel(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public IEnumerable<Regimen> UserRegimens { get; set; } = default!;

    public async Task OnGetAsync()
    {
        UserRegimens = await _userManager.Users.Include(r => r.Regimens).Where(u => u.Id == _userManager.GetUserId(User)).Select(u => u.Regimens).FirstOrDefaultAsync();
    }
}
