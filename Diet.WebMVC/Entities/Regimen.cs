namespace Diet.WebMVC.Entities;

public class Regimen : BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int Price { get; set; }

    // Relations
    public IEnumerable<RegimenHistory>? RegimenHistories{ get; set; }
}
