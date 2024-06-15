namespace Diet.WebMVC.Entities;

public class AppUser : IdentityUser
{
    public History? History { get; set; }
}
