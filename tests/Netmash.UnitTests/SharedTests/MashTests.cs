using Netmash.Shared.Mashes;

namespace Netmash.UnitTests.SharedTests;

public class MashTests
{
    [Fact]
    public void Mash_Name_ShouldThrowExceptionOnEmpty()
    {
        var mash = new Mash("Test Name");

        Assert.Throws<ArgumentException>(() =>
        {
            mash.Name = "";
        });
    }
}
