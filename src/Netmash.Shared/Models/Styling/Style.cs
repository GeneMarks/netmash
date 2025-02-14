using Netmash.Shared.Interfaces;

namespace Netmash.Shared.Models.Styling;

public class Style(
        IStringValidator availableProperties,
        string className,
        string? pseudoClassName = null,
        string? secondaryClassName = null)
{
    public string ClassName { get; } = className;
    public string? PseudoClassName { get; } = pseudoClassName;
    public string? SecondaryClassName { get; } = secondaryClassName; // TODO: Support infinite secondary classes
    public IReadOnlyDictionary<string, string> CssProperties => _cssProperties;
    private readonly Dictionary<string, string> _cssProperties  = [];

    public void UpdateProperty(string key, string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(nameof(key), "CSS property key cannot be null or empty.");

        if (!availableProperties.IsValid(key))
        {
            throw new ArgumentException($"Invalid CSS property: \"{key}\"", nameof(key));
        }

        _cssProperties[key] = value;
    }

    public void RemoveProperty(string key)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(nameof(key), "CSS property key cannot be null or empty.");

        _cssProperties.Remove(key);
    }
}
