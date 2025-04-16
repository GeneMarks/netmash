using System.Data;
using System.Text.Json.Serialization;

namespace Netmash.Server.Configuration;

public class AppSettings
{
    private int _dbBackupsToKeep = 10;
    public int DbBackupsToKeep
    {
        get => _dbBackupsToKeep;
        set {
            if (value < 0)
                throw new ConstraintException("Must be 0 or a positive integer.");
            _dbBackupsToKeep = value;
        }
    }
    public string BaseStorageDirectory { get; set; } = "storage";
    public string DbDirectory { get; set; } = "db";
    public string DbFilename { get; set; } = "netmash.db";
    public string LogDirectory { get; set; } = "logs";
    public string UploadDirectory { get; set; } = "uploads";

    [JsonIgnore]
    public string DbFolderPath => Path.Combine(BaseStorageDirectory, DbDirectory);
    [JsonIgnore]
    public string DbFilePath => Path.Combine(DbFolderPath, DbFilename);
    [JsonIgnore]
    public string LogFolderPath => Path.Combine(BaseStorageDirectory, LogDirectory);
    [JsonIgnore]
    public string UploadFolderPath => Path.Combine(BaseStorageDirectory, UploadDirectory);
}
