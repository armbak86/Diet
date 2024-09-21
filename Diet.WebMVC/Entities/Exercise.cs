namespace Diet.WebMVC.Entities;

public class Exercise : BaseEntity
{
    public string? Name { get; set; }

    //These two props actually represent burned calories per specific time of doing it
    public int Minutes { get; set; }
    public float BurnedCalorie { get; set; }

    //Relations 
    public ICollection<HistoryExerciseItem>? HistoryItems { get; set; }
}
