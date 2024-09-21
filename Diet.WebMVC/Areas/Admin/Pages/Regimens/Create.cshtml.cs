namespace Diet.WebMVC.Areas.Admin.Pages.Regimens;

[Authorize(Roles = "Admin")]
public class CreateRegimenModel : PageModel
{
    private readonly IGenericRepository<Regimen> _repository;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;

    public CreateRegimenModel(IGenericRepository<Regimen> repository, IMapper mapper, IFileService fileService)
    {
        _repository = repository;
        _mapper = mapper;
        _fileService = fileService;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public RegimenViewModel Regimen { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        // TODO: See how to pass image from automapper
        var regimen = _mapper.Map<Regimen>(Regimen);
        regimen.Image = Regimen.Image.FileName;

        await _fileService.CreateFileAsync(Regimen.Image,_fileService.GetRootPath("images"), Regimen.Image.FileName);

        await _repository.AddAsync(regimen);

        return RedirectToPage("./Index");
    }
}
