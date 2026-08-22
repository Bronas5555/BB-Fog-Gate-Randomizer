namespace BB_Fog_Gate_Randomizer.Randomizer.Fog;

public class Requirements
{
    public static readonly Requirement CainhurstSummons = new Requirement(new Item("Cainhurst Summons"));
    public static readonly Requirement RomDefeated = new Requirement(RequirementType.BossDefeated, "RomDefeated");
    public static readonly Requirement UpperCathedralWardKey = new Requirement(new Item("UpperCathedralWardKey"));
    public static readonly Requirement VicarAmeliaDefeated = new Requirement(RequirementType.BossDefeated, "VicarAmeliaDefeated");
    public static readonly Requirement ForbiddenWoodsAccess = new Requirement(RequirementType.WorldState, "ForbiddenWoodsAccess");
    public static readonly Requirement TonsilStoneObtained = new Requirement(new Item("TonsilStone"), [ForbiddenWoodsAccess]);
    public static readonly Requirement WitchOfHemwickDefeated = new Requirement(RequirementType.WorldState, "WitchOfHemwickDefeated");
    public static readonly Requirement EyePendant = new Requirement(new Item("EyePendant"));

}