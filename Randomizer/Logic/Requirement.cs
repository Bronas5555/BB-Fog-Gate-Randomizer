using System.Collections.Generic;
using System.Linq;

namespace BB_Fog_Gate_Randomizer.Randomizer.Fog;

public class Requirement
{
    public RequirementType Type { get; }

    public Item Item { get; }
    public string Value { get; }
    private RequirementLogicType _logicType;

    private List<Requirement> _additionalRequirements;
    
    public Requirement(Item item)
    {
        Type = RequirementType.Item;
        Item = item;
        _additionalRequirements = new();
    }
    public Requirement(Item item, List<Requirement> additionalRequirements, RequirementLogicType logicType)
    {
        Type = RequirementType.Item;
        Item = item;
        _additionalRequirements = additionalRequirements;
        _logicType = logicType;
    }
    
    public Requirement(RequirementType type, string value)
    {
        Type = type;
        Value = value;
        _additionalRequirements = new();
    }
    
    public bool IsMet(PlayerState player)
    {
        if (_logicType == RequirementLogicType.AND)
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
        if (_logicType == RequirementLogicType.OR)
        {
            switch(Type)
            {
                case RequirementType.Item:
                    return player.Items.Contains(Item) || _additionalRequirements.Any(requirement => requirement.IsMet(player));
            
                case RequirementType.BossDefeated:
                    return player.DefeatedBosses.Contains(Value) || _additionalRequirements.Any(requirement => requirement.IsMet(player));
            
                case RequirementType.WorldState:
                    return player.WorldStates.Contains(Value) || _additionalRequirements.Any(requirement => requirement.IsMet(player));
            }
            return false;
        }
        throw new System.NotImplementedException("Not implemented Logic Type");
    }

    public override string ToString()
    {
        string result = "";
        switch(Type)
        {
            case RequirementType.Item: result += Item.Name; break;
            case RequirementType.BossDefeated: result += Value; break;
            case RequirementType.WorldState: result += Value; break;
        }

        foreach (var additionalRequirement in _additionalRequirements)
        {
            if (_logicType == RequirementLogicType.AND)
            {
                result += " and " + additionalRequirement.ToString();
            }
            else if (_logicType == RequirementLogicType.OR)
            {
                result += " or " + additionalRequirement.ToString();
            }
        }

        if (result != "") return result;
        return "Error, Unknown RequirementType";
    }
}

public enum RequirementType
{
    Item,
    BossDefeated,
    WorldState
}

public enum RequirementLogicType
{
    AND,
    OR
}