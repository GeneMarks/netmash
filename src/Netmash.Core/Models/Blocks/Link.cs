using Netmash.Core.Utilities;

namespace Netmash.Core.Models.Blocks;

public class Link : ISortable, IStylable
{
    public required Uri Url { get; set; }
    public string? Text { get; set; }
    public Uri? Icon { get; set; }

    public uint SortOrder { get; set; }
    public string DivId { get; set; } = IdGenerator.NewDivId();
}
