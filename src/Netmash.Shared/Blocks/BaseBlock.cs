using Netmash.Shared.Interfaces;
using Netmash.Shared.Styling;
using Netmash.Shared.Utilities;

namespace Netmash.Shared.Blocks;

public abstract class BaseBlock : IStylable
{
    public string Id { get; } = IdGenerator.NewId();
    public abstract BlockType Type { get; }
    public HashSet<Style> Styles { get; } = [];

    public virtual IEnumerable<IStylable> GetStylableChildren() => Enumerable.Empty<IStylable>();
}
