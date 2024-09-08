namespace Diet.WebMVC.Profiles;

public class FoodItemProfile : Profile
{
    public FoodItemProfile()
    {
        CreateMap<HistoryFoodItem, FoodItemViewModel>().ReverseMap();
    }
}

public class ExerciseItemProfile : Profile
{
    public ExerciseItemProfile()
    {
        CreateMap<HistoryExerciseItem, ExerciseItemViewModel>().ReverseMap();
    }
}