namespace Netmash.Core.Models.Blocks;

public class LinksBlock : BaseBlock
{
    public override BlockType BlockType => BlockType.Links;

    public List<Link> Links { get; set; } = [];
}
