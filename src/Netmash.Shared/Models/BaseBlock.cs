namespace Netmash.Shared.Models;

using Netmash.Shared.Utilities;

public abstract class BaseBlock
{
    public string Id { get; } = IdGenerator.NewId();
    public string CssClass { get; } = IdGenerator.NewCssClass();
    public abstract BlockType Type { get; }
    public StyleSet Styles { get; }

    protected BaseBlock(StyleSet styles)
    {
        Styles = styles;
    }
}
