namespace Diet.WebMVC.Areas.Identity.Pages.Account;

[AllowAnonymous]
public class LoginModel : PageModel
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public LoginModel(SignInManager<AppUser> signInManager,
        UserManager<AppUser> userManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [BindProperty]
    public UserLoginViewModel UserViewModel { get; set; }


    public string ReturnUrl { get; set; }

    [TempData]
    public string ErrorMessage { get; set; }

    public IActionResult OnGetAsync(string returnUrl = null)
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
        //TODO: Remove Email Varification 
        returnUrl ??= Url.Content("~/");

        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(UserViewModel.Email, UserViewModel.Password, UserViewModel.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
                return LocalRedirect(returnUrl);
            else
            {
                ModelState.AddModelError(string.Empty, "اطلاعات وارد شده صحیح نمی باشد");
                return Page();
            }
        }

        // If we got this far, something failed, redisplay form
        return Page();
    }
}
