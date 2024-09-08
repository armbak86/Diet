namespace Diet.WebMVC.Areas.Identity.Pages.Account;

[AllowAnonymous]
public class LoginModel : PageModel
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IHistoryRepository _historyRepository;
    public LoginModel(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IHistoryRepository historyRepository)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _historyRepository = historyRepository;
    }

    [BindProperty]
    public UserLoginViewModel UserViewModel { get; set; }


    public string ReturnUrl { get; set; }

    [TempData]
    public string ErrorMessage { get; set; }

    public IActionResult OnGetAsync(string? returnUrl = null)
    {
        returnUrl ??= Url.Content("~/");

        if (_signInManager.IsSignedIn(User))
            return LocalRedirect(returnUrl);

        if (!string.IsNullOrEmpty(ErrorMessage))
        {
            ModelState.AddModelError(string.Empty, ErrorMessage);
        }

        ReturnUrl = returnUrl;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string returnUrl = null)
    {
        returnUrl ??= Url.Content("~/");

        if (!ModelState.IsValid)
            return Page();

        var result = await _signInManager.PasswordSignInAsync(UserViewModel.Email, UserViewModel.Password, UserViewModel.RememberMe, lockoutOnFailure: false);
        if (!result.Succeeded)
        {
            ModelState.AddModelError(string.Empty, "اطلاعات وارد شده صحیح نمی باشد");
            return Page();
        }

        var user = await _userManager.FindByEmailAsync(UserViewModel.Email);
        if (user == null)
            return Page(); // Handle if user is unexpectedly null

        // Check if the HistoryId claim already exists
        var userClaims = await _userManager.GetClaimsAsync(user);
        if (!userClaims.Any(c => c.Type == "HistoryId"))
        {
            var historyId = await _historyRepository.GetHistoryIdAsync(user.Id);
            await _userManager.AddClaimAsync(user, new Claim("HistoryId", historyId.ToString()));

            // Re-sign the user to refresh the claims
            await _signInManager.SignInAsync(user, isPersistent: false);
        }

        return LocalRedirect(returnUrl);
    }

}
