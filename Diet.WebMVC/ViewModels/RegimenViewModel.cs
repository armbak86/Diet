namespace Diet.WebMVC.ViewModels;

public class RegimenViewModel:BaseViewModel
{
    [Display(Name=$"نام رژیم")]
    [Required(ErrorMessage = "نام رژیم اجباری است")]
    [MaxLength(150,ErrorMessage = "نام حداکثر می تواند دارای ۱۵۰ کاراکتر باشد")]
    public string? Name { get; set; }

    [Display(Name = $"توضییحات رژیم")]
    [Required(ErrorMessage = "توضییحات رژیم اجباری است")]
    public string? Description { get; set; }
}
