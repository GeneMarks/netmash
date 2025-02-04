namespace Netmash.Shared.Utilities;

using NanoidDotNet;

public static class IdGenerator
{
    public static string NewId() =>
        Nanoid.Generate(Nanoid.Alphabets.UppercaseLettersAndDigits, 14);

    public static string NewCssClass() =>
        Nanoid.Generate(Nanoid.Alphabets.UppercaseLettersAndDigits, 12);
}
