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
            // TODO: Use AutoMapper

            var user = new AppUser { UserName = UserViewModel.Email, Email = UserViewModel.Email, Age = UserViewModel.Age, Weight = UserViewModel.Weight, Hight = UserViewModel.Hight };
            var result = await _userManager.CreateAsync(user, UserViewModel.Password);
            if (result.Succeeded)
            {
                var history = await _historyRepository.AddAsync(new History() { AppUserId = user.Id });

                var userClaims = await _userManager.GetClaimsAsync(user);
                if (!userClaims.Any(c => c.Type == "HistoryId"))
                {
                    await _userManager.AddClaimAsync(user, new Claim("HistoryId", history.Id.ToString()));

                    // Re-sign the user to refresh the claims
                    await _signInManager.SignInAsync(user, isPersistent: false);
                }

                await _userManager.UpdateAsync(user);
                await _signInManager.SignInAsync(user, isPersistent: false);
                return LocalRedirect(returnUrl ?? "/Index");
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
