namespace Diet.WebMVC.Pages.UserHistory;

public class EditHistoryModel : PageModel
{
    private readonly IHistoryRepository _repository;
    private readonly IMapper _mapper;

    public EditHistoryModel(IHistoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [BindProperty]
    public HistoryViewModel History { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
            return NotFound();


        var History = await _repository.GetHistoryAsync((int)id);
        if (History == null)
            return NotFound();

        History = _mapper.Map<HistoryViewModel>(History);
        return Page();
    }


    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        await _repository.UpdateHistoryAsync(_mapper.Map<History>(History));

        return RedirectToPage("./Index");
    }
}
