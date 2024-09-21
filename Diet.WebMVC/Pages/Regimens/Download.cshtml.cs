namespace Diet.WebMVC.Pages.Regimens;

[Authorize]
public class DownloadModel : PageModel
{
    private readonly IGenericRepository<Regimen> _repository;
    private readonly IFileService _fileService;

    public DownloadModel(IGenericRepository<Regimen> repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var regimen = await _repository.GetByIdAsync(id);

        // Check if the file exists
        if (regimen == null)
        {
            return NotFound(); // Return 404 if the file does not exist
        }

        // Return the file for download
        var fileBytes = System.IO.File.ReadAllBytes(Path.Combine(_fileService.GetRootPath("files"),regimen.File));
        var contentType = "application/octet-stream";
        return File(fileBytes, contentType, regimen.File);
    }
}
