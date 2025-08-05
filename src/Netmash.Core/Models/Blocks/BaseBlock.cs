using Netmash.Core.Utilities;

namespace Netmash.Core.Models.Blocks;

public abstract class BaseBlock : ISortable, IStylable
{
    public abstract BlockType BlockType { get; }

    public uint SortOrder { get; set; }
    public string DivId { get; set; } = IdGenerator.NewDivId();
}
