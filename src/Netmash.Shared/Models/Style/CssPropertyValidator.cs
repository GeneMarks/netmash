using Netmash.Shared.Interfaces;

namespace Netmash.Shared.Models.Style;

public class CssPropertyValidator(HashSet<string> allowedCssProperties) : IStringValidator
{
    public bool IsValid(string property) =>
        allowedCssProperties.Contains(property);
}
