namespace Diet.WebMVC.Areas.Identity.Pages.Account;

[AllowAnonymous]
public class LogoutModel : PageModel
{
    private readonly SignInManager<AppUser> _signInManager;

    public LogoutModel(SignInManager<AppUser> signInManager, ILogger<LogoutModel> logger)
    {
        _signInManager = signInManager;
    }

    public async Task<IActionResult> OnGet()
    {
        if (_signInManager.IsSignedIn(User))
            await _signInManager.SignOutAsync();

        return RedirectToPage("./Login");
    }
}
