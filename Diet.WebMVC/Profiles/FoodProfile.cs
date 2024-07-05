namespace Diet.WebMVC.Profiles;

public class FoodProfile : Profile
{
    public FoodProfile()
    {
        CreateMap<Food, FoodViewModel>().ReverseMap();
    }
}
