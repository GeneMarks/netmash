using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Netmash.Server.Configuration;
using Serilog;

namespace Netmash.Server.Data;

public class AppDbManager(AppSettings settings)
{
    private readonly AppSettings _settings = settings;
    private SqliteConnection? _sharedConnection;
    private bool _isInitialized = false;

    public SqliteConnection GetConnection()
    {
        if (!_isInitialized || _sharedConnection is null)
            throw new InvalidOperationException("AppDbManager has not been initialized.");

        return _sharedConnection;
    }

    public async Task InitializeAsync()
    {
        if (_isInitialized)
        {
            Log.Information("Skipping database initialization attempt. Database already initialized.");
            return;
        }

        Log.Information("Initializing database...");

        Log.Debug("Opening connection to disk database at {DbPath}", _settings.DbPath);
        await using var dbConn = new SqliteConnection($"Data Source={_settings.DbPath}");
        await dbConn.OpenAsync();

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(dbConn)
            .Options;

        Log.Debug("Ensuring database schema with EF Core...");
        await using var context = new AppDbContext(options);
        await context.Database.EnsureCreatedAsync();

        Log.Debug("Opening shared in-memory connection...");
        _sharedConnection = new SqliteConnection("Data Source=netmash;Mode=Memory;Cache=Shared");
        await _sharedConnection.OpenAsync();

        Log.Debug("Syncing disk database to memory...");
        dbConn.BackupDatabase(_sharedConnection);

        _isInitialized = true;
        Log.Information("Database initialized and loaded into memory successfully.");
    }

    public async Task SaveToDiskAsync()
    {
        if (!_isInitialized || _sharedConnection is null)
            throw new InvalidOperationException("AppDbManager has not been initialized.");

        await CreateBackupAsync();

        Log.Information("Syncing in-memory database to file: {DbPath}", _settings.DbPath);
        Log.Debug("Opening connection to disk database at {DbPath}", _settings.DbPath);
        await using var disk = new SqliteConnection($"Data Source={_settings.DbPath}");
        await disk.OpenAsync();

        Log.Debug("Syncing in-memory database to disk...", _settings.DbPath);
        _sharedConnection.BackupDatabase(disk);
    }

    private async Task CreateBackupAsync()
    {
        int backupsToKeep = 10;
        string dbDir = _settings.DbDirectory;
        string dbPath = _settings.DbPath;
        string dbName = Path.GetFileName(dbPath);

        string timestamp = DateTime.UtcNow.ToString("yyyyMMdd-HHmmss");
        string dbBackupPath = Path.Combine(dbDir, $"{dbName}.{timestamp}.bak");

        Log.Information("Backing up {DbName} to {DbBackupPath}", dbName, dbBackupPath);
        await using FileStream source = File.Open(dbPath, FileMode.Open, FileAccess.Read, FileShare.Read);
        await using FileStream dest = File.Create(dbBackupPath);
        await source.CopyToAsync(dest);

        Log.Information("Cleaning up old database backups...");
        var backupFiles = Directory
            .GetFiles(dbDir, $"{dbName}.*.bak")
            .OrderByDescending(File.GetCreationTimeUtc)
            .ToList();

        foreach (var file in backupFiles.Skip(backupsToKeep))
        {
            Log.Debug("Deleting backup file: {File}", file);
            File.Delete(file);
        }
    }
}
