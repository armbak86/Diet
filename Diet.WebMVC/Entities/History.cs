namespace Diet.WebMVC.Entities;

public class History : BaseEntity
{
    //Relations
    public IEnumerable<HistoryFoodItem>? FoodHistoryItems { get; set; }
    public IEnumerable<HistoryExerciseItem>? ActivityHistoryItems { get; set; }
    public IEnumerable<RegimenHistory>? RegimenHistories{ get; set; }

    public string? AppUserId { get; set; }
}
