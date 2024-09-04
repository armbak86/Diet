//namespace Diet.WebMVC.Areas.Admin.Pages.Users;

//public class EditAppUserModel : PageModel
//{
//    private readonly IAppUserRepository _repository;
//    private readonly IMapper _mapper;

//    public EditAppUserModel(IAppUserRepository repository, IMapper mapper)
//    {
//        _repository = repository;
//        _mapper = mapper;
//    }

//    [BindProperty]
//    public AppUserViewModel AppUser { get; set; } = default!;

//    public async Task<IActionResult> OnGetAsync(int? id)
//    {
//        if (id == null)
//            return NotFound();


//        var user = await _repository.GetAppUserAsync((int)id);
//        if (user == null)
//            return NotFound();

//        AppUser = _mapper.Map<AppUserViewModel>(user);
//        return Page();
//    }


//    public async Task<IActionResult> OnPostAsync()
//    {
//        if (!ModelState.IsValid)
//            return Page();

//        await _repository.UpdateAppUserAsync(_mapper.Map<AppUser>(AppUser));

//        return RedirectToPage("./Index");
//    }
//}
