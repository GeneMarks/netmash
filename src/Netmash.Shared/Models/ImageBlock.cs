using Netmash.Shared.Interfaces;

namespace Netmash.Shared.Models;

public class ImageBlock : Block
{
    public ImageBlock(IBlockRenderer Renderer) : base(BlockType.Image, Renderer) { }
}
