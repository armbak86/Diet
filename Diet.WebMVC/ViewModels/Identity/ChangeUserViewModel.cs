namespace Diet.WebMVC.ViewModels;

public class ChangeUserViewModel
{
    [Display(Name = "وزن")]
    public float Weight { get; set; }

    [Display(Name = "قد")]
    public float Hight { get; set; }

    [Display(Name = "سن")]
    public int Age { get; set; }
}
