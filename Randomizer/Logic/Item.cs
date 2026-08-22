namespace BB_Fog_Gate_Randomizer.Randomizer.Fog;

public class Item
{
    public string Name { get; }

    public Item(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }
}