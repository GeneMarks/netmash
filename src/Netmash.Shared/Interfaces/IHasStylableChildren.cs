using Netmash.Shared.Styling;

namespace Netmash.Shared.Interfaces;

public interface IHasStylableChildren
{
    public void UnregisterWithChildren(CssGenerator cssGenerator);
}
