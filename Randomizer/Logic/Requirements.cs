namespace BB_Fog_Gate_Randomizer.Randomizer.Fog;

public class Requirements
{
    public static readonly Requirement CainhurstSummons = 
        new Requirement(Items.CainhurstSummons);
    public static readonly Requirement RomDefeated = 
        new Requirement(RequirementType.BossDefeated, "RomDefeated");
    public static readonly Requirement UpperCathedralWardKey = 
        new Requirement(Items.UpperCathedralWardKey);
    public static readonly Requirement VicarAmeliaDefeated = 
        new Requirement(RequirementType.BossDefeated, "VicarAmeliaDefeated");
    public static readonly Requirement ForbiddenWoodsAccess = 
        new Requirement(RequirementType.WorldState, "ForbiddenWoodsAccess");
    public static readonly Requirement TonsilStoneObtained = 
        new Requirement(Items.TonsilStone, [ForbiddenWoodsAccess], RequirementLogicType.AND);
    public static readonly Requirement WitchOfHemwickDefeated = 
        new Requirement(RequirementType.WorldState, "WitchOfHemwickDefeated");
    public static readonly Requirement EyePendant = 
        new Requirement(Items.EyePendant);
    public static readonly Requirement BloodStarvedBeastDefeated = 
        new Requirement(RequirementType.BossDefeated, "BloodStarvedBeastDefeated");
    public static readonly Requirement InnerCathedralWardAccess = 
        new Requirement(Items.HunterChiefEmblem, [BloodStarvedBeastDefeated], RequirementLogicType.OR);
    public static readonly Requirement HunterChiefEmblem =
        new Requirement(Items.HunterChiefEmblem);


}