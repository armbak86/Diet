namespace Diet.WebMVC.Entities;

public class AppUser : IdentityUser
{
    public float Weight { get; set; }
    public float Hight { get; set; }
    public int Age { get; set; }

    public History? History { get; set; }

    public IEnumerable<Regimen>? Regimens { get; set; }
}
