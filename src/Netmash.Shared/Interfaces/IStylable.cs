using Netmash.Shared.Models;

namespace Netmash.Shared.Interfaces;

public interface IStylable
{
    public string CssClass { get; }
    public List<Style> Styles { get; }
}
