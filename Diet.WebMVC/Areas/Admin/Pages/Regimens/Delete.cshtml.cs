namespace Diet.WebMVC.Areas.Admin.Pages.Regimens;

public class DeleteRegimenModel : PageModel
{
    private readonly IGenericRepository<Regimen> _repository;

    public DeleteRegimenModel(IGenericRepository<Regimen> repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
            return NotFound();

        var regimen = await _repository.GetByIdAsync((int)id);

        if (regimen != null)
            await _repository.RemoveAsync(regimen);
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
