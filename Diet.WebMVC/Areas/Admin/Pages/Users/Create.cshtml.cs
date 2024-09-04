//namespace Diet.WebMVC.Areas.Admin.Pages.Users;

//public class CreateAppUserModel : PageModel
//{
//    private readonly UserManager<AppUser> _userManager;
//    private readonly IMapper _mapper;

//    public CreateAppUserModel(UserManager<AppUser> userManager, IMapper mapper)
//    {
//        _userManager = userManager;
//        _mapper = mapper;
//    }

//    public IActionResult OnGet()
//    {
//        return Page();
//    }

//    [BindProperty]
//    public AppUserViewModel AppUser { get; set; } = default!;

//    public async Task<IActionResult> OnPostAsync()
//    {
//        if (!ModelState.IsValid)
//            return Page();


//        await _repository.CreateAppUserAsync(_mapper.Map<AppUser>(AppUser));

//        return RedirectToPage("./Index");
//    }
//}
