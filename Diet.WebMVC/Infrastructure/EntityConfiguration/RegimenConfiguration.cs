namespace Diet.WebMVC.Infrastructure.EntityConfiguration;

public class RegimenConfiguration : IEntityTypeConfiguration<Regimen>
{
    public void Configure(EntityTypeBuilder<Regimen> builder)
    {
        builder.Property(f => f.Name).HasMaxLength(150).IsRequired();

        builder.Property(f => f.Description).HasMaxLength(750).IsRequired();

        builder.Property(f => f.CreatedDate).HasDefaultValue(DateTime.Now);
    }
}
