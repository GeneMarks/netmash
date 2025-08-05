namespace Netmash.Core.Parsing;

public record ParsedMash
{
    public required IReadOnlyList<Stack<Tag>> TagStacks { get; init; }
    public required IReadOnlyList<MashParseError> Errors { get; init; }
    public bool IsClean => Errors.Count == 0;
}
