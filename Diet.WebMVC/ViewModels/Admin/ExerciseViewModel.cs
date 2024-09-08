namespace Diet.WebMVC.ViewModels;

public class ExerciseViewModel:BaseViewModel
{
    [Display(Name=$"نام فعالیت")]
    [Required(ErrorMessage = "{0} اجباری است")]
    [MaxLength(150,ErrorMessage = "{0} حداکثر می تواند دارای ۱۵۰ کاراکتر باشد")]
    public string? Name { get; set; }

    [Display(Name = $"دقیقه")]
    [Required(ErrorMessage = "{0} اجباری است")]
    public float Minutes { get; set; }

    [Display(Name = $"کالری سوخته شده")]
    [Required(ErrorMessage = "{0} اجباری است")]
    public float BurnedCalorie { get; set; }
}
