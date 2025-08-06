using Netmash.Core.Models.Mashes;

namespace Netmash.UnitTests.CoreTests;

public class MashTests
{
    [Fact]
    public void Mash_Name_ShouldThrowExceptionOnEmpty()
    {
        var mash = new Mash
        {
            Metadata = new MashMetadata { Name = "Test Mash", UrlPath = "/" }
        };

        Assert.Throws<ArgumentException>(() =>
        {
            mash.Metadata.Name = "";
        });
    }
}
