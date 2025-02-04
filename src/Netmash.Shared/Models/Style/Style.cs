namespace Netmash.Shared.Models;

public class Style
{
    private CssPropertyValidator AvailableProperties { get; }
    private Dictionary<string, string> CssProperties { get; } = new();

    public Style(CssPropertyValidator availableProperties)
    {
        AvailableProperties = availableProperties;
    }

    public void UpdateProperty(string key, string value)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentNullException(nameof(key), "CSS property key cannot be null or empty.");
        }

        if (!AvailableProperties.IsValidProperty(key))
        {
            throw new ArgumentException($"Invalid CSS property: \"{key}\"", nameof(key));
        }

        CssProperties[key] = value;
    }
}
