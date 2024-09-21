namespace Diet.WebMVC.Areas.Admin.Pages;

[Authorize(Roles = "Admin")]
public class IndexModel : PageModel
{

    public IActionResult OnGetAsync()
    {
        return RedirectToPage("./Foods/Index");
    }
}
