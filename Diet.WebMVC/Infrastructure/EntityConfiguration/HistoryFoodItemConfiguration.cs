namespace Diet.WebMVC.Infrastructure.EntityConfiguration;

public class HistoryFoodItemConfiguration : IEntityTypeConfiguration<HistoryFoodItem>
{
    public void Configure(EntityTypeBuilder<HistoryFoodItem> builder)
    {
        builder.Property(f => f.EatenFoodAmount).IsRequired();
    }
}
