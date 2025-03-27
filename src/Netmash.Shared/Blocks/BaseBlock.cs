using Netmash.Shared.Common;
using Netmash.Shared.Interfaces;
using Netmash.Shared.Styling;
using Netmash.Shared.Utilities;

namespace Netmash.Shared.Blocks;

public abstract class BaseBlock : Entity, ISortable, IStylable
{
    public uint SortOrder { get; set; }
    public string DivId { get; set; } = IdGenerator.NewDivId();
    public HashSet<Style> Styles { get; set; } = [];

    public abstract BlockType BlockType { get; }

    public virtual IEnumerable<IStylable> GetStylableChildren() => [];
}
