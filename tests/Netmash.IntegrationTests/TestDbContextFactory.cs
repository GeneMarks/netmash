using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Netmash.Server.Data;

namespace Netmash.IntegrationTests;

public class TestDbContextFactory
{
    public static ApplicationDbContext Create()
    {
        var connection = new SqliteConnection("Data Source=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlite(connection)
            .Options;

        var context = new ApplicationDbContext(options);
        context.Database.EnsureCreated();

        return context;
    }
}
