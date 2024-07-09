namespace Diet.WebMVC.Profiles;

public class RegimenProfile : Profile
{
    public RegimenProfile() => CreateMap<Regimen, RegimenViewModel>().ReverseMap();
}
