using Netmash.Shared.Blocks;
using Netmash.Shared.Interfaces;
using Netmash.Shared.Styling;
using Netmash.Shared.Utilities;

namespace Netmash.Shared.Mashes;

public class Mash : IStylable
{
    public string Id { get; } = IdGenerator.NewId();
    public Account Owner { get; }
    public string Name { get; set; }
    public List<BaseBlock> Blocks { get; set; }
    public CssGenerator CssGenerator = new(this);
    public StyleContainer Styles { get; } = new();
}
