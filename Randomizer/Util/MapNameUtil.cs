namespace BB_Fog_Gate_Randomizer.Randomizer.Util;

public class MapNameUtil
{
    public static int MapIdentifierToAreaId(string identifier)
    {
        if (identifier == "") return -1;
        return int.Parse(identifier.Substring(1, 2));
    }

    public static int MapIdentifierToBlockId(string identifier)
    {
        if (identifier == "") return -1;
        return int.Parse(identifier.Substring(4, 2));
    }
}