namespace Diet.WebMVC.ViewModels;

public class UpdateRegimenViewModel:BaseViewModel
{
    [Display(Name=$"نام رژیم")]
    [Required(ErrorMessage = "{0} اجباری است")]
    [MaxLength(150,ErrorMessage="{0} حداکثر می تواند دارای ۱۵۰ کاراکتر باشد")]
    public string? Name { get; set; }

    [Display(Name = $"قیمت")]
    [Required(ErrorMessage = "{0} اجباری است")]
    public int Price { get; set; }

    [Display(Name = $"توضییحات رژیم")]
    [MinLength(25,ErrorMessage="{0} حداقل می تواند دارای {1} کاراکتر باشد"),MaxLength(750,ErrorMessage = "{0} حداکثر می تواند دارای {1} کاراکتر باشد")]
    [Required(ErrorMessage = "{0} اجباری است")]
    public string? Description { get; set; }
    
    [Display(Name = $"عکس رژیم")]
    public IFormFile? ImageFormFile{ get; set; }

    public string? Image { get; set; }

    [Display(Name = $"فایل رژیم")]
    public IFormFile? FileFormFile{ get; set; }
    public string? File { get; set; }
}
