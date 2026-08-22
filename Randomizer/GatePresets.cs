using System.Collections.Generic;
using BB_Fog_Gate_Randomizer.Randomizer.Fog;

namespace BB_Fog_Gate_Randomizer.Randomizer;

public class GatePresets
{
    public static readonly List<FogGate> AllFogGates =
    [
        FogGates.WitchOfHemwickArenaEntrance,
        FogGates.WitchOfHemwickArenaExit,
        FogGates.WitchOfHemwickEntrance,
        FogGates.WitchOfHemwickExit,
        FogGates.WarpToCastleCainhurst,
        FogGates.MPGHemwickCharnelLaneHemwick,
        FogGates.MPGHemwickCharnelLaneCathedral,
        
        FogGates.BloodStarvedBeastArenaEntrance,
        FogGates.BloodStarvedBeastEntrance,
        FogGates.DarkbeastPaarlArenaEntrance,
        FogGates.DarkbeastPaarlEntrance,
        FogGates.DarkbeastPaarlArenaExit,
        FogGates.DarkbeastPaarlExit,
        FogGates.OldYharnamMPGToStaircase,
        FogGates.OldYharnamMPGToOldYharnam,
        
        FogGates.CathedralWardMPGToCathedralWard,
        FogGates.CathedralWardMPGToGascoigne,
        FogGates.VicarAmeliaArenaEntrance,
        FogGates.VicarAmeliaEntrance,
        FogGates.MPGBeforeOldYharnamLanternTowardsOldYharnam,
        FogGates.MPGBeforeOldYharnamLanternTowardsCathedralWard,
        FogGates.MPGBeforeSacrificalConnectionChurchCathedralWard,
        FogGates.MPGBeforeSacrificalConnectionChurchChurch,
        FogGates.MPGInfrontHemwickCharnelLaneCathedralWard,
        FogGates.MPGInfrontHemwickCharnelLaneHemwick,
        FogGates.WarpToOldHuntersDLC,
        
        FogGates.GascoigneArenaEntrance,
        FogGates.GascoigneEntrance,
        FogGates.GascoigneArenaExitMPG,
        FogGates.GascoigneExitMPG,
        FogGates.GateAfterIosefkasClinicToClinic,
        FogGates.GateAfterIosefkasClinicToFirstLamp,
        FogGates.ClericBeastArenaEntrance,
        FogGates.ClericBeastEntrance,
        
        FogGates.MPGUpperCathedralWardUpper,
        FogGates.MPGUpperCathedralCathedralWard,
        FogGates.EbrietasaArenaEntrance,
        FogGates.EbrietasaEntrance,
        FogGates.CelestialEmissaryArenaEntrance,
        FogGates.CelestialEmissaryEntrance,
        FogGates.CelestialEmissaryArenaExit,
        FogGates.CelestialEmissaryExit,
        
        FogGates.WarpFromCastleCainhurst,
        FogGates.MartyrLogariusArenaEntrance,
        FogGates.MartyrLogariusEntrance,
        
        FogGates.WarpBackToLectureBuilding,
        FogGates.WetNurseArenaEntrance,
        FogGates.WetNurseEntrance,
        FogGates.MicolashArenaEntrance,
        FogGates.MicolashEntrance,
        FogGates.MicolashArenaExitMetalGateEyeBridge,
        FogGates.MicolashExitMetalGateEyeBridge,
        
        FogGates.ShadowsOfYharnamArenaEntrance,
        FogGates.ShadowsOfYharnamEntrance,
        FogGates.ShadowsOfYharnamArenaExit,
        FogGates.ShadowsOfYharnamExit,
        FogGates.MPGWoodsEntranceToWoods,
        FogGates.MPGWoodsEntranceToYharnam,
        FogGates.MPGCaveToIosefkasClinicWoods,
        FogGates.MPGCaveToIosefkasClinicCave,
        
        FogGates.OneRebornArenaEntrance,
        FogGates.OneRebornEntrance,
        FogGates.OneRebornArenaExit,
        FogGates.OneRebornExit,
        FogGates.MPGYahargulEntranceYahargul,
        FogGates.MPGYahargulEntranceCathedralWard,
        FogGates.MPGHypogeanGoalPaarl,
        FogGates.MPGHypogeanGoalGoal,
        FogGates.WarpToLectureBuildingAfterOneReborn,
        FogGates.WarpToLectureBuildingLesserAmygdala,
        
        FogGates.MPGBeginningByrgenwerthWoods,
        FogGates.MPGBeginningByrgenwerthByrgenwerth,
        FogGates.RomArenaEntrance,
        FogGates.RomEntrance,
        FogGates.WarpToNightmareofMensis,
        FogGates.WarpBackToYahargulAfterOneReborn,
        FogGates.WarpBackToLesserAmygdala,
        FogGates.WarpToNightmareFrontier,
        
        FogGates.AmygdalaArenaEntrance,
        FogGates.AmygdalaEntrance,
        FogGates.AmygdalaArenaExit,
        FogGates.AmygdalaExit,
        FogGates.WarpFrontierBackToLectureBuilding,
        
        FogGates.LaurenceArenaEntrance,
        FogGates.LaurenceEntrance,
        FogGates.LudwigArenaEntrance,
        FogGates.LudwigEntrance,
        FogGates.LudwigArenaExit,
        FogGates.LudwigExit,
        FogGates.AddedWarpBackCathedralWard,
        
        FogGates.MPGAfterLudwigLudwig,
        FogGates.MPGAfterLudwigResearchHall,
        FogGates.LadyMariaArenaEntrance,
        FogGates.LadyMariaEntrance,
        FogGates.LivingFailiuresArenaEntrance,
        FogGates.LivingFailiuresEntrance,
        
        FogGates.OrphanofKosArenaEntrance,
        FogGates.OrphanofKosEntrance
    ];
    
