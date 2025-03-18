using Netmash.Shared.Interfaces;

namespace Netmash.Shared.Styling;

public static class StyleExtensions
{
    public static void AddOrUpdateStyle(this IStylable stylable, Style style)
    {
        var prevStyle = stylable.Styles.FirstOrDefault(s =>
                s.Selector == style.Selector
                && s.Rule == style.Rule);

        if (prevStyle != null)
        {
            stylable.Styles.Remove(prevStyle);
        }

        stylable.Styles.Add(style);
    }

    public static bool RemoveStyle(this IStylable stylable, string selector, string rule)
    {
        var styleToRemove = stylable.Styles.FirstOrDefault(s =>
                s.Selector == selector
                && s.Rule == rule);

        if (styleToRemove != null)
        {
            return stylable.Styles.Remove(styleToRemove);
        }

        return false;
    }
}
