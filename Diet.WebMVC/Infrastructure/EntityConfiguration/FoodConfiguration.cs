namespace Diet.WebMVC.Infrastructure.EntityConfiguration;

public class FoodConfiguration : IEntityTypeConfiguration<Food>
{
    public void Configure(EntityTypeBuilder<Food> builder)
    {
        builder.Property(f => f.Name).HasMaxLength(150).IsRequired();

        builder.Property(f => f.PerAmount).IsRequired();

        builder.Property(f => f.Calorie).IsRequired();

        builder.Property(f => f.CreatedDate).HasDefaultValue(DateTime.Now);
    }
}
