namespace Diet.WebMVC.Entities;

public class HistoryFoodItem : BaseEntity
{
    public float FoodAmount { get; set; }

    //Relations
    public int FoodId { get; set; }
    public Food? Food { get; set; }

    public int HistoryId { get; set; }
    public History? History { get; set; }

    //Functionality
    public float FinalCalorie
    {
        get
        {
            if (Food == null) return -1;


            return FoodAmount / Food.Amount * Food.Calorie;
        }
    }
}
