using Netmash.Shared.Blocks;
using Netmash.Shared.Interfaces;
using Netmash.Shared.Styling;
using Netmash.Shared.Utilities;

namespace Netmash.Shared.Mash;

public class Mash : IStylable
{
    public string Id { get; } = IdGenerator.NewId();
    public Account Owner { get; }
    public string Name { get; set; }
    public List<BaseBlock> Blocks { get; set; }
    public CssGenerator CssGenerator = new();
    public StyleContainer Styles { get; } = new();
}
