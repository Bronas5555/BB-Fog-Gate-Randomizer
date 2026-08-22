using System;
using System.Collections.Generic;
using BB_Fog_Gate_Randomizer.Randomizer.Fog;

namespace BB_Fog_Gate_Randomizer.Randomizer.Util;

public class TreeUtil
{
    public static int GetDepth(FogGate startGate)
    {
        return GetDepth(startGate, new HashSet<FogGate>());
    }

    private static int GetDepth(FogGate gate, HashSet<FogGate> path)
    {
        if (gate == null) return 0;

        if (!path.Add(gate)) return 0;

        int maxDepth = 0;

        foreach (var child in gate.LinkedFogGate.WalkNeighbours)
        {
            maxDepth = Math.Max(maxDepth, GetDepth(child, path));
        }

        path.Remove(gate);
        
        return 1 + maxDepth;
    }
}