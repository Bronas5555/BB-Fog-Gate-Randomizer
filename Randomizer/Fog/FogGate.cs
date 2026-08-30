using System.Collections.Generic;
using BB_Fog_Gate_Randomizer.Emevd;
using BB_Fog_Gate_Randomizer.Randomizer.Fog;
using BB_Fog_Gate_Randomizer.Randomizer.Scaling;

namespace BB_Fog_Gate_Randomizer.Randomizer.Fog;

public class FogGate
{
    public string            Name;
    public int               SpawnPointEntityId;
    public int               InteractionObjectEntityId;
    public MapName           MapName;
    public List<Requirement> Requirements;
    public List<Requirement> Rewards;
    public WarpEventType     WarpEventType;
    public int               RequiredEventFlag;
    public List<ParamBoss>?  ParamBosses;

    //All Fog Gates which can be reached by walking from this Fog Gate
    //Can still be inaccessible due to Requirements
    public List<FogGate> WalkNeighbours = new();

    //Randomized Warp Destination
    public FogGate? LinkedFogGate;

    public FogGate(
        string name, 
        int spawnPointEntityId, 
        int interactionObjectEntityId, 
        MapName mapName,
        WarpEventType warpEventType = WarpEventType.FogGate,
        int requiredEventFlag = -1,
        List<ParamBoss>? paramBosses = null)
    {
        Name = name;
        SpawnPointEntityId = spawnPointEntityId;
        InteractionObjectEntityId = interactionObjectEntityId;
        Requirements = new();
        Rewards = new();
        WarpEventType = warpEventType;
        MapName = mapName;
        ParamBosses = paramBosses;
        RequiredEventFlag = requiredEventFlag;
    }

    public FogGate(
        string name, 
        int spawnPointEntityId, 
        int interactionObjectEntityId, 
        List<Requirement> requirements, 
        List<Requirement> rewards,
        MapName mapName,
        WarpEventType warpEventType = WarpEventType.FogGate,
        int requiredEventFlag = -1,
        List<ParamBoss>? paramBoses = null)
    {
        Name = name;
        SpawnPointEntityId = spawnPointEntityId;
        InteractionObjectEntityId = interactionObjectEntityId;
        Requirements = requirements;
        Rewards = rewards;
        WarpEventType = warpEventType;
        MapName = mapName;
        ParamBosses = paramBoses;
        RequiredEventFlag = requiredEventFlag;
    }
    
    public bool IsAccessible(PlayerState player)
    {
        foreach(var req in Requirements)
        {
            if(!req.IsMet(player))
                return false;
        }

        return true;
    }

    public void SetupWalkNeighbours(List<FogGate> walkNeighbours)
    {
        WalkNeighbours = walkNeighbours;
    }
    
    public void Link(FogGate other)
    {
        LinkedFogGate = other;
        other.LinkedFogGate = this;
    }
}