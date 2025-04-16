using System.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Netmash.Server.Data;

namespace Netmash.TestUtilities;

public static class TestDbContextFactory
{
    public static async Task<AppDbContext> CreateAsync(SqliteConnection connection)
    {
        if (connection.State != ConnectionState.Open)
        {
            await connection.OpenAsync();
        }

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(connection)
            .Options;

        var context = new AppDbContext(options);
        await context.Database.EnsureCreatedAsync();

        return context;
    }

    public static async Task<AppDbContext> CreateInMemoryAsync()
    {
        var connection = new SqliteConnection("Data Source=:memory:");
        return await CreateAsync(connection);
    }

    public static async Task<AppDbContext> CreateFromFileAsync(string dbPath)
    {
        var connection = new SqliteConnection($"Data Source={dbPath}");
        return await CreateAsync(connection);
    }
}
