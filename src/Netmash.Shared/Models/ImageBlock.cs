namespace Netmash.Shared.Models;

public class ImageBlock : BaseBlock
{
    public override BlockType Type => BlockType.Image;
    public string Url { get; set; }

    public ImageBlock(string url, List<Style> styles) : base(styles)
    {
        Url = url;
    }
}
