namespace Diet.WebMVC.Areas.Identity.Pages.Account.Manage;

public partial class IndexModel : PageModel
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IMapper _mapper;

    public IndexModel(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
    }

    [TempData]
    public string StatusMessage { get; set; }

    [BindProperty]
    public ChangeUserViewModel UserViewModel { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
            return NotFound();

        UserViewModel = _mapper.Map<ChangeUserViewModel>(user);

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
            return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");

        if (!ModelState.IsValid)
        {
            UserViewModel = _mapper.Map<ChangeUserViewModel>(user);
            return Page();
        }

        user.Weight = UserViewModel.Weight;
        user.Age = UserViewModel.Age;
        user.Hight = UserViewModel.Hight;

        await _userManager.UpdateAsync(user);

        await _signInManager.RefreshSignInAsync(user);
        StatusMessage = "تغییرات با موفقیت اعمال شد";
        return RedirectToPage();

    }
}
