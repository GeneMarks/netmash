namespace Netmash.Core.Parsing;

public static class MashEscaper
{
    private const char EscapeChar = '\\';

    public static bool IsEscaped(string input, int index)
    {
        if (index <= 0 || index > input.Length) return false;

        int escapeCount = 0;
        int pos = index - 1;

        while (pos >= 0 && input[pos] == EscapeChar)
        {
            ++escapeCount;
            --pos;
        }

        return escapeCount % 2 != 0;
    }

    public static string Unescape(string input)
    {
        List<int> escapeCharIndexes = [];

        for (int i = 0; i < input.Length;)
        {
            if (input[i] == EscapeChar)
            {
                escapeCharIndexes.Add(i);
                if (i + 1 < input.Length && input[i + 1] == EscapeChar)
                    ++i;
            }

            ++i;
        }

        foreach (int index in escapeCharIndexes.OrderByDescending(i => i))
        {
            input = input.Remove(index, 1);
        }

        return input;
    }
}
