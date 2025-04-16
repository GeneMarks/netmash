using Netmash.Shared.Mashes;
using Netmash.TestUtilities;

namespace Netmash.IntegrationTests.ServerTests;

public class StylesConverterTests
{
    [Fact]
    public async Task Styles_AreSavedAndLoadedCorrectly()
    {
        using var context = await TestDbContextFactory.CreateInMemoryAsync();

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
