namespace Netmash.Core.Utilities;

using NanoidDotNet;

public static class IdGenerator
{
    public static string NewId(byte digits) =>
        Nanoid.Generate(Nanoid.Alphabets.UppercaseLettersAndDigits, digits);

    public static string NewDivId() =>
        Nanoid.Generate(Nanoid.Alphabets.UppercaseLettersAndDigits, 14);
}
