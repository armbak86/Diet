
namespace Diet.WebMVC.ViewModels;

public class ExerciseItemViewModel : BaseViewModel
{
    [Display(Name=$"فعالیت")]
    [Required(ErrorMessage = "{0} اجباری است")]
    public int ExerciseId { get; set; }

    [Display(Name = $"مقدار")]
    [Required(ErrorMessage = "{0} اجباری است")]
    public float DoneExerciseAmount { get; set; }
}
