namespace Diet.WebMVC.Entities.Common;

/// <summary>
/// Extracting all common properties in this class 
/// </summary>
public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
}