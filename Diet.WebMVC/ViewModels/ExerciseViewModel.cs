namespace Diet.WebMVC.ViewModels;

public class ExerciseViewModel:BaseViewModel
{
    [Display(Name=$"نام فعالیت")]
    [Required(ErrorMessage = "نام فعالیت اجباری است")]
    [MaxLength(150,ErrorMessage = "نام حداکثر می تواند دارای ۱۵۰ کاراکتر باشد")]
    public string? Name { get; set; }

    [Display(Name = $"دقیقه")]
    [Required(ErrorMessage = "دقیقه اجباری است")]
    public float Minutes { get; set; }

    [Display(Name = $"کالری سوخته شده")]
    [Required(ErrorMessage = "کالری سوخته شده اجباری است")]
    public float BurnedCalorie { get; set; }
}
