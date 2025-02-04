namespace Netmash.Shared.Models;

public class CssPropertyValidator
{
    private readonly HashSet<String> _allowedCssProperties;

    public CssPropertyValidator(HashSet<String> allowedCssProperties)
    {
       _allowedCssProperties = allowedCssProperties;
    }

    public bool IsValidProperty(string property) =>
        _allowedCssProperties.Contains(property);
}
