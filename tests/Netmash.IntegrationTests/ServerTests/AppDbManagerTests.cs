using System.Data;
using Microsoft.EntityFrameworkCore;
using Netmash.Shared.Mashes;
using Netmash.TestUtilities;

namespace Netmash.IntegrationTests.ServerTests;

public class AppDbManagerTests
{
    [Fact]
    public async Task AppDbManager_InitializeAsync_CreatesValidConnection()
    {
        var settings = TestAppSettingsFactory.Create();

        using var environmentInitializer = new TestAppEnvironmentInitializerContext(settings);
        environmentInitializer.InitializeDirectories();

        var dbManager = TestDbManagerFactory.Create(settings);
        await dbManager.InitializeAsync();

        var conn = dbManager.GetConnection();

        Assert.NotNull(conn);
        Assert.Equal(ConnectionState.Open, conn.State);
    }

    [Fact]
    public async Task AppDbManager_SaveToDiskAsync_SavesDatabaseToDisk()
    {
        var settings = TestAppSettingsFactory.Create();

        using var environmentInitializer = new TestAppEnvironmentInitializerContext(settings);
        environmentInitializer.InitializeDirectories();

        var dbManager = TestDbManagerFactory.Create(settings);
        await dbManager.InitializeAsync();

        var dbFileSize = new FileInfo(settings.DbFilePath).Length;

        using var context = await TestDbContextFactory.CreateAsync(dbManager.GetConnection());
        context.Mashes.Add(new Mash("Test Mash"));
        await context.SaveChangesAsync();

        await dbManager.SaveToDiskAsync();

        var updatedDbFileSize = new FileInfo(settings.DbFilePath).Length;

        using var diskContext = await TestDbContextFactory.CreateFromFileAsync(settings.DbFilePath);
        var mashFromDisk = await diskContext.Mashes.FirstOrDefaultAsync();

        Assert.True(File.Exists(settings.DbFilePath));
        Assert.True(updatedDbFileSize >= dbFileSize);
        Assert.NotNull(mashFromDisk);
        Assert.Equal("Test Mash", mashFromDisk.Name);
    }

    [Fact]
    public async Task AppDbManager_SaveToDiskAsync_CleansUpOldBackupFiles()
    {
        var settings = TestAppSettingsFactory.Create();

        using var environmentInitializer = new TestAppEnvironmentInitializerContext(settings);
        environmentInitializer.InitializeDirectories();

        var dbManager = TestDbManagerFactory.Create(settings);
        await dbManager.InitializeAsync();

        // Mock-up backup files
        var backupFilePaths = new List<string>();

        for (int i = 0; i < settings.DbBackupsToKeep + 5; ++i)
        {
            string timestamp = DateTime.UtcNow.AddDays(-i).ToString("yyyyMMdd-HHmmssfff");
            string filePath = Path.Combine(settings.DbFolderPath, $"{settings.DbFilename}.{timestamp}.bak");

            File.Create(filePath)
                .Dispose();

            backupFilePaths.Add(filePath);

            await Task.Delay(50); // timestamp collision safety net
        }

        var expectedToBeKept = backupFilePaths
            .OrderByDescending(Path.GetFileName)
            .Take(settings.DbBackupsToKeep)
            .Select(Path.GetFileName)
            .ToHashSet();

        // remove oldest of kept backups (it will get bumped by the newly created one)
        expectedToBeKept.Remove(expectedToBeKept.OrderBy(name => name).First());

        // Save to disk triggers backup and backup cleanup logic
        await dbManager.SaveToDiskAsync();

        var postBackupFilePaths = Directory
            .GetFiles(settings.DbFolderPath, $"{settings.DbFilename}.*.bak")
            .OrderByDescending(Path.GetFileName)
            .Skip(1) // skip the newly created backup
            .Select(Path.GetFileName)
            .ToHashSet();

        Assert.Equal(expectedToBeKept.Count, postBackupFilePaths.Count);
        Assert.Equal(expectedToBeKept, postBackupFilePaths);
    }
}
