using Netmash.Server.Configuration;

namespace Netmash.TestUtilities;

public sealed class TestAppEnvironmentInitializerContext(AppSettings settings) : IDisposable
{
    private readonly AppSettings _settings = settings;

    public void InitializeDirectories()
    {
        AppEnvironmentInitializer.InitializeDirectories(_settings);
    }

    public void Dispose()
    {
        if (!Directory.Exists(_settings.BaseStorageDirectory)) return;

        try
        {
            Directory.Delete(_settings.BaseStorageDirectory, recursive: true);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to delete test directory: {_settings.BaseStorageDirectory}\n{ex}");
        }
    }
}
