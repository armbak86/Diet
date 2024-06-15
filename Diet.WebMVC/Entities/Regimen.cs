namespace Diet.WebMVC.Entities;

public class Regimen : BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    
    //TODO: Decide if you want the user be charged for Regimen
    //public int Price { get; set; }

    // Relations
    public IEnumerable<History>? Histories{ get; set; }
}
