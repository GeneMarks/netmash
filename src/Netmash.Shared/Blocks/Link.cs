using Netmash.Shared.Common;
using Netmash.Shared.Interfaces;
using Netmash.Shared.Styling;
using Netmash.Shared.Utilities;

namespace Netmash.Shared.Blocks;

public class Link(Uri href, string? title = null, Uri? icon = null) : Entity, ISortable, IStylable
{
    public uint SortOrder { get; set; }
    public string DivId { get; set; } = IdGenerator.NewDivId();
    public HashSet<Style> Styles { get; set; } = [];

    public Uri Href { get; set; } = href;
    public string? Title { get; set; } = title;
    public Uri? Icon { get; set; } = icon;
}
