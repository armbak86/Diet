namespace Diet.WebMVC.ViewModels;

public class UserLoginViewModel:BaseViewModel
{
    [Required(ErrorMessage="{0} اجباری است")]
    [EmailAddress(ErrorMessage="{0} معتبر وارد کنید!")]
    [Display(Name = "ایمیل")]
    public string Email { get; set; }

    [Required(ErrorMessage="{0} اجباری است")]
    [StringLength(100, ErrorMessage = "{0} باید بین ۶ تا ۱۰۰ کاراکتر باشد", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "رمز عبور")]
    public string Password { get; set; }

    [Display(Name = "مرا به خاطر بسپار")]
    public bool RememberMe { get; set; }

}
