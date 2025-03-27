using Netmash.Shared.Blocks;
using Netmash.Shared.Common;
using Netmash.Shared.Interfaces;
using Netmash.Shared.Styling;
using Netmash.Shared.Utilities;

namespace Netmash.Shared.Mashes;

public class Mash : Entity, IStylable
{
    /*public Account Owner { get; }*/
    private string _name;
    public string Name
    {
        get => _name;
        set => SetName(value);
    }
    public List<BaseBlock> Blocks { get; set; } = [];
    public string DivId { get; set; } = IdGenerator.NewDivId();
    public HashSet<Style> Styles { get; set; } = [];

    public Mash(string name)
    {
        SetName(name);
    }

    private void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be blank.");
        if (name.Length > 100)
            throw new ArgumentException("Name cannot exceed 100 characters.");

        _name = name;
    }
}
