namespace Products.Infrastructure.Persistence.EntityConfiguration;

public class HistoryExerciseItemConfiguration : IEntityTypeConfiguration<HistoryExerciseItem>
{
    public void Configure(EntityTypeBuilder<HistoryExerciseItem> builder)
    {
        builder.Property(f => f.DoneExerciseAmount).IsRequired();
    }
}
