using Microsoft.AspNetCore.Identity;

namespace Diet.WebMVC.Areas.Admin.Pages.Users;

[Authorize(Roles = "Admin")]
public class MakeAdminModel : PageModel
{
    private readonly UserManager<AppUser> _userManager;

    public MakeAdminModel(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> OnGetAsync(string? id)
    {
        if (id == null)
            return NotFound();

        var user = await _userManager.FindByIdAsync(id);

        if (user != null)
            await _userManager.AddToRoleAsync(user, "Admin");
        else
            return NotFound();

        return RedirectToPage("./Index");
    }
}
