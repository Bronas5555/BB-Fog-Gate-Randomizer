using System.Collections.Generic;
using System.Linq;

namespace BB_Fog_Gate_Randomizer.Randomizer.Fog;

public class Requirement
{
    public RequirementType Type { get; }

    public Item Item { get; }
    public string Value { get; }

    private List<Requirement> _additionalRequirements;
    
    public Requirement(Item item)
    {
        Type = RequirementType.Item;
        Item = item;
        _additionalRequirements = new();
    }
    public Requirement(Item item, List<Requirement> additionalRequirements)
    {
        Type = RequirementType.Item;
        Item = item;
        _additionalRequirements = additionalRequirements;
    }
    
    public Requirement(RequirementType type, string value)
    {
        Type = type;
        Value = value;
        _additionalRequirements = new();
    }
    
    public bool IsMet(PlayerState player)
    {
        switch(Type)
        {
            case RequirementType.Item:
                return player.Items.Contains(Item) && _additionalRequirements.All(requirement => requirement.IsMet(player));
            
            case RequirementType.BossDefeated:
                return player.DefeatedBosses.Contains(Value) && _additionalRequirements.All(requirement => requirement.IsMet(player));
            
            case RequirementType.WorldState:
                return player.WorldStates.Contains(Value) && _additionalRequirements.All(requirement => requirement.IsMet(player));
        }
        return false;
    }

    public override string ToString()
    {
        switch(Type)
        {
            case RequirementType.Item: return Item.Name;
            case RequirementType.BossDefeated: return Value;
            case RequirementType.WorldState: return Value;
        }

        return "Error, Unknown RequirementType";
    }
}

public enum RequirementType
{
    Item,
    BossDefeated,
    WorldState
}