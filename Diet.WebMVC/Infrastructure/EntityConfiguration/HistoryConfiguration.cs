namespace Diet.WebMVC.Infrastructure.EntityConfiguration;

public class HistoryConfiguration : IEntityTypeConfiguration<History>
{
    public void Configure(EntityTypeBuilder<History> builder)
    {
        builder.Property(h => h.CreatedDate).HasDefaultValue(DateTime.Now);

        builder.HasOne(h => h.AppUser).WithOne(u => u.History).HasForeignKey<AppUser>(u => u.HistoryId);
    }
}
