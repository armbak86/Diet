namespace Diet.WebMVC.Profiles;

public class RegimenProfile : Profile
{
    public RegimenProfile()
    {
        CreateMap<Regimen, RegimenViewModel>()
            .ForPath(dest => dest.Image.FileName, opt => opt.MapFrom(src => src.Image))
            .ForPath(dest => dest.File.FileName, opt => opt.MapFrom(src => src.File))
            .ReverseMap();

        CreateMap<Regimen, UpdateRegimenViewModel>().ReverseMap();
    }
}
