using Netmash.Shared.Styling;

namespace Netmash.Shared.Interfaces;

public interface IStylable
{
    public StyleContainer Styles { get; }

    public void RegisterStyles(CssGenerator cssGenerator) =>
        cssGenerator.RegisterStyles(Styles);
    public void UnregisterStyles(CssGenerator cssGenerator) =>
        cssGenerator.UnregisterStyles(Styles);
}
