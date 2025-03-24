using Netmash.Shared.Blocks;
using Netmash.Shared.Common;
using Netmash.Shared.Interfaces;
using Netmash.Shared.Styling;
using Netmash.Shared.Utilities;

namespace Netmash.Shared.Mashes;

public class Mash(string name) : Entity, IStylable
{
    /*public Account Owner { get; }*/
    public string Name { get; set; } = name;
    public List<BaseBlock> Blocks { get; set; } = [];
    public string DivId { get; set; } = IdGenerator.NewDivId();
    public HashSet<Style> Styles { get; set; } = [];
}
