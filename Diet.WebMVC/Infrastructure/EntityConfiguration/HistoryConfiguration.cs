namespace Diet.WebMVC.Infrastructure.EntityConfiguration;

public class HistoryConfiguration : IEntityTypeConfiguration<History>
{
    public void Configure(EntityTypeBuilder<History> builder)
    {
        builder.Property(f => f.CreatedDate).HasDefaultValue(DateTime.Now);
    }
}
