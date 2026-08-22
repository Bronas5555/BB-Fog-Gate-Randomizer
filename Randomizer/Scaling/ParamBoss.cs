using System.Collections.Generic;
using BB_Fog_Gate_Randomizer.Util;

namespace BB_Fog_Gate_Randomizer.Randomizer.Scaling;

public class ParamBoss
{
    public int NpcId;
    public List<NumberSpan> NpcAttackIds;
    public string Name;
    public int Hp;
    public int ScalingTier;
    
    public ParamBoss(int npcId, List<NumberSpan> npcAttackIds, string name, int hp, int scalingTier)
    {
        NpcId = npcId;
        NpcAttackIds = npcAttackIds;
        Name = name;
        Hp = hp;
        ScalingTier = scalingTier;
    }
}