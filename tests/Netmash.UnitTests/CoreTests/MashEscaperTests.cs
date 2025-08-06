using Netmash.Core.Parsing;

namespace Netmash.UnitTests.CoreTests;

public class MashEscaperTests
{
    [Fact]
    public void MashEscaper_IsEscaped_DeterminesEscapedString()
    {
        string escaped = @"This char is escaped: \[";
        string unescaped = @"This char isn't escaped: [";
        string unescaped2 = @"This char also isn't escaped: \\[";

        Assert.True(MashEscaper.IsEscaped(escaped, 23));
        Assert.False(MashEscaper.IsEscaped(unescaped, 25));
        Assert.False(MashEscaper.IsEscaped(unescaped2, 32));
    }

    [Fact]
    public void MashEscaper_Unescape_CanUnescapeAllCharsInString()
    {
        string escaped = @"This st\\\ring h\\\\\\as \\ several \""escaped\"" chars like this: \[].";
        string expected = @"This st\ring h\\\as \ several ""escaped"" chars like this: [].";

        Assert.Equal(expected, MashEscaper.Unescape(escaped));
    }
}
