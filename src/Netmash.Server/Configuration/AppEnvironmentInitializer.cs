using Serilog;

namespace Netmash.Server.Configuration;

public static class AppEnvironmentInitializer
{
    public static void InitializeDirectories(AppSettings settings)
    {
        Log.Information("Initializing app directories...");

        foreach (var dir in new[]
        {
            settings.DbFolderPath,
            settings.LogFolderPath,
            settings.UploadFolderPath
        })
        {
            Log.Information("Ensuring directory exists: {Directory}", dir);
            Directory.CreateDirectory(dir);
        }
    }
}
