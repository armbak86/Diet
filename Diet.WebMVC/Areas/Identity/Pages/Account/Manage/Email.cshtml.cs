namespace Diet.WebMVC.Areas.Identity.Pages.Account.Manage;

public class EmailModel : PageModel
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public EmailModel(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public string Username { get; set; }

    public string Email { get; set; }


    [TempData]
    public string StatusMessage { get; set; }

    [BindProperty]
    public ChangeEmailViewModel ViewModel { get; set; }

    private async Task LoadAsync(AppUser user)
    {
        Email = await _userManager.GetEmailAsync(user);
        
        ViewModel = new ChangeEmailViewModel { NewEmail = Email };
    }

    public async Task<IActionResult> OnGetAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        
        if (user == null)
            return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");

        await LoadAsync(user);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        }

        if (!ModelState.IsValid)
        {
            await LoadAsync(user);
            return Page();
        }

        var email = await _userManager.GetEmailAsync(user);
        if (ViewModel.NewEmail != email)
        {
            var userId = await _userManager.GetUserIdAsync(user);
            await _userManager.SetEmailAsync(user,ViewModel.NewEmail);
            StatusMessage = "ایمیل با موفقیت تغییر یافت";
            return RedirectToPage();
        }

        return RedirectToPage();
    }
}
