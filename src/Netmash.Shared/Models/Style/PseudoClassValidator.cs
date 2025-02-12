using Netmash.Shared.Interfaces;

namespace Netmash.Shared.Models.Style;

public class PseudoClassValidator(HashSet<string> allowedPseudoClasses) : IStringValidator
{
    public bool IsValid(string property) =>
        allowedPseudoClasses.Contains(property);
}
