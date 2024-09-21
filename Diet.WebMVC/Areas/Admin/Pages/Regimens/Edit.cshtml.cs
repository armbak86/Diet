namespace Diet.WebMVC.Areas.Admin.Pages.Regimens;

[Authorize(Roles = "Admin")]
public class EditRegimenModel : PageModel
{
    private readonly IGenericRepository<Regimen> _repository;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;

    public EditRegimenModel(IGenericRepository<Regimen> repository, IMapper mapper, IFileService fileService)
    {
        _repository = repository;
        _mapper = mapper;
        _fileService = fileService;
    }

    [BindProperty]
    public UpdateRegimenViewModel Regimen { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
            return NotFound();


        var regimen = await _repository.GetByIdAsync((int)id);
        if (regimen == null)
            return NotFound();

        Regimen = _mapper.Map<UpdateRegimenViewModel>(regimen);
        return Page();
    }


    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        if(Regimen.ImageFormFile != null)
        {
            var imagesPath = _fileService.GetRootPath("images");
            _fileService.DeleteFile(imagesPath,Regimen.Image);
            Regimen.Image = Regimen.ImageFormFile.FileName;
            await _fileService.CreateFileAsync(Regimen.ImageFormFile,imagesPath,Regimen.Image);
        }

        if (Regimen.FileFormFile != null)
        {
            var filesPath = _fileService.GetRootPath("files");
            _fileService.DeleteFile(filesPath, Regimen.File);
            Regimen.File = Regimen.FileFormFile.FileName;
            await _fileService.CreateFileAsync(Regimen.ImageFormFile, filesPath, Regimen.File);
        }

        await _repository.UpdateAsync(_mapper.Map<Regimen>(Regimen));

        return RedirectToPage("./Index");
    }
}
