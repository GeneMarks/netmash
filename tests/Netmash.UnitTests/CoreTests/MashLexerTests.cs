using Netmash.Core.Parsing;

namespace Netmash.UnitTests.CoreTests;

public class MashLexerTests
{
    [Fact]
    public void MashLexer_Tokenize_ProducesValidTokenList()
    {
        string testMash = """
            [block:Text id=intro-text]
            Welcome to <i>Netmash</i>. This is a text block.
            And here's another line in the block.
            [/block:style]

            color: #000000
            [/style]
            """;

        List<MashToken> expectedMashTokens =
        [
            new MashToken { Type = MashTokenType.TagOpen, LineNumber = 1, Content = "block:Text id=intro-text" },
            new MashToken { Type = MashTokenType.Body, LineNumber = 2, Content = """
                Welcome to <i>Netmash</i>. This is a text block.
                And here's another line in the block.
                """},
            new MashToken { Type = MashTokenType.TagClose, LineNumber = 4, Content = "/block:style" },
            new MashToken { Type = MashTokenType.Body, LineNumber = 6, Content = "color: #000000" },
            new MashToken { Type = MashTokenType.TagClose, LineNumber = 7, Content = "/style" }
        ];

        var mashTokens = MashLexer.Tokenize(testMash);

        Assert.Equal(expectedMashTokens, mashTokens);
    }
}
