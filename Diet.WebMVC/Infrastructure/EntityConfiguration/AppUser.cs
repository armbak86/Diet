namespace Diet.WebMVC.Infrastructure.EntityConfiguration;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(u => u.Weight).IsRequired();
        builder.Property(u => u.Hight).IsRequired();
        builder.Property(u => u.Age).IsRequired();

        builder.HasOne(u => u.History).WithOne(h => h.AppUser).HasForeignKey<History>(h => h.AppUserId);
    }
}
