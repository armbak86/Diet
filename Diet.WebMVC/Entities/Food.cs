namespace Diet.WebMVC.Entities;

public class Food : BaseEntity
{
    public string? Name { get; set; }

    //These two props actually represent food calorie per specific amount of it
    public float PerAmount { get; set; }
    public float Calorie { get; set; }

    //Relations 
    public ICollection<HistoryFoodItem>? HistoryItems { get; set; }
}
