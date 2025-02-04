namespace Netmash.Shared.Models;

public class StyleSet
{
    public Style MainStyles { get; }
    public IReadOnlyDictionary<StyleVariation, Style> StyleVariations { get; }

    public StyleSet(Style mainStyles, Dictionary<StyleVariation, Style> styleVariations)
    {
        MainStyles = mainStyles;
        StyleVariations = styleVariations;
    }
}
