using Microsoft.EntityFrameworkCore;
using Netmash.Server.Configuration;
using Netmash.Server.Data;
using Netmash.Server.Services.Database;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);

    /* Settings Configuration */
    builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
    builder.WebHost.ConfigureKestrel(options =>
    {
        options.Configure(builder.Configuration.GetSection("Kestrel"));
    });

    // Load settings for pre-build tasks
    var appSettings = builder.Configuration.GetSection("AppSettings").Get<AppSettings>()!;

    /* Logger Configuration */
    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .WriteTo.Console(outputTemplate: "[{Level:u3}] {Message:lj}{NewLine}{Exception}")
        .WriteTo.File($"{appSettings.LogDirectory}/netmash.log", rollingInterval: RollingInterval.Day)
        .CreateLogger();

    builder.Services.AddSerilog();

    /* App Environment Initialization */
    AppEnvironmentInitializer.InitializeDirectories(appSettings);

    /* Database Initialization */
    var dbManager = new AppDbManager(appSettings);
    await dbManager.InitializeAsync();

    builder.Services.AddSingleton(dbManager);

    // Use dbManager's shared connection for dbcontext
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        var conn = dbManager.GetConnection();
        options.UseSqlite(conn);
    });

    builder.Services.AddRazorPages();
    builder.Services.AddControllersWithViews();

    var app = builder.Build();

    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
    }

    app.UseStaticFiles();

    app.UseAuthorization();

    app.MapGet("/hi", () => "Hello!");

    app.MapDefaultControllerRoute();
    app.MapRazorPages();

    app.UseAntiforgery();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Failed to start.");
}
finally
{
    Log.CloseAndFlush();
}
