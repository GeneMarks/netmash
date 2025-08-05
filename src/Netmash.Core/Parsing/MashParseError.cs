namespace Netmash.Core.Parsing;

public enum MashParseErrorType
{
    MashMetaNotFound,
    MissingClosingTag,
    NestedBlockNotAllowed,
    StyleTagWithoutTarget,
    UnknownTagType
}

public record MashParseError
{
    public required MashParseErrorType ErrorType { get; init; }
    public required int LineNumber { get; init; }
    public required string? ContextLine { get; init; } = null;
    public string Message => ErrorType.GetErrorMessage(LineNumber);
}
