namespace Diet.WebMVC.ViewModels;

public class ChangePasswordViewModel : BaseViewModel
{
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "{0} اجباری است")]
    [Display(Name = "رمز قدیمی")]
    public string OldPassword { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage="{0} اجباری است")]
    [Display(Name = "رمز جدید")]
    public string NewPassword { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "{0} اجباری است")]
    [Display(Name = "تایید رمز جدید")]
    [Compare("NewPassword", ErrorMessage = "رمز های وارد شده با یکدیگر همخوانی ندارند")]
    public string ConfirmPassword { get; set; }
}
