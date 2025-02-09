using Netmash.Shared.Interfaces;
using Netmash.Shared.Utilities;

namespace Netmash.Shared.Models;

public abstract class BaseBlock : IStylable
{
    public string Id { get; } = IdGenerator.NewId();
    public abstract BlockType Type { get; }
    public string CssClass { get; } = IdGenerator.NewCssClass();
    public List<Style> Styles { get; }

    protected BaseBlock(List<Style> styles)
    {
        Styles = styles;
    }
}
