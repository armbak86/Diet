namespace Diet.WebMVC.Pages.UserHistory;

[Authorize]
public class IndexModel : PageModel
{

    private readonly IHistoryRepository _historyRepository;
    private readonly UserManager<AppUser> _userManager;

    public IndexModel(IHistoryRepository historyRepository, IPaginationService<HistoryFoodItem> paginationService, UserManager<AppUser> userManager)
    {
        _historyRepository = historyRepository;
        _userManager = userManager;
    }

    public IEnumerable<HistoryFoodItem> FoodItems { get; set; }
    public IEnumerable<HistoryExerciseItem> ExerciseItems { get; set; }

    public async Task OnGetAsync()
    {
        FoodItems = (await _historyRepository.GetFoodsLoadedHistoryAsync(_userManager.GetUserId(User))).FoodHistoryItems;
        ExerciseItems = (await _historyRepository.GetExercisesLoadedHistoryAsync(_userManager.GetUserId(User))).ExerciseHistoryItems;
    }
}
