namespace Netmash.Core.Models.Mashes;

public class MashMetadata
{
    private string _name = string.Empty;
    public required string Name
    {
        get => _name;
        set => SetName(value);
    }
    public required string UrlPath { get; set; }
    public string? Theme { get; set; }

    private void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be blank.");
        if (name.Length > 100)
            throw new ArgumentException("Name cannot exceed 100 characters.");

        _name = name;
    }
}
