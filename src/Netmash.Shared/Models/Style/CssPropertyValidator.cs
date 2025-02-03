namespace Netmash.Shared.Models;

public class CssPropertyValidator
{
    private readonly HashSet<String> _allowedCssProperties;

    public CssPropertyValidator(HashSet<String> allowedCssProperties)
    {
       _allowedCssProperties = allowedCssProperties;
    }

    public bool isValidProperty(string property)
    {
        return _allowedCssProperties.Contains(property);
    }
}
