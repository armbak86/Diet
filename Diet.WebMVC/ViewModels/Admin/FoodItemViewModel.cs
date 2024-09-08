namespace Diet.WebMVC.ViewModels;

public class FoodItemViewModel : BaseViewModel
{

    [Display(Name=$"غذا")]
    [Required(ErrorMessage = "{0} اجباری است")]
    public int FoodId { get; set; }

    [Display(Name = $"مقدار")]
    [Required(ErrorMessage = "{0} اجباری است")]
    public float EatenFoodAmount { get; set; }

 
}
