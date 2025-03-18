using Netmash.Shared.Interfaces;
using Netmash.Shared.Styling;

namespace Netmash.Shared.Blocks;

public class Link(string href, string title) : IStylable
{
    public string Href { get; set; } = href;
    public string Title { get; set; } = title;
    public string? Icon { get; set; }
    public HashSet<Style> Styles { get; } = [];
}
