namespace Netmash.Shared.Blocks;

public class ImageBlock(string url) : BaseBlock
{
    public override BlockType BlockType => BlockType.Image;
    public string Url { get; set; } = url;
}
