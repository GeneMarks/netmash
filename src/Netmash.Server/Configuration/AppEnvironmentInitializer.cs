using Serilog;

namespace Netmash.Server.Configuration;

public static class AppEnvironmentInitializer
{
    public static void InitializeDirectories(AppSettings settings)
    {
        Log.Information("Initializing app directories...");

        foreach (var dir in new[]
        {
            settings.DbDirectory,
            settings.UploadDirectory
        })
        {
            Log.Information("Ensuring directory exists: {Directory}", dir);
            Directory.CreateDirectory(dir);
        }
    }
}
