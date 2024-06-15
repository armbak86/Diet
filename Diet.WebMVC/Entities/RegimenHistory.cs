namespace Diet.WebMVC.Entities;

public class RegimenHistory
{
    public int HistoryId { get; set; }
    public int RegimenId { get; set; }
    public History? History { get; set; }
    public Regimen? Regimen { get; set; }
}
