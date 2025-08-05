namespace Netmash.Core.Parsing;

public static class MashParseErrorTypeExtensions
{
    public static string GetErrorMessage(this MashParseErrorType type, int lineNumber)
    {
        string message = type switch
        {
            MashParseErrorType.MashMetaNotFound => "Mash header not found",
            MashParseErrorType.MissingClosingTag => "Missing closing tag",
            MashParseErrorType.NestedBlockNotAllowed => "Nested block not allowed",
            MashParseErrorType.StyleTagWithoutTarget => "Style tag is missing style target",
            MashParseErrorType.UnknownTagType => "Unknown tag type",
            _ => "Unknown error when parsing Mash"
        };

        return $"Line {lineNumber}: {message}";
    }
}
