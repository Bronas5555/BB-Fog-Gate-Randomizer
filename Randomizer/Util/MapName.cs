using BB_Fog_Gate_Randomizer.Randomizer.Util;

namespace BB_Fog_Gate_Randomizer.Randomizer;

public class MapName
{
    public string Identifier;
    public int AreaId;
    public int BlockId;
    public string Name;

    public MapName(string identifier, string name)
    {
        Identifier = identifier;
        Name = name;
        
        AreaId = MapNameUtil.MapIdentifierToAreaId(Identifier);
        BlockId = MapNameUtil.MapIdentifierToBlockId(Identifier);
    }
}