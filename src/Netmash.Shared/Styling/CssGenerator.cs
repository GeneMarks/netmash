using Netmash.Shared.Interfaces;
using Netmash.Shared.Utilities;

namespace Netmash.Shared.Styling;

public class CssGenerator(IStylable stylableObj)
{
    public string Id { get; private set; } = IdGenerator.NewId();
    private IStylable StylableObj { get; } = stylableObj;
    private string _css = "";

    public string Generate()
    {
        // Set new ID string used for cache-busting
        Id = IdGenerator.NewId();
        // Clear css before rebuilding
        _css = "";
        // Recursively build css
        BuildCss(StylableObj);

        return _css;
    }

    private void BuildCss(IStylable stylableObj)
    {
        var groupedStyles = stylableObj.Styles.GroupBy(style => style.Selector);

        foreach (var group in groupedStyles)
        {
            var rules = string.Join("\n", group.Select(s => $"    {s.Rule}: {s.Value};"));
            _css += $"\n\n{group.Key} {{\n{rules}\n}}";
        }

        var stylableChildren = stylableObj.GetStylableChildren();

        if (!stylableChildren.Any()) return;
        foreach (var child in stylableChildren)
        {
            BuildCss(child);
        }
    }
}
