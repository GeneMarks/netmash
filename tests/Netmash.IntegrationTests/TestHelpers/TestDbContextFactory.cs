using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Netmash.Server.Data;

namespace Netmash.IntegrationTests.TestHelpers;

public class TestDbContextFactory
{
    public static AppDbContext Create()
    {
        var connection = new SqliteConnection("Data Source=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(connection)
            .Options;

        var context = new AppDbContext(options);
        context.Database.EnsureCreated();

        return context;
    }
}
