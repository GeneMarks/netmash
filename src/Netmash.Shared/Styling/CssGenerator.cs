using System.Text;
using Netmash.Shared.Interfaces;

namespace Netmash.Shared.Styling;

public static class CssGenerator
{
    public static string Generate(IStylable stylableObj)
    {
        var builder = new StringBuilder();
        BuildCss(stylableObj, builder);
        return builder.ToString();
    }

    private static void BuildCss(IStylable stylableObj, StringBuilder builder)
    {
        var groupedStyles = stylableObj.Styles.GroupBy(style => style.Selector);

        foreach (var group in groupedStyles)
        {
            var rules = string.Join(Environment.NewLine, group.Select(s => $"    {s.Rule}: {s.Value};"));
            builder.AppendLine($"{group.Key} {{");
            builder.AppendLine(rules);
            builder.AppendLine("}");
        }

        foreach (var child in stylableObj.GetStylableChildren())
        {
            BuildCss(child, builder);
        }
    }
}
