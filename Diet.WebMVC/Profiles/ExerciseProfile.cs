namespace Diet.WebMVC.Profiles;

public class ExerciseProfile : Profile
{
    public ExerciseProfile()
    {
        CreateMap<Exercise, ExerciseViewModel>().ReverseMap();
    }
}
