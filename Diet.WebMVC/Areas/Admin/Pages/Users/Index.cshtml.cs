namespace Diet.WebMVC.Areas.Admin.Pages.Users;

[Authorize(Roles = "Admin")]
public class AppUserIndex : PageModel
{
    private readonly UserManager<AppUser> _userManager;

    public AppUserIndex(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public IEnumerable<AppUser> AppUsers { get; set; } = default!;

    public void OnGetAsync() => AppUsers = _userManager.Users;
}
