using Netmash.Shared.Interfaces;
using Netmash.Shared.Models.Styling;

namespace Netmash.Shared.Models;

public class Mash : IStylable
{
    public Account Owner { get; }
    public string Name { get; set; }
    public List<Block> Blocks { get; set; }
    public CssGenerator CssGenerator = new();
    public StyleContainer Styles { get; } = new();
}
