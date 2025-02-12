using Netmash.Shared.Interfaces;

namespace Netmash.Shared.Models.Style;

public class Style(IStylable stylee, IStringValidator availableProperties, IStringValidator availablePseudos, string? pseudoClass)
{
    public IStylable Stylee { get; } = stylee;
    public string? PseudoClass { get; }
    private Dictionary<string, string> CssProperties { get; } = new();
    private IStringValidator AvailableProperties { get; } = availableProperties;
    private IStringValidator AvailablePseudos { get; } = availablePseudos;

    public void UpdateProperty(string key, string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(nameof(key), "CSS property key cannot be null or empty.");

        if (!AvailableProperties.IsValid(key))
        {
            throw new ArgumentException($"Invalid CSS property: \"{key}\"", nameof(key));
        }

        CssProperties[key] = value;
    }

    public void RemoveProperty(string key)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(nameof(key), "CSS property key cannot be null or empty.");

        CssProperties.Remove(key);
    }
}
