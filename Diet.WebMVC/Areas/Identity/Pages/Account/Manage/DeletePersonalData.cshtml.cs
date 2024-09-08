namespace Diet.WebMVC.Areas.Identity.Pages.Account.Manage;

public class DeletePersonalDataModel : PageModel
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IGenericRepository<History> _historyRepository;

    public DeletePersonalDataModel(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IGenericRepository<History> historyRepository)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _historyRepository = historyRepository;
    }

    [BindProperty]
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }


    public async Task<IActionResult> OnGet()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        }


        if (!await _userManager.CheckPasswordAsync(user, Password))
        {
            ModelState.AddModelError(string.Empty, "رمز عبور اشتباه است");
            return Page();
        }


        await _historyRepository.RemoveAsync(int.Parse(User.FindFirstValue("HistoryId")));
        var result = await _userManager.DeleteAsync(user);
        var userId = await _userManager.GetUserIdAsync(user);
        if (!result.Succeeded)
        {
            throw new InvalidOperationException($"Unexpected error occurred deleting user with ID '{userId}'.");
        }

        await _signInManager.SignOutAsync();

        return Redirect("~/");
    }
}
