namespace Netmash.Shared.Blocks;

public class ImageBlock : BaseBlock
{
    public Uri Url { get; set; }

    public ImageBlock(Uri url)
    {
        BlockType = BlockType.Image;
        Url = url;
    }
}
