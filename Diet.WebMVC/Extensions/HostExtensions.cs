namespace Categories.API.Extensions;

public static class HostExtensions
{
    public static WebApplication MigrateToDatabase<TDbContext>(this WebApplication host, Action<TDbContext>? seed = null,int count = 0)
        where TDbContext : DbContext
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<TDbContext>();
            var logger = services.GetRequiredService<ILogger<Program>>();

            try
            {
                logger.LogInformation("Migrating to the database ...");
                context.Database.Migrate();
                logger.LogInformation("Migrated successfully.");

                logger.LogInformation("Seeding the database ...");
                seed?.Invoke(context);
                logger.LogInformation("Seeded successfully.");
            }
            catch (Exception ex)
            {
                //TODO:Use Polly
                logger.LogInformation($"Something went wrong!\n  {ex.Message}");
                count++;
                if (count < 50) MigrateToDatabase<TDbContext>(host, seed, count);
            }

            return host;
        }
    }
}
