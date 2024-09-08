namespace Diet.WebMVC.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<AppUser, ChangeUserViewModel>().ReverseMap();
    }
}
