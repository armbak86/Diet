namespace Diet.WebMVC.ViewModels;

public class ChangeEmailViewModel:BaseViewModel
{
    [Required(ErrorMessage="{0} اجباری است")]
    [EmailAddress(ErrorMessage = "{0} معتبر وارد کنید!")]
    [Display(Name = "ایمیل جدید")]
    public string NewEmail { get; set; }
}
