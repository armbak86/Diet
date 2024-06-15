namespace Diet.WebMVC.Infrastructure;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Food> Foods { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<History> Histories { get; set; }
    public DbSet<HistoryExerciseItem> HistoryExerciseItems{ get; set; }
    public DbSet<HistoryFoodItem> HistoryFoodItems { get; set; }
    public DbSet<Regimen> Regimens { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new FoodConfiguration());
        modelBuilder.ApplyConfiguration(new ExerciseConfiguration());
        modelBuilder.ApplyConfiguration(new HistoryFoodItemConfiguration());
        modelBuilder.ApplyConfiguration(new HistoryExerciseItemConfiguration());
        modelBuilder.ApplyConfiguration(new HistoryConfiguration());
        modelBuilder.ApplyConfiguration(new RegimenConfiguration());
    }
}
