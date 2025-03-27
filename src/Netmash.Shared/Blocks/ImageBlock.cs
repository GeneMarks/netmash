namespace Netmash.Shared.Blocks;

public class ImageBlock(Uri url) : BaseBlock
{
    public override BlockType BlockType => BlockType.Image;
    public Uri Url { get; set; } = url;
}
