using Netmash.Shared.Interfaces;

namespace Netmash.Shared.Blocks;

public class LinkGroupBlock : BaseBlock
{
    public override BlockType Type => BlockType.LinkGroup;
    public List<Link> Links { get; } = [];

    public override IEnumerable<IStylable> GetStylableChildren() => Links;
}