    public static List<FogGate> AllFogGatesNoDlc =
    [
        FogGates.WitchOfHemwickArenaEntrance,
        FogGates.WitchOfHemwickArenaExit,
        FogGates.WitchOfHemwickEntrance,
        FogGates.WitchOfHemwickExit,
        FogGates.WarpToCastleCainhurst,
        FogGates.MPGHemwickCharnelLaneHemwick,
        FogGates.MPGHemwickCharnelLaneCathedral,
        
        FogGates.BloodStarvedBeastArenaEntrance,
        FogGates.BloodStarvedBeastEntrance,
        FogGates.DarkbeastPaarlArenaEntrance,
        FogGates.DarkbeastPaarlEntrance,
        FogGates.DarkbeastPaarlArenaExit,
        FogGates.DarkbeastPaarlExit,
        FogGates.OldYharnamMPGToStaircase,
        FogGates.OldYharnamMPGToOldYharnam,
        
        FogGates.CathedralWardMPGToCathedralWard,
        FogGates.CathedralWardMPGToGascoigne,
        FogGates.VicarAmeliaArenaEntrance,
        FogGates.VicarAmeliaEntrance,
        FogGates.MPGBeforeOldYharnamLanternTowardsOldYharnam,
        FogGates.MPGBeforeOldYharnamLanternTowardsCathedralWard,
        FogGates.MPGBeforeSacrificalConnectionChurchCathedralWard,
        FogGates.MPGBeforeSacrificalConnectionChurchChurch,
        FogGates.MPGInfrontHemwickCharnelLaneCathedralWard,
        FogGates.MPGInfrontHemwickCharnelLaneHemwick,
        
        FogGates.GascoigneArenaEntrance,
        FogGates.GascoigneEntrance,
        FogGates.GascoigneArenaExitMPG,
        FogGates.GascoigneExitMPG,
        FogGates.GateAfterIosefkasClinicToClinic,
        FogGates.GateAfterIosefkasClinicToFirstLamp,
        FogGates.ClericBeastArenaEntrance,
        FogGates.ClericBeastEntrance,
        
        FogGates.MPGUpperCathedralWardUpper,
        FogGates.MPGUpperCathedralCathedralWard,
        FogGates.EbrietasaArenaEntrance,
        FogGates.EbrietasaEntrance,
        FogGates.CelestialEmissaryArenaEntrance,
        FogGates.CelestialEmissaryEntrance,
        FogGates.CelestialEmissaryArenaExit,
        FogGates.CelestialEmissaryExit,
        
        FogGates.WarpFromCastleCainhurst,
        FogGates.MartyrLogariusArenaEntrance,
        FogGates.MartyrLogariusEntrance,
        
        FogGates.WarpBackToLectureBuilding,
        FogGates.WetNurseArenaEntrance,
        FogGates.WetNurseEntrance,
        FogGates.MicolashArenaEntrance,
        FogGates.MicolashEntrance,
        FogGates.MicolashArenaExitMetalGateEyeBridge,
        FogGates.MicolashExitMetalGateEyeBridge,
        
        FogGates.ShadowsOfYharnamArenaEntrance,
        FogGates.ShadowsOfYharnamEntrance,
        FogGates.ShadowsOfYharnamArenaExit,
        FogGates.ShadowsOfYharnamExit,
        FogGates.MPGWoodsEntranceToWoods,
        FogGates.MPGWoodsEntranceToYharnam,
        FogGates.MPGCaveToIosefkasClinicWoods,
        FogGates.MPGCaveToIosefkasClinicCave,
        
        FogGates.OneRebornArenaEntrance,
        FogGates.OneRebornEntrance,
        FogGates.OneRebornArenaExit,
        FogGates.OneRebornExit,
        FogGates.MPGYahargulEntranceYahargul,
        FogGates.MPGYahargulEntranceCathedralWard,
        FogGates.MPGHypogeanGoalPaarl,
        FogGates.MPGHypogeanGoalGoal,
        FogGates.WarpToLectureBuildingAfterOneReborn,
        FogGates.WarpToLectureBuildingLesserAmygdala,
        
        FogGates.MPGBeginningByrgenwerthWoods,
        FogGates.MPGBeginningByrgenwerthByrgenwerth,
        FogGates.RomArenaEntrance,
        FogGates.RomEntrance,
        FogGates.WarpToNightmareofMensis,
        FogGates.WarpBackToYahargulAfterOneReborn,
        FogGates.WarpBackToLesserAmygdala,
        FogGates.WarpToNightmareFrontier,
        
        FogGates.AmygdalaArenaEntrance,
        FogGates.AmygdalaEntrance,
        FogGates.AmygdalaArenaExit,
        FogGates.AmygdalaExit,
        FogGates.WarpFrontierBackToLectureBuilding,
        
    ];

