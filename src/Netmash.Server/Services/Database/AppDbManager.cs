using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Netmash.Server.Configuration;
using Netmash.Server.Data;
using Serilog;

namespace Netmash.Server.Services.Database;

public class AppDbManager(AppSettings settings)
{
    private readonly AppSettings _settings = settings;
    private const string _backupsTimestampFormat = "yyyyMMdd-HHmmssfff";
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

        Log.Debug("Opening connection to disk database at {DbFilePath}", _settings.DbFilePath);
        await using var dbConn = new SqliteConnection($"Data Source={_settings.DbFilePath}");
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

        Log.Information("Syncing in-memory database to file: {DbFilePath}", _settings.DbFilePath);
        Log.Debug("Opening connection to disk database at {DbFilePath}", _settings.DbFilePath);
        await using var dbConn = new SqliteConnection($"Data Source={_settings.DbFilePath}");
        await dbConn.OpenAsync();

        Log.Debug("Syncing in-memory database to {DbFilePath}...", _settings.DbFilePath);
        _sharedConnection.BackupDatabase(dbConn);
    }

    private async Task CreateBackupAsync()
    {
        string dbFolderPath = _settings.DbFolderPath;
        string dbFilePath = _settings.DbFilePath;
        string dbFilename = _settings.DbFilename;

        string timestamp = DateTime.UtcNow.ToString(_backupsTimestampFormat);
        string dbBackupFilePath = Path.Combine(dbFolderPath, $"{dbFilename}.{timestamp}.bak");

        Log.Information("Backing up {DbName} to {DbBackupPath}", dbFilename, dbBackupFilePath);
        await using FileStream source = File.Open(dbFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        await using FileStream dest = File.Create(dbBackupFilePath);
        await source.CopyToAsync(dest);

        CleanupBackups($"{dbFilename}.*.bak");
    }

    private void CleanupBackups(string pattern)
    {
        Log.Information("Cleaning up old database backups...");
        var backupFiles = Directory
            .GetFiles(_settings.DbFolderPath, pattern)
            .OrderByDescending(Path.GetFileName)
            .ToList();

        foreach (var file in backupFiles.Skip(_settings.DbBackupsToKeep))
        {
            Log.Debug("Deleting backup file: {File}", file);
            File.Delete(file);
        }
    }
}
