namespace Diet.WebMVC.Entities;

/// <summary>
/// A wrapper for history items to record eaten foods and exercises
/// </summary>
public class History : BaseEntity
{
    //Relations
    public IEnumerable<HistoryFoodItem>? FoodHistoryItems { get; set; }
    public IEnumerable<HistoryExerciseItem>? ExerciseHistoryItems { get; set; }

    public AppUser? AppUser { get; set; }
    public string? AppUserId { get; set; }
}