    public static readonly List<FogGate> BossGatesOnlyNoDlc =
    [
        FogGates.ClericBeastArenaEntrance,
        FogGates.ClericBeastEntrance,
        
        FogGates.GascoigneArenaEntrance,
        FogGates.GascoigneEntrance,
        
        FogGates.VicarAmeliaArenaEntrance,
        FogGates.VicarAmeliaEntrance,
        
        FogGates.BloodStarvedBeastArenaEntrance,
        FogGates.BloodStarvedBeastEntrance,
        
        FogGates.WitchOfHemwickArenaEntrance,
        FogGates.WitchOfHemwickArenaExit,
        FogGates.WitchOfHemwickExit,
        FogGates.WitchOfHemwickEntrance,
        
        FogGates.ShadowsOfYharnamArenaEntrance,
        FogGates.ShadowsOfYharnamArenaExit,
        FogGates.ShadowsOfYharnamEntrance,
        FogGates.ShadowsOfYharnamExit,
        
        FogGates.RomArenaEntrance,
        FogGates.RomEntrance,
        
        FogGates.DarkbeastPaarlArenaEntrance,
        FogGates.DarkbeastPaarlArenaExit,
        FogGates.DarkbeastPaarlEntrance,
        FogGates.DarkbeastPaarlExit,
        
        FogGates.OneRebornArenaEntrance,
        FogGates.OneRebornArenaExit,
        FogGates.OneRebornEntrance,
        FogGates.OneRebornExit,
        
        FogGates.AmygdalaArenaEntrance,
        FogGates.AmygdalaArenaExit,
        FogGates.AmygdalaEntrance,
        FogGates.AmygdalaExit,
        
        FogGates.MicolashArenaEntrance,
        FogGates.MicolashArenaExitMetalGateEyeBridge,
        FogGates.MicolashEntrance,
        FogGates.MicolashExitMetalGateEyeBridge,
        
        FogGates.WetNurseArenaEntrance,
        FogGates.WetNurseEntrance,
        
        FogGates.CelestialEmissaryArenaEntrance,
        FogGates.CelestialEmissaryArenaExit,
        FogGates.CelestialEmissaryEntrance,
        FogGates.CelestialEmissaryExit,
        
        FogGates.EbrietasaEntrance,
        FogGates.EbrietasaArenaEntrance,
        
        FogGates.MartyrLogariusArenaEntrance,
        FogGates.MartyrLogariusEntrance,
    ];
    
