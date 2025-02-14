namespace Netmash.Shared.Styling;

public class StyleComparer : IEqualityComparer<Style>
{
    public bool Equals(Style? x, Style? y)
    {
        if (x is null && y is null) return true;
        if (x is null || y is null) return false;

        return x.ClassName == y.ClassName &&
            x.PseudoClassName == y.PseudoClassName &&
            x.SecondaryClassName == y.SecondaryClassName;
    }

    public int GetHashCode(Style obj)
    {
        ArgumentNullException.ThrowIfNull(nameof(obj));
        return HashCode.Combine(obj.ClassName, obj.PseudoClassName, obj.SecondaryClassName);
    }
}
