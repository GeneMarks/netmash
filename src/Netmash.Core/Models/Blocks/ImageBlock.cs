namespace Netmash.Core.Models.Blocks;

public class ImageBlock : BaseBlock
{
    public override BlockType BlockType => BlockType.Image;

    public required Uri Url { get; set; }
    public string? AltText { get; set; }
}
