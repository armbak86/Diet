namespace Diet.WebMVC.Areas.Admin.Pages.Users;

[Authorize(Roles = "Admin")]
public class DeleteAppUserModel : PageModel
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IHistoryRepository _historyRepository;

    public DeleteAppUserModel(UserManager<AppUser> userManager, IHistoryRepository historyRepository)
    {
        _userManager = userManager;
        _historyRepository = historyRepository;
    }

    public async Task<IActionResult> OnGetAsync(string? id)
    {
        if (id == null)
            return NotFound();

        // TODO: Refactor code to have foreign kes instead of this nasty way 
        var user = await _userManager.Users.Include(u => u.History).Where(u=>u.Id== id).FirstOrDefaultAsync();

        if (user != null)
        {
            await _historyRepository.RemoveAsync(await _historyRepository.GetByIdAsync(user.History.Id));
            await _userManager.DeleteAsync(user);
        }
        else
            return NotFound();

        return RedirectToPage("./Index");
    }
}
