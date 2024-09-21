namespace Diet.WebMVC.Areas.Admin.Pages.Regimens;

[Authorize(Roles = "Admin")]
public class DeleteRegimenModel : PageModel
{
    private readonly IGenericRepository<Regimen> _repository;
    private readonly IFileService _fileService;

    public DeleteRegimenModel(IGenericRepository<Regimen> repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
            return NotFound();

        var regimen = await _repository.GetByIdAsync((int)id);

        if (regimen != null)
        {
            _fileService.DeleteFile(_fileService.GetRootPath("images"), regimen.Image);
            _fileService.DeleteFile(_fileService.GetRootPath("files"), regimen.File);
            await _repository.RemoveAsync(regimen);
        }
        else
            return NotFound();

        return RedirectToPage("./Index");
    }
}
