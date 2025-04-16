using Netmash.Server.Configuration;
using Netmash.Server.Services.Database;

namespace Netmash.TestUtilities;

public static class TestDbManagerFactory
{
    public static AppDbManager Create(AppSettings settings) => new(settings);
}
