namespace Diet.WebMVC.Entities;

public class HistoryExerciseItem : BaseEntity
{
    public float ExerciseAmount { get; set; }

    //Relations
    public int ActivityId { get; set; }
    public Exercise? Activity { get; set; }

    public int HistoryId { get; set; }
    public History? History { get; set; }

    //Functionality
    public float FinalCalorie
    {
        get
        {
            if (Activity == null) return -1;


            return ExerciseAmount / Activity.Minutes * Activity.BurnedCalorie;
        }
    }
}
