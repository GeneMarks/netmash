using Netmash.Shared.Interfaces;

namespace Netmash.Shared.Models;

public class PseudoClassValidator : IStringValidator
{
    private readonly HashSet<String> _allowedPseudoClasses;

    public PseudoClassValidator(HashSet<String> allowedPseudoClasses)
    {
       _allowedPseudoClasses = allowedPseudoClasses;
    }

    public bool IsValid(string property) =>
        _allowedPseudoClasses.Contains(property);
}
