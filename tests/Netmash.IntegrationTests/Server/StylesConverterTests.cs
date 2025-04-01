using Netmash.Shared.Mashes;

namespace Netmash.IntegrationTests.Server;

public class StylesConverterTests
{
    [Fact]
    public void Styles_AreSavedAndLoadedCorrectly()
    {
        using var context = TestDbContextFactory.Create();

        var mash = new Mash("Stylable Mash")
        {
            Styles = [new(".stylable-mash", "color", "red")]
        };

        context.Mashes.Add(mash);
        context.SaveChanges();

        context.ChangeTracker.Clear(); // Stop tracking mash to ensure true db loading

        var loadedMash = context.Mashes.First();

        var expectedStyle = mash.Styles.First();
        var loadedStyle = loadedMash.Styles.First();

        Assert.Equal(expectedStyle.Selector, loadedStyle.Selector);
        Assert.Equal(expectedStyle.Rule, loadedStyle.Rule);
        Assert.Equal(expectedStyle.Value, loadedStyle.Value);
    }
}
