namespace Netmash.Shared.Blocks;

public class ImageBlock(string url) : BaseBlock
{
    public override BlockType Type => BlockType.Image;
    public string Url { get; } = url;
}
