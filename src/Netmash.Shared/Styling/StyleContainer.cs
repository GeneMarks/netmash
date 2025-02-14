namespace Netmash.Shared.Styling;

public class StyleContainer
{
    public IReadOnlyCollection<Style> AllStyles => _styles;
    private readonly HashSet<Style> _styles = new(new StyleComparer());

    public Style? GetStyle(string className, string? pseudoClassName = null, string? secondaryClassName = null)
    {
        return _styles.FirstOrDefault(s =>
            s.ClassName == className &&
            s.PseudoClassName == pseudoClassName &&
            s.SecondaryClassName == secondaryClassName);
    }

    public void AddStyle(Style style)
    {
        if (_styles.Contains(style))
        {
            throw new ArgumentException("Cannot add style: style already exists!", nameof(style));
        }

        _styles.Add(style);
    }

    public void RemoveStyle(string className, string? pseudoClassName = null, string? secondaryClassName = null)
    {
        var style = GetStyle(className, pseudoClassName, secondaryClassName);
        if (style is not null)
        {
            _styles.Remove(style);
        }
    }
}
