using Microsoft.EntityFrameworkCore;
using Netmash.Server.Configuration;
using Netmash.Server.Data;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
    var settings = builder.Configuration.Get<AppSettings>()!;

    Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Information()
        .WriteTo.Console(outputTemplate: "[{Level:u3}] {Message:lj}{NewLine}{Exception}")
        .WriteTo.File($"{settings.LogDirectory}/netmash.log", rollingInterval: RollingInterval.Day)
        .CreateLogger();

    builder.Services.AddSerilog();

    AppEnvironmentInitializer.InitializeDirectories(settings);

    var dbManager = new AppDbManager(settings);
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
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseAuthorization();

    app.MapGet("/hi", () => "Hello!");

    app.MapDefaultControllerRoute();
    app.MapRazorPages();

    app.UseAntiforgery();


    // TODO: port and coloring
    Log.Information("Started successfully. Listening on port");
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
