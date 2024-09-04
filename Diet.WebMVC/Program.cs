using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Diet.WebMVC.Infrastructure;
using Diet.WebMVC.Services;
var builder = WebApplication.CreateBuilder(args);

// TODO:Move Serilog config to appsettings
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console(theme: AnsiConsoleTheme.Code)
    .CreateLogger();

// Add services to the container.

// Serilog
builder.Host.UseSerilog();

// DataBase
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<AppUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedEmail = false;
})
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddRazorPages();

// Repositories
builder.Services.AddScoped<IFoodRepository, FoodRepository>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IRegimenRepository, RegimenRepository>();
builder.Services.AddScoped<IHistoryRepository, HistoryRepository>();
builder.Services.AddScoped<IHistoryFoodItemRepository, HistoryFoodItemRepository>();

//Services 
builder.Services.AddHttpClient<ICheckoutService, ZarinPalTestCheckoutService>();

builder.Services.AddScoped(typeof(IPaginationService<>), typeof(PaginationService<>));
builder.Services.AddScoped<ICheckoutService, ZarinPalTestCheckoutService>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(FoodProfile), typeof(ExerciseProfile), typeof(RegimenProfile));

// End services


var app = builder.Build();

// Migration
app.MigrateToDatabase<AppDbContext>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.UseMigrationsEndPoint();
else
    app.UseExceptionHandler("/Home/Error");


app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSerilogRequestLogging();

app.MapRazorPages();

app.Run();
