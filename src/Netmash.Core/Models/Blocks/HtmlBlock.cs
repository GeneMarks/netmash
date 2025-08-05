namespace Netmash.Core.Models.Blocks;

public class HtmlBlock : BaseBlock
{
    public override BlockType BlockType => BlockType.Html;

    public string Html { get; set; } = string.Empty;
}
