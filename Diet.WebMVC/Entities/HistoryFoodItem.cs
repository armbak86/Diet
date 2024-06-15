namespace Diet.WebMVC.Entities;

/// <summary>
/// Used in histories as items to determine user's eaten food amount
/// </summary>
public class HistoryFoodItem : BaseEntity
{
    public float EatenFoodAmount { get; set; }

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


            return EatenFoodAmount / Food.PerAmount * Food.Calorie;
        }
    }
}
