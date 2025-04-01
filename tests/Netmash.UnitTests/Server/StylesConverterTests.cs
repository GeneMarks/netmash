using Netmash.Server.Data.Converters;
using Netmash.Shared.Styling;

namespace Netmash.UnitTests.Server;

public class StylesConverterTests
{
    [Fact]
    public void StylesConverter_CanSerializeToJson()
    {
        var converter = new StylesConverter();
        var toProvider = converter.ConvertToProviderExpression.Compile();

        var styles = new HashSet<Style> {
            new (".class", "color", "#ffffff"),
            new (".secondClass", "border-color", "#000000")
        };

        var json = toProvider(styles);
        var expectedJson = "[{\"Selector\":\".class\",\"Rule\":\"color\",\"Value\":\"#ffffff\"}," +
            "{\"Selector\":\".secondClass\",\"Rule\":\"border-color\",\"Value\":\"#000000\"}]";

        Assert.Equal(expectedJson, json);
    }

    [Fact]
    public void StylesConverter_CanDeserializeToStyles()
    {
        var converter = new StylesConverter();
        var fromProvider = converter.ConvertFromProviderExpression.Compile();

        var json = "[{\"Selector\":\".class\",\"Rule\":\"color\",\"Value\":\"#ffffff\"}," +
            "{\"Selector\":\".secondClass\",\"Rule\":\"border-color\",\"Value\":\"#000000\"}]";

        var styles = fromProvider(json);

        Assert.NotNull(styles);
        Assert.Equal(2, styles.Count);
        Assert.Contains(new Style(".class", "color", "#ffffff"), styles);
        Assert.Contains(new Style(".secondClass", "border-color", "#000000"), styles);
    }
}
