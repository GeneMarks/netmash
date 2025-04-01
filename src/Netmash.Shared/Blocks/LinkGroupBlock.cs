using Netmash.Shared.Interfaces;

namespace Netmash.Shared.Blocks;

public class LinkGroupBlock : BaseBlock
{
    public List<Link> Links { get; set; } = [];

    public override IEnumerable<IStylable> GetStylableChildren() => Links;

    public LinkGroupBlock()
    {
        BlockType = BlockType.LinkGroup;
    }
}
