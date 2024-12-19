namespace Mishmash.Shared.Models;

public class Mash
{
    public readonly Account Owner { get; }
    public string Name { get; set; }
    public MashAppearance Appearance { get; set; }
    public List<Block> Blocks { get; set; }

    public Mash(Account owner, string name, MashAppearance appearance, List<Block> blocks)
    {
        Owner = owner;
        Name = name;
        Appearance = appearance;
        Blocks = blocks;
    }
}
