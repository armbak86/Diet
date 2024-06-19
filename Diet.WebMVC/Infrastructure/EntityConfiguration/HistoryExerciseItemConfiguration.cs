namespace Diet.WebMVC.Infrastructure.EntityConfiguration;

public class HistoryExerciseItemConfiguration : IEntityTypeConfiguration<HistoryExerciseItem>
{
    public void Configure(EntityTypeBuilder<HistoryExerciseItem> builder)
    {
        builder.Property(f => f.DoneExerciseAmount).IsRequired();
    }
}
