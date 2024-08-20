namespace Diet.WebMVC.ViewModels;

public class FoodViewModel:BaseViewModel
{
    private readonly string displayName = "غذا";

    [Display(Name=$"نام غذا")]
    [Required(ErrorMessage = "{0} اجباری است")]
    [MaxLength(150,ErrorMessage = "{0} حداکثر می تواند دارای ۱۵۰ کاراکتر باشد")]
    public string? Name { get; set; }

    [Display(Name = $"در مقدار")]
    [Required(ErrorMessage = "{0} اجباری است")]
    public float PerAmount { get; set; }

    [Display(Name = $"کالری")]
    [Required(ErrorMessage = "{0} اجباری است")]
    public float Calorie { get; set; }
}
