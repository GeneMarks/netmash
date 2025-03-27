using System.Text;
using Netmash.Shared.Blocks;
using Netmash.Shared.Mashes;
using Netmash.Shared.Styling;

namespace Netmash.UnitTests.Shared;

public class CssGeneratorTests
{
    [Fact]
    public void CssGenerator_Generate_ProducesValidCss()
    {
        var mash = new Mash("Test Mash");

        mash.AddOrUpdateStyle(new Style($".{mash.DivId}", "color", "black"));
        mash.AddOrUpdateStyle(new Style($".{mash.DivId}", "font-size", "2rem"));
        mash.AddOrUpdateStyle(new Style($".{mash.DivId} .link", "color", "#f0f0f0"));

        var builder = new StringBuilder();
        builder.AppendLine($".{mash.DivId} {{");
        builder.AppendLine("    color: black;");
        builder.AppendLine("    font-size: 2rem;");
        builder.AppendLine("}");
        builder.AppendLine($".{mash.DivId} .link {{");
        builder.AppendLine("    color: #f0f0f0;");
        builder.AppendLine("}");

        var expectedCss = builder.ToString();

        var css = CssGenerator.Generate(mash);

        Assert.Equal(expectedCss, css);
    }

    [Fact]
    public void CssGenerator_Generate_ProducesValidCssWithRecursion()
    {
        var linkGroupBlock = new LinkGroupBlock();

        linkGroupBlock.AddOrUpdateStyle(new Style($".{linkGroupBlock.DivId}", "color", "black"));
        linkGroupBlock.AddOrUpdateStyle(new Style($".{linkGroupBlock.DivId}", "font-size", "2rem"));
        linkGroupBlock.AddOrUpdateStyle(new Style($".{linkGroupBlock.DivId} .link", "font-size", "2rem"));

        linkGroupBlock.Links = [
            new Link(new Uri("https://test.com/")),
            new Link(new Uri("https://test.com/"))
        ];

        var link1 = linkGroupBlock.Links[0];
        var link2 = linkGroupBlock.Links[1];

        link1.AddOrUpdateStyle(new Style($".{link1.DivId}", "border-color", "white"));
        link1.AddOrUpdateStyle(new Style($".{link1.DivId}", "margin-top", "20px"));
        link2.AddOrUpdateStyle(new Style($".{link2.DivId}", "border-color", "red"));
        link2.AddOrUpdateStyle(new Style($".{link2.DivId}", "margin-top", "6px"));

        var builder = new StringBuilder();
        builder.AppendLine($".{linkGroupBlock.DivId} {{");
        builder.AppendLine("    color: black;");
        builder.AppendLine("    font-size: 2rem;");
        builder.AppendLine("}");
        builder.AppendLine($".{linkGroupBlock.DivId} .link {{");
        builder.AppendLine("    font-size: 2rem;");
        builder.AppendLine("}");
        builder.AppendLine($".{link1.DivId} {{");
        builder.AppendLine("    border-color: white;");
        builder.AppendLine("    margin-top: 20px;");
        builder.AppendLine("}");
        builder.AppendLine($".{link2.DivId} {{");
        builder.AppendLine("    border-color: red;");
        builder.AppendLine("    margin-top: 6px;");
        builder.AppendLine("}");

        var expectedCss = builder.ToString();

        var css = CssGenerator.Generate(linkGroupBlock);

        Assert.Equal(expectedCss, css);
    }
}
