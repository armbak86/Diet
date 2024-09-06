namespace Diet.WebMVC.Pages.UserHistory;

[Authorize]
public class IndexModel : PageModel
{

    private readonly IHistoryRepository _historyRepository;
    private readonly IPaginationService<Regimen> _paginationService;
    private readonly UserManager<AppUser> _userManager;

    public IndexModel(IHistoryRepository historyRepository, IPaginationService<Regimen> paginationService, UserManager<AppUser> userManager)
    {
        _historyRepository = historyRepository;
        _paginationService = paginationService;
        _userManager = userManager;
    }

    public IEnumerable<HistoryFoodItem> FoodItemes { get;set; }
    public IEnumerable<HistoryExerciseItem> ExerciseItemes { get;set; }

    public async Task OnGetAsync()
    {
        //FoodItemes = await _foodRepository.GetHistoryFoodItemsAsync(await _historyRepository.GetHistoryIdAsync(_userManager.GetUserId(User)));
        FoodItemes = (await _historyRepository.GetLoadedHistoryAsync(_userManager.GetUserId(User))).FoodHistoryItems;
    }
}
