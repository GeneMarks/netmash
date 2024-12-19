using Mishmash.Shared.Interfaces;

namespace Mishmash.Shared.Models;

public abstract class Block
{
    public BlockType Type { get; }
    private readonly IBlockRenderer _renderer;

    protected Block(BlockType type, IBlockRenderer renderer)
    {
        Type = type;
        _renderer = renderer;
    }

    public virtual string RenderHtml()
    {
        return _renderer.Generate(this);
    }
}
