namespace Diet.WebMVC.Areas.Identity.Pages.Account;

[AllowAnonymous]
public class RegisterModel : PageModel
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly IHistoryRepository _historyRepository;

    public RegisterModel(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        IHistoryRepository historyRepository)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _historyRepository = historyRepository;
    }

    [BindProperty]
    public UserRegisterViewModel UserViewModel { get; set; }

    public string ReturnUrl { get; set; }

    public IActionResult OnGetAsync(string returnUrl = null)
    {
        ReturnUrl = returnUrl ??= Url.Content("~/");

        if (_signInManager.IsSignedIn(User))
            return LocalRedirect(returnUrl);


        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string returnUrl = null)
    {
        if (ModelState.IsValid)
        {
            var user = new AppUser { UserName = UserViewModel.Email, Email = UserViewModel.Email };
            var result = await _userManager.CreateAsync(user, UserViewModel.Password);
            if (result.Succeeded)
            {
                await _historyRepository.CreateHistoryAsync(new History() { AppUserId = user.Id });

                await _userManager.UpdateAsync(user);
                await _signInManager.SignInAsync(user,isPersistent: false);
                return LocalRedirect(returnUrl);
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        // If we got this far, something failed, redisplay form
        return Page();
    }
}
