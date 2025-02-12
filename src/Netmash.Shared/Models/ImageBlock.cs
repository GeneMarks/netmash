namespace Netmash.Shared.Models;

public class ImageBlock(string url, List<Style> styles) : BaseBlock(styles)
{
    public override BlockType Type => BlockType.Image;
    public string Url { get; set; } = url;
}
