namespace Diet.WebMVC.Entities;

public class UserRegimen
{
    public string UserId { get; set; }
    public int RegimenId { get; set; }

    public ICollection<AppUser> AppUsers { get; set; }
    public ICollection<AppUser> Regimens { get; set; }
}
