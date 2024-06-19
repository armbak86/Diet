namespace Diet.WebMVC.Infrastructure.EntityConfiguration;

public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder.Property(f => f.Name).HasMaxLength(150).IsRequired();

        builder.Property(f => f.BurnedCalorie).IsRequired();

        builder.Property(f => f.CreatedDate).HasDefaultValue(DateTime.Now);
    }
}
