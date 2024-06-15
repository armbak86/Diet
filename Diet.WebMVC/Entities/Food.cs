namespace Diet.WebMVC.Entities;

public class Food : BaseEntity
{
    public string? Name { get; set; }
    public float Amount { get; set; }
    public float Calorie { get; set; }

    //Relations 
    public IEnumerable<HistoryFoodItem>? HistoryItems { get; set; }
}
