using Netmash.Shared.Styling;

namespace Netmash.Shared.Interfaces;

public interface IStylable
{
    public HashSet<Style> Styles { get; }

    public virtual IEnumerable<IStylable> GetStylableChildren() => Enumerable.Empty<IStylable>();
}
