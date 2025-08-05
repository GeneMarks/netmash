using System.Text.RegularExpressions;

namespace Netmash.Core.Parsing;

public static partial class TokenRegex
{
    [GeneratedRegex(@"\[(?<tag>.*?)\]", RegexOptions.Multiline)]
    public static partial Regex Regex();
}

public static class MashLexer
{
    private static MatchCollection TokenMatches(string input) => TokenRegex.Regex().Matches(input);

    public static List<MashToken> Tokenize(string rawMash)
    {
        var tokens = new List<MashToken>();
        int currentLine = 1;
        int currentPos = 0;

        var regex = TokenRegex.Regex();
        var match = regex.Match(rawMash);

        while (match.Success)
        {
            if (MashEscaper.IsEscaped(rawMash, match.Index))
            {
                match = match.NextMatch();
                continue;
            }

            // Substring of everything between the end of the
            // last match and the start of the current match
            string between = rawMash[currentPos..match.Index];
            // Count and consume newline chars at the start of between
            var betweenLeadingNewlines = between.TakeWhile(c => c == '\n').Count();
            var bodyRaw = between[betweenLeadingNewlines..];

            if (!string.IsNullOrWhiteSpace(bodyRaw))
            {
                var bodyContent = bodyRaw.TrimEnd('\r', '\n');
                int bodyLine = currentLine + betweenLeadingNewlines;

                tokens.Add(new MashToken
                {
                    Type = MashTokenType.Body,
                    LineNumber = bodyLine,
                    Content = MashEscaper.Unescape(bodyContent)
                });

            }

            // Increment currentLine by number of newline chars in between
            currentLine += between.Count(c => c == '\n');

            var value = match.Groups["tag"].Value;
            var tagType = value.StartsWith('/')
                ? MashTokenType.TagClose
                : MashTokenType.TagOpen;

            tokens.Add(new MashToken
            {
                Type = tagType,
                LineNumber = currentLine,
                Content = value
            });

            currentPos = match.Index + match.Length;
            match = match.NextMatch();
        }


        string end = rawMash[currentPos..];
        var endLeadingNewlines = end.TakeWhile(c => c == '\n').Count();
        var endBodyRaw = end[endLeadingNewlines..];

        if (!string.IsNullOrWhiteSpace(endBodyRaw))
        {
            var endBodyContent = endBodyRaw.TrimEnd('\r', '\n');
            int endBodyLine = currentLine + endLeadingNewlines;

            tokens.Add(new MashToken
            {
                Type = MashTokenType.Body,
                LineNumber = endBodyLine,
                Content = MashEscaper.Unescape(endBodyContent)
            });

        }

        currentLine += end.Count(c => c == '\n');

        return tokens;
    }
}
