using Netmash.Server.Configuration;

namespace Netmash.TestUtilities;

public static class TestAppSettingsFactory
{
    public static AppSettings Create() => new()
    {
        BaseStorageDirectory = Path.Combine("test_storage", Guid.NewGuid().ToString())
    };
}
