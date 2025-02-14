using Netmash.Shared.Interfaces;
using Netmash.Shared.Models.Styling;
using Netmash.Shared.Utilities;

namespace Netmash.Shared.Models;

public abstract class BaseBlock : IStylable
{
    public string Id { get; } = IdGenerator.NewId();
    public abstract BlockType Type { get; }
    public StyleContainer Styles { get; } = new();
}
