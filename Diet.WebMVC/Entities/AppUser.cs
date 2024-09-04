using System.ComponentModel.DataAnnotations.Schema;

namespace Diet.WebMVC.Entities;

public class AppUser : IdentityUser
{
        public History? History { get; set; }
}
