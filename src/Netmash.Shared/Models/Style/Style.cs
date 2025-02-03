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
        if (!string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentNullException(nameof(key), "CSS property key cannot be null or empty.");
        }

        if (!AvailableProperties.isValidProperty(key))
        {
            throw new ArgumentException($"Invalid CSS property: \"{key}\"", nameof(key));
        }

        if (CssProperties.ContainsKey(key))
        {
            CssProperties[key] = value;
        }
        else
        {
            CssProperties.Add(key, value);
        }
    }
}
