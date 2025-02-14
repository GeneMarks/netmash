using Netmash.Shared.Utilities;

namespace Netmash.Shared.Styling;

public class CssGenerator
{
    public string Id { get; private set; } = IdGenerator.NewId();
    private readonly HashSet<StyleContainer> _styleContainers = [];
    private string _css = "";

    public void RegisterStyles(StyleContainer styles) =>
        _styleContainers.Add(styles);

    public void UnregisterStyles(StyleContainer styles) =>
        _styleContainers.Remove(styles);

    public string BuildCss()
    {
        Id = IdGenerator.NewId(); // Set new ID string used for cache-busting

        _css = string.Join("\n\n", _styleContainers
            .SelectMany(sc => sc.AllStyles)
            .Select(GetStyleRule));

        return _css;
    }

    public static string GetStyleRule(Style style)
    {
        var selector = $".{style.ClassName}";

        if (style.SecondaryClassName is not null)
        {
            selector = $"{selector} .{style.SecondaryClassName}";
        }

        if (style.PseudoClassName is not null)
        {
            selector = $"{selector}:{style.PseudoClassName}";
        }

        var properties = string.Join("\n", style.CssProperties.Select(kvp => $"{kvp.Key}: {kvp.Value};"));

        return $$"""
            {{selector}} {
                {{properties}}
            }
            """;
    }

}
