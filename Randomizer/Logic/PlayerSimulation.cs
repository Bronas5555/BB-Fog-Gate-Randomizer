using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace BB_Fog_Gate_Randomizer.Randomizer.Fog;

public class PlayerSimulation
{
    public static bool IsValid(FogGate startGate)
    {
        return 
            ValidateNode(startGate, startGate, new HashSet<FogGate>());
    }

    private static bool ValidateNode(FogGate node, FogGate root, HashSet<FogGate> visited)
    {
        if (!visited.Add(node)) return true;
        
        foreach (var requirement in node.Requirements)
        {
            if (!ExistsProviderOutsideSubtree(root, node, requirement, new HashSet<FogGate>()))
            {
                return false;
            }
        }

        foreach (var child in GetChildren(node))
        {
            if (!ValidateNode(child, root, visited))
            {
                return false;
            }
        }

        return true;
    }

    private static bool ExistsProviderOutsideSubtree(
        FogGate current,
        FogGate excluded,
        Requirement requirement,
        HashSet<FogGate> visited)
    {

        if (!visited.Add(current)) return false;
        
        // Do not look inside the node that has the requirement.
        if (ReferenceEquals(current, excluded))
            return false;

        if (current.Rewards.Contains(requirement))
            return true;

        foreach (var child in GetChildren(current))
        {
            if (ExistsProviderOutsideSubtree(child, excluded, requirement, visited))
                return true;
        }

        return false;
    }
    private static IEnumerable<FogGate> GetChildren(FogGate node)
    {
        if (node.LinkedFogGate == null)
            yield break;

        foreach (var child in node.LinkedFogGate.WalkNeighbours)
            yield return child;
    }
}