namespace Netmash.Server.Configuration;

public class AppSettings
{
    public string DbDirectory { get; set; } = "storage/db";
    public string DbPath => Path.Combine(DbDirectory, "netmash.db");
    public string LogDirectory { get; set; } = "storage/logs";
    public string UploadDirectory { get; set; } = "storage/uploads";
}
