namespace Netmash.Core.Models.Blocks;

public class CssBlock : BaseBlock
{
    public override BlockType BlockType => BlockType.Css;

    public string Css { get; set; } = string.Empty;
}
