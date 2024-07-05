namespace Diet.WebMVC.ViewModels;

public class FoodViewModel:BaseViewModel
{
    private readonly string displayName = "غذا";

    [Display(Name=$"نام غذا")]
    [Required(ErrorMessage = "نام اجباری است")]
    [MaxLength(150,ErrorMessage = "نام حداکثر می تواند دارای ۱۵۰ کاراکتر باشد")]
    public string? Name { get; set; }

    [Display(Name = $"در مقدار")]
    [Required(ErrorMessage = "در مقدار اجباری است")]
    public float PerAmount { get; set; }

    [Display(Name = $"کالری")]
    [Required(ErrorMessage = "کالری اجباری است")]
    public float Calorie { get; set; }
}
