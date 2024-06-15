namespace Diet.WebMVC.Entities;

/// <summary>
/// Used in histories as items to determine user's exercise duration
/// </summary>
public class HistoryExerciseItem : BaseEntity
{
    public float DoneExerciseAmount { get; set; }

    //Relations
    public int ExerciseId { get; set; }
    public Exercise? Exercise { get; set; }

    public int HistoryId { get; set; }
    public History? History { get; set; }

    //Functionality
    public float FinalCalorie
    {
        get
        {
            if (Exercise == null) return -1;


            return DoneExerciseAmount / Exercise.Minutes * Exercise.BurnedCalorie;
        }
    }
}
