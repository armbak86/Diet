namespace Diet.WebMVC.Entities;

public class Exercise : BaseEntity
{
    public string? Name { get; set; }
    public int Minutes { get; set; }
    public float BurnedCalorie { get; set; }

    //Relations 
    public IEnumerable<HistoryExerciseItem>? HistoryItems { get; set; }
}
