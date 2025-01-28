using Netmash.Shared.Models;

namespace Netmash.Shared.Interfaces;

public interface IBlockRenderer
{
    string Generate(Block block);
}
