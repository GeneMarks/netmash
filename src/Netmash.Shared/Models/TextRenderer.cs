using Netmash.Shared.Interfaces;

namespace Netmash.Shared.Models;

public class TextRenderer : IBlockRenderer
{
    public string Generate(Block block)
    {
        return "hi";
    }
}
