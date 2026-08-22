using System.Collections.Generic;

namespace BB_Fog_Gate_Randomizer.Randomizer.Fog;

public class PlayerState
{
    public HashSet<Item>   Items          { get; } = new();
    public HashSet<string> DefeatedBosses { get; } = new();

    public HashSet<string> WorldStates { get; } = new();

    public PlayerState()
    { }

    public PlayerState(PlayerState other)
    {
        Items = new HashSet<Item>(other.Items);
        DefeatedBosses = new HashSet<string>(other.DefeatedBosses);
    }

    public void Collect(FogGate gate)
    {
        foreach (var item in gate.Rewards)
        {
            switch (item.Type)
            {
                case RequirementType.Item : Items.Add(item.Item); break;
                case RequirementType.BossDefeated : DefeatedBosses.Add(item.Value); break;
                case RequirementType.WorldState : WorldStates.Add(item.Value); break;
            }
        }
            
    }

    public PlayerState Clone()
    {
        return new PlayerState(this);
    }
}