    public static readonly List<FogGate> BossGatesOnly =
    [
        FogGates.ClericBeastArenaEntrance,
        FogGates.ClericBeastEntrance,
        
        FogGates.GascoigneArenaEntrance,
        FogGates.GascoigneEntrance,
        
        FogGates.VicarAmeliaArenaEntrance,
        FogGates.VicarAmeliaEntrance,
        
        FogGates.BloodStarvedBeastArenaEntrance,
        FogGates.BloodStarvedBeastEntrance,
        
        FogGates.WitchOfHemwickArenaEntrance,
        FogGates.WitchOfHemwickArenaExit,
        FogGates.WitchOfHemwickExit,
        FogGates.WitchOfHemwickEntrance,
        
        FogGates.ShadowsOfYharnamArenaEntrance,
        FogGates.ShadowsOfYharnamArenaExit,
        FogGates.ShadowsOfYharnamEntrance,
        FogGates.ShadowsOfYharnamExit,
        
        FogGates.RomArenaEntrance,
        FogGates.RomEntrance,
        
        FogGates.DarkbeastPaarlArenaEntrance,
        FogGates.DarkbeastPaarlArenaExit,
        FogGates.DarkbeastPaarlEntrance,
        FogGates.DarkbeastPaarlExit,
        
        FogGates.OneRebornArenaEntrance,
        FogGates.OneRebornArenaExit,
        FogGates.OneRebornEntrance,
        FogGates.OneRebornExit,
        
        FogGates.AmygdalaArenaEntrance,
        FogGates.AmygdalaArenaExit,
        FogGates.AmygdalaEntrance,
        FogGates.AmygdalaExit,
        
        FogGates.MicolashArenaEntrance,
        FogGates.MicolashArenaExitMetalGateEyeBridge,
        FogGates.MicolashEntrance,
        FogGates.MicolashExitMetalGateEyeBridge,
        
        FogGates.WetNurseArenaEntrance,
        FogGates.WetNurseEntrance,
        
        FogGates.CelestialEmissaryArenaEntrance,
        FogGates.CelestialEmissaryArenaExit,
        FogGates.CelestialEmissaryEntrance,
        FogGates.CelestialEmissaryExit,
        
        FogGates.EbrietasaEntrance,
        FogGates.EbrietasaArenaEntrance,
        
        FogGates.MartyrLogariusArenaEntrance,
        FogGates.MartyrLogariusEntrance,
        
        FogGates.LudwigArenaEntrance,
        FogGates.LudwigArenaExit,
        FogGates.LudwigEntrance,
        FogGates.LudwigExit,
        
        FogGates.LaurenceArenaEntrance,
        FogGates.LaurenceEntrance,
        
        FogGates.LivingFailiuresArenaEntrance,
        FogGates.LivingFailiuresEntrance,
        
        FogGates.LadyMariaArenaEntrance,
        FogGates.LadyMariaEntrance,
        
        FogGates.OrphanofKosArenaEntrance,
        FogGates.OrphanofKosEntrance,
    ];
}