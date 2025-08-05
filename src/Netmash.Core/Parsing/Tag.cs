namespace Netmash.Core.Parsing;

public enum TagType
{
    meta,
    global,
    block,
    link,
    style
}

public record Tag
{
    public required TagType TagType { get; init; }
    public required string SubTag { get; init; }
    public required Dictionary<string, string> Attributes { get; init; }
    public required string Content { get; init; }
};
