using Netmash.Shared.Interfaces;

namespace Netmash.Shared.Blocks;

public class LinkGroupBlock : BaseBlock
{
    public override BlockType BlockType => BlockType.LinkGroup;
    public List<Link> Links { get; set; } = [];

    public override IEnumerable<IStylable> GetStylableChildren() => Links;
}
