namespace Netmash.Core.Parsing;

public enum MashTokenType
{
    TagOpen,
    TagClose,
    Body
}

public record MashToken
{
    public required MashTokenType Type { get; init; }
    public required int LineNumber { get; init; }
    public required string Content { get; init; } = string.Empty;
}
