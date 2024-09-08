namespace Diet.WebMVC.Areas.Identity.Pages.Account.Manage;

public class ChangePasswordModel : PageModel
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ILogger<ChangePasswordModel> _logger;

    public ChangePasswordModel(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        ILogger<ChangePasswordModel> logger)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _logger = logger;
    }

    [BindProperty]
    public ChangePasswordViewModel ViewModel { get; set; }

    [TempData]
    public string StatusMessage { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
            return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var user = await _userManager.GetUserAsync(User);
        if (user == null)
            return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");

        var changePasswordResult = await _userManager.ChangePasswordAsync(user, ViewModel.OldPassword, ViewModel.NewPassword);
        if (!changePasswordResult.Succeeded)
        {
            foreach (var error in changePasswordResult.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return Page();
        }

        await _signInManager.RefreshSignInAsync(user);

        StatusMessage = "رمز عبور شما با موفقیت تغییر یافت";

        return RedirectToPage();
    }
}
