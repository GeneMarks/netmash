namespace Netmash.Server.Configuration;

public class AppSettings
{
    public string DbDirectory { get; set; } = "db";
    public string DbPath => Path.Combine(DbDirectory, "netmash.db");
    public string LogDirectory { get; set; } = "logs";
    public string UploadDirectory { get; set; } = "uploads";
}
