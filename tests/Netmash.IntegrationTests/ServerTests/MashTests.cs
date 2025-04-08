using Netmash.IntegrationTests.TestHelpers;
using Netmash.Shared.Mashes;

namespace Netmash.IntegrationTests.ServerTests;

public class MashTests
{
    [Fact]
    public void Mash_CanInsertAndRetrieve()
    {
        using var context = TestDbContextFactory.Create();

        context.Mashes.Add(new Mash("Test Mash"));
        context.SaveChanges();

        var mash = context.Mashes.Single(m => m.Name == "Test Mash");

        Assert.NotNull(mash);
    }
}
