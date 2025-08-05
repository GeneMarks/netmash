using Netmash.Core.Models.Blocks;
using Netmash.Core.Utilities;

namespace Netmash.Core.Models.Mashes;

public class Mash : IStylable
{
    public required MashMetadata Metadata { get; init; }
    public List<BaseBlock> Blocks { get; set; } = [];

    public string DivId { get; set; } = IdGenerator.NewDivId();
}
