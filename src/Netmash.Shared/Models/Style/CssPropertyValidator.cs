using Netmash.Shared.Interfaces;

namespace Netmash.Shared.Models;

public class CssPropertyValidator : IStringValidator
{
    private readonly HashSet<String> _allowedCssProperties;

    public CssPropertyValidator(HashSet<String> allowedCssProperties)
    {
       _allowedCssProperties = allowedCssProperties;
    }

    public bool IsValid(string property) =>
        _allowedCssProperties.Contains(property);
}
