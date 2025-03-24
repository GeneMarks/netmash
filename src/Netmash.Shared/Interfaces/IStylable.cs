using Netmash.Shared.Styling;

namespace Netmash.Shared.Interfaces;

public interface IStylable
{
    string DivId { get; set; }
    HashSet<Style> Styles { get; set; }

    IEnumerable<IStylable> GetStylableChildren() => [];
}
