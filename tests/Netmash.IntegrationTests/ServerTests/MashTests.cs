using Netmash.Shared.Mashes;
using Netmash.TestUtilities;

namespace Netmash.IntegrationTests.ServerTests;

public class MashTests
{
    [Fact]
    public async Task Mash_CanInsertAndRetrieve()
    {
        using var context = await TestDbContextFactory.CreateInMemoryAsync();

        context.Mashes.Add(new Mash("Test Mash"));
        context.SaveChanges();

        var mash = context.Mashes.Single(m => m.Name == "Test Mash");

        Assert.NotNull(mash);
    }
}
