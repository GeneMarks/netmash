using Netmash.Shared.Interfaces;

namespace Netmash.Shared.Models;

public class Style
{
    public IStylable Parent { get; }
    private Dictionary<string, string> CssProperties { get; } = new();
    private string? PseudoClass { get; }
    private IStringValidator AvailableProperties { get; }
    private IStringValidator AvailablePseudos { get; }

    public Style(IStylable parent, IStringValidator availableProperties, IStringValidator availablePseudos, string? pseudoClass)
    {
        Parent = parent;
        AvailableProperties = availableProperties;
        AvailablePseudos = availablePseudos;
        if (pseudoClass is not null)
        {
            PseudoClass = pseudoClass;
        }
    }

    public void UpdateProperty(string key, string value)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(nameof(key), "CSS property key cannot be null or empty.");

        if (!AvailableProperties.IsValid(key))
        {
            throw new ArgumentException($"Invalid CSS property: \"{key}\"", nameof(key));
        }

        CssProperties[key] = value;
    }

    public void RemoveProperty(string key)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(nameof(key), "CSS property key cannot be null or empty.");

        CssProperties.Remove(key);
    }
}
