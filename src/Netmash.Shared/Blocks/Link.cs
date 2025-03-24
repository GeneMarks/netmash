using Netmash.Shared.Common;
using Netmash.Shared.Interfaces;
using Netmash.Shared.Styling;
using Netmash.Shared.Utilities;

namespace Netmash.Shared.Blocks;

public class Link(string href, string title) : Entity, ISortable, IStylable
{
    public string Href { get; set; } = href;
    public string Title { get; set; } = title;
    public string? Icon { get; set; }
    public uint SortOrder { get; set; }
    public string DivId { get; set; } = IdGenerator.NewDivId();
    public HashSet<Style> Styles { get; set; } = [];
}
