namespace Diet.WebMVC.Areas.Admin.Pages.Regimens;

public class DeleteRegimenModel : PageModel
{
    private readonly IRegimenRepository _repository;

    public DeleteRegimenModel(IRegimenRepository repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
            return NotFound();

        var regimen = await _repository.GetRegimenAsync((int)id);

        if (regimen != null)
            await _repository.DeleteRegimenAsync(regimen);
        else
            return NotFound();

        return RedirectToPage("./Index");
    }

    //public async Task<IActionResult> OnPostAsync(int? id)
    //{
    //    if (id == null)
    //    {
    //        return NotFound();
    //    }

    //    var regimen = await _repository.GetRegimenAsync((int)id);
    //    if (regimen != null)
    //    {
    //        Regimen = regimen;
    //        _repository.Regimens.Remove(Regimen);
    //        await _repository.SaveChangesAsync();
    //    }

    //    return RedirectToPage("./IndexModel");
    //}
}
