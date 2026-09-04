using System.Collections.Generic;
using System.Linq;
using BB_Fog_Gate_Randomizer.Emevd;
using BB_Fog_Gate_Randomizer.Randomizer.Scaling;

namespace BB_Fog_Gate_Randomizer.Randomizer.Fog;

public static class FogGates
{
    //m21_00_00_00 Hunter's Dream
    //Fog Gate to Gherman isn't randomized
    
    //m22_00_00_00 Hemwick Charnel Lane (7)
    public static FogGate WitchOfHemwickArenaEntrance = new FogGate("Witch of Hemwick Arena Entrance", 2270000, 2271800, [], [Requirements.WitchOfHemwickDefeated], Maps.HemwickCharnelLane, WarpEventType.FogGateEventFlag, 12201800, [Bosses.WitchofHemwick1, Bosses.WitchofHemwick2]);
    public static FogGate WitchOfHemwickArenaExit = new FogGate("Witch of Hemwick Arena Exit", 2270001, 2271801, [], [Requirements.WitchOfHemwickDefeated], Maps.HemwickCharnelLane, WarpEventType.FogGateEventFlag, 12201800,  [Bosses.WitchofHemwick1, Bosses.WitchofHemwick2]);
    public static FogGate WitchOfHemwickEntrance = new FogGate("Witch of Hemwick Entrance", 2270002, 2201800, [], [Requirements.TonsilStoneObtained], Maps.HemwickCharnelLane);
    public static FogGate WitchOfHemwickExit = new FogGate("Witch of Hemwick Exit", 2270003, 2201801, [], [], Maps.HemwickCharnelLane);
    public static FogGate WarpToCastleCainhurst = 
        new FogGate("Warp to Castle Cainhurst", 2270004, 2201300,
            [Requirements.CainhurstSummons, Requirements.WitchOfHemwickDefeated], 
            [Requirements.TonsilStoneObtained], 
            Maps.HemwickCharnelLane, WarpEventType.CastleCainhurtsWarp);
    public static FogGate MPGHemwickCharnelLaneHemwick = 
        new FogGate("MPG At Door Entrance Hemwick Charnel Lane towards Hemwick.", 2270005, 2201999, Maps.HemwickCharnelLane);
    public static FogGate MPGHemwickCharnelLaneCathedral = 
        new FogGate("MPG At Door Entrance Hemwick Charnel Lane towards Cathedral Ward.", 2270006, 2271999, Maps.HemwickCharnelLane);
    
    //m23_00_00_01 Old Yharnam (8)
    public static FogGate BloodStarvedBeastArenaEntrance = new FogGate("Blood Starved Beast Arena Entrance", 2370999, 2301801, [], [Requirements.BloodStarvedBeastDefeated], Maps.OldYharnam, WarpEventType.FogGateEventFlag, 12301800, [Bosses.BloodStarvedBeast1, Bosses.BloodStarvedBeast2]);
    public static FogGate BloodStarvedBeastEntrance = new FogGate("Blood Starved Beast Entrance", 2375999, 2301800, Maps.OldYharnam);
    public static FogGate DarkbeastPaarlArenaEntrance = new FogGate("Darkbeast Paarl Arena Entrance", 2375998, 2301812, Maps.OldYharnam, WarpEventType.FogGateEventFlag, 12301700, [Bosses.DarkbeastPaarl]);
    public static FogGate DarkbeastPaarlEntrance = new FogGate("Darkbeast Paarl Entrance", 2375997, 2301810, Maps.OldYharnam);
    public static FogGate DarkbeastPaarlArenaExit = new FogGate("Darkbeast Paarl Arena Exit", 2375996, 2301811, Maps.OldYharnam, WarpEventType.FogGateEventFlag, 12301700, [Bosses.DarkbeastPaarl]);
    public static FogGate DarkbeastPaarlExit = new FogGate("Darkbeast Paarl Exit", 2375995, 2301813, Maps.OldYharnam);
    public static FogGate OldYharnamMPGToStaircase = 
        new FogGate("Old Yharnam MPG To Staircase", 2300994, 2301999, Maps.OldYharnam);
    public static FogGate OldYharnamMPGToOldYharnam = new FogGate("Old Yharnam MPG To Old Yharnam", 2300999, 2301998, Maps.OldYharnam);
    
    //m24_00_00_01 Cathedral Ward (11)
    public static FogGate CathedralWardMPGToCathedralWard = new FogGate("Cathedral Ward MPG To Cathedral Ward", 2407999, 2471999, [], [Requirements.TonsilStoneObtained], Maps.CathedralWard);
    public static FogGate CathedralWardMPGToGascoigne = new FogGate("Cathedral Ward MPG To Gascoigne", 2407998, 2401999, Maps.CathedralWard);
    public static FogGate VicarAmeliaArenaEntrance = new FogGate("Vicar Amelia Arena Entrance", 2407997, 2471800, [], [Requirements.VicarAmeliaDefeated], Maps.CathedralWard, WarpEventType.FogGateEventFlag, 12401800, [Bosses.VicarAmelia]);
    public static FogGate VicarAmeliaEntrance = new FogGate("Vicar Amelia Entrance", 2407996, 2401800, [Requirements.BloodStarvedBeastDefeated], [Requirements.TonsilStoneObtained], Maps.CathedralWard);
    public static FogGate MPGBeforeOldYharnamLanternTowardsOldYharnam =
        new FogGate("MPG Before Old Yharnam Lantern Towards Old Yharnam", 2407994, 2401997, Maps.CathedralWard);
    public static FogGate MPGBeforeOldYharnamLanternTowardsCathedralWard =
        new FogGate("MPG Before Old Yharnam Lantern Towards Cathedral Ward", 2407995, 2471997, [], [], Maps.CathedralWard);
    public static FogGate MPGBeforeSacrificalConnectionChurchCathedralWard = 
        new FogGate("MPG before Church Before Yahar'gul towards Cathedral Ward", 2407993, 2471996, [Requirements.BloodStarvedBeastDefeated], [Requirements.TonsilStoneObtained], Maps.CathedralWard);
    public static FogGate MPGBeforeSacrificalConnectionChurchChurch = 
        new FogGate("MPG before Church Before Yahar'gul towards Church", 2407992, 2401996, [], [], Maps.CathedralWard);
    public static FogGate MPGInfrontHemwickCharnelLaneCathedralWard = 
        new FogGate("MPG Infront Hemwick Charnel Lane, towards Cathedral Ward", 2407991, 2471995, [Requirements.BloodStarvedBeastDefeated], [Requirements.TonsilStoneObtained], Maps.CathedralWard);
    public static FogGate MPGInfrontHemwickCharnelLaneHemwick = 
        new FogGate("MPG Infront Hemwick Charnel Lane, towards Hemwick Charnel Lane", 2407990, 2401995, Maps.CathedralWard);
    public static FogGate WarpToOldHuntersDLC = new FogGate("Warp to Old Hunters DLC", 2407989, 2401994, [Requirements.VicarAmeliaDefeated], [], Maps.CathedralWard, WarpEventType.DLCWarp);
    
    //m24_01_00_01 Central Yaharnam (8)
    public static FogGate GascoigneArenaEntrance = new FogGate("Gascoigne Arena Entrance", 2490998, 2491810, Maps.CentralYharnam, WarpEventType.FogGateEventFlag, 12411800, [Bosses.Gascoigne1, Bosses.Gascoigne2]);
    public static FogGate GascoigneEntrance = new FogGate("Gascoigne Entrance", 2490999, 2411810, [], [Requirements.TonsilStoneObtained], Maps.CentralYharnam);
    public static FogGate GascoigneArenaExitMPG = 
        new FogGate("Gascoigne Arena Exit MPG", 2491010, 2491820, Maps.CentralYharnam);
    public static FogGate GascoigneExitMPG = 
        new FogGate("Gascoige Exit MPG", 2491020, 2411997, Maps.CentralYharnam);
    public static FogGate GateAfterIosefkasClinicToClinic =
        new FogGate("Metal Gate after Iosefkas Clinic Clinic Side", 2491030, 2491811, Maps.CentralYharnam);
    public static FogGate GateAfterIosefkasClinicToFirstLamp =
        new FogGate("Metal Gate after Iosefkas Clinic Towards First Lamp", 2491031, 2491812, [], [Requirements.TonsilStoneObtained], Maps.CentralYharnam);
    public static FogGate ClericBeastArenaEntrance = new FogGate("Cleric Beast Arena Entrance", 2490997, 2417800, Maps.CentralYharnam, WarpEventType.FogGateEventFlag, 12411700, [Bosses.ClericBeast1, Bosses.ClericBeast2]);
    public static FogGate ClericBeastEntrance = new FogGate("Cleric Beast Entrance", 2490996, 2411800, [], [Requirements.TonsilStoneObtained], Maps.CentralYharnam);

    //m24_02_00_01 Upper Cathedral Ward (8)
    public static FogGate MPGUpperCathedralWardUpper = 
        new FogGate("MPG Upper Cathedral Ward towards Upper Cathedral Ward", 2420997, 2427999, Maps.UpperCathedralWard, WarpEventType.FogGate, -1, [Bosses.OrphanageKeyBrainSucker1, Bosses.OrphanageKeyBrainSucker2]);
    public static FogGate MPGUpperCathedralCathedralWard = 
        new FogGate("MPG Upper Cathedral Ward towards Cathedral Ward", 2420996 , 2421999, [Requirements.UpperCathedralWardKey], [], Maps.UpperCathedralWard);
    public static FogGate EbrietasaArenaEntrance = new FogGate("Ebrietas Arena Entrance", 2420995, 2421801, Maps.UpperCathedralWard, WarpEventType.FogGateEventFlag, 12421800, [Bosses.Ebrietas]);
    public static FogGate EbrietasaEntrance = new FogGate("Ebrietas Entrance", 2420994, 2421800, Maps.UpperCathedralWard);
    public static FogGate CelestialEmissaryArenaEntrance = 
        new FogGate("Celestial Emissary Arena Entrance", 2420993, 2421702, Maps.UpperCathedralWard, WarpEventType.FogGateEventFlag, 12421700, [Bosses.CelestialEmissary1, Bosses.CelestialEmissary2, Bosses.CelestialEmissary3, Bosses.CelestialEmissary4]);
    public static FogGate CelestialEmissaryEntrance = 
        new FogGate("Celestial Emissary Entrance", 2420992, 2421700, Maps.UpperCathedralWard);
    public static FogGate CelestialEmissaryArenaExit = 
        new FogGate("Celestial Emissary Arena Exit", 2420991, 2421701, Maps.UpperCathedralWard, WarpEventType.FogGateEventFlag, 12421700, [Bosses.CelestialEmissary1, Bosses.CelestialEmissary2, Bosses.CelestialEmissary3, Bosses.CelestialEmissary4]);
    public static FogGate CelestialEmissaryExit = 
        new FogGate("Celestial Emissary Exit", 2420990, 2421703, Maps.UpperCathedralWard);
    
    //m25_00_00_00 Forsaken Castle Cainhurst (3)
    public static FogGate WarpFromCastleCainhurst = 
        new FogGate("Added Warp From Castle Cainhurst Entrance back to Hemwick Charnel Lane ", 2500998, 2501801, Maps.ForsakenCastleCainhurst);
    public static FogGate MartyrLogariusArenaEntrance = new FogGate("Martyr Logarius Arena Entrance", 2500996, 2501802, Maps.ForsakenCastleCainhurst, WarpEventType.FogGateEventFlag, 12501800, [Bosses.MartyLogarius]);
    public static FogGate MartyrLogariusEntrance = new FogGate("Martyr Logarius Entrance", 2500997, 2501800, Maps.ForsakenCastleCainhurst);
    
    //m26_00_00_00 Nightmare of Mensis (7)
    public static FogGate WarpBackToLectureBuilding = new FogGate("Added Warp back to Lecture Building", 2600998, 2601802, Maps.NightmareOfMensis);
    public static FogGate WetNurseArenaEntrance = new FogGate("Margo's Wet Nurse Arena Entrance", 2600996, 2601801, Maps.NightmareOfMensis, WarpEventType.FogGateEventFlag, 12601800, [Bosses.WetNurse1, Bosses.WetNurse2]);
    public static FogGate WetNurseEntrance         = new FogGate("Margo's Wet Nurse Entrance", 2600997, 2601800, Maps.NightmareOfMensis);
    public static FogGate MicolashArenaEntrance = 
        new FogGate("Micolash Arena Entrance", 2600994, 2601851, [], [], Maps.NightmareOfMensis, WarpEventType.FogGateEventFlag, 12601850);
    public static FogGate MicolashEntrance      = new FogGate("Micolash Entrance", 2600995, 2601850, Maps.NightmareOfMensis);
    public static FogGate MicolashExitMetalGateEyeBridge = new FogGate("Micolash Bridge Exit", 2600993, 2601859, Maps.NightmareOfMensis);
    public static FogGate MicolashArenaExitMetalGateEyeBridge = 
        new FogGate("Micolash Bridge Arena Exit", 2600992, 2601858, [], [], Maps.NightmareOfMensis, WarpEventType.FogGateEventFlag, 12601850);
    
    //m27_00_00_01 Forbidden Woods (8)
    public static FogGate ShadowsOfYharnamArenaEntrance = new FogGate("Shadows of Yharnam Arena Entrance", 2700998, 2701802, [], [Requirements.ForbiddenWoodsAccess], Maps.ForbiddenWoods, WarpEventType.FogGateEventFlag, 12701800, [Bosses.ShadowOfYharnam1, Bosses.ShadowOfYharnam2, Bosses.ShadowOfYharnam3]);
    public static FogGate ShadowsOfYharnamEntrance      = new FogGate("Shadows of Yharnam Entrance", 2700997, 2701800, [], [Requirements.ForbiddenWoodsAccess, Requirements.TonsilStoneObtained], Maps.ForbiddenWoods);
    public static FogGate ShadowsOfYharnamArenaExit = new FogGate("Shadows of Yharnam Arena Exit", 2700996, 2701803, [], [Requirements.ForbiddenWoodsAccess], Maps.ForbiddenWoods, WarpEventType.FogGateEventFlag, 12701800, [Bosses.ShadowOfYharnam1, Bosses.ShadowOfYharnam2, Bosses.ShadowOfYharnam3]);
    public static FogGate ShadowsOfYharnamExit      = new FogGate("Shadows of Yharnam Exit", 2700995, 2701801, Maps.ForbiddenWoods);
    public static FogGate MPGWoodsEntranceToWoods = 
        new FogGate("MPG at Beginning of Forbidden Woods, towards Woods", 2700994, 2707999, [], [Requirements.ForbiddenWoodsAccess, Requirements.TonsilStoneObtained], Maps.ForbiddenWoods);
    public static FogGate MPGWoodsEntranceToYharnam = 
        new FogGate("MPG at Beginning of Forbidden Woods, towards Yharnam", 2700993, 2701999, Maps.ForbiddenWoods);
    public static FogGate MPGCaveToIosefkasClinicWoods = 
        new FogGate("MPG Cave to Iosefkas Clinic, towards Woods", 2700992, 2701998, [], [Requirements.ForbiddenWoodsAccess, Requirements.TonsilStoneObtained], Maps.ForbiddenWoods);
    public static FogGate MPGCaveToIosefkasClinicCave = 
        new FogGate("MPG Cave to Iosefkas Clinic, towards Cave", 2700991, 2707998, [], [Requirements.CainhurstSummons], Maps.ForbiddenWoods);
    
    //m28_00_00_01 Yahar'gul Unseen Village (10)
    public static FogGate OneRebornArenaEntrance = new FogGate("The One Reborn Arena Entrance", 2800998, 2801802, Maps.YahargulUnseenVillage, WarpEventType.FogGateEventFlag, 12801800, [Bosses.TheOneReborne1, Bosses.TheOneReborne2, Bosses.TheOneReborne3]);
    public static FogGate OneRebornEntrance      = new FogGate("The One Reborn Entrance", 2800995, 2801800, [Requirements.RomDefeated], [Requirements.UpperCathedralWardKey], Maps.YahargulUnseenVillage);
    public static FogGate OneRebornArenaExit = new FogGate("The One Reborn Arena Exit", 2800996, 2801801, Maps.YahargulUnseenVillage, WarpEventType.FogGateEventFlag, 12801800, [Bosses.TheOneReborne1, Bosses.TheOneReborne2, Bosses.TheOneReborne3]);
    public static FogGate OneRebornExit      = new FogGate("The One Reborn Exit", 2800997, 2801803, Maps.YahargulUnseenVillage);
    public static FogGate MPGYahargulEntranceYahargul =
        new FogGate("MPG at Beginning of Yahar'gul, towards Yaha'rgul", 2800992, 2801998, [],  [Requirements.UpperCathedralWardKey], Maps.YahargulUnseenVillage);
    public static FogGate MPGYahargulEntranceCathedralWard =
        new FogGate("MPG at Beginning of Yahar'gul, towards Sacrificial Church", 2800993, 2801999, [Requirements.RomDefeated], [], Maps.YahargulUnseenVillage);
    public static FogGate MPGHypogeanGoalPaarl =
        new FogGate("MPG Hypogean Goal Cave to Darkbeast Paarl, towards Darkbeast Paarl", 2800991, 2801998, Maps.YahargulUnseenVillage);
    public static FogGate MPGHypogeanGoalGoal =
        new FogGate("MPG Hypogean Goal Cave to Darkbeast Paarl, towards Hypogean Goal", 2800990, 2801997, [], [Requirements.UpperCathedralWardKey], Maps.YahargulUnseenVillage);
    public static FogGate WarpToLectureBuildingAfterOneReborn = 
        new FogGate("Warp to Nightmare of Mensis, after One Reborn", 2800994, 2801500, Maps.YahargulUnseenVillage);
    //Doesn't actually have interactionEntity, but needs to be set anyway, as eventID is generated from it
    public static FogGate WarpToLectureBuildingLesserAmygdala = 
        new FogGate("Warp to Lecture Building, Lesser Amygdala (requires Tonsil Stone)", 2800989, 2801501, [Requirements.TonsilStoneObtained], [], Maps.YahargulUnseenVillage, WarpEventType.TonsilStoneWarp); 
    
    //m32_00_00_01 Byrgenwerth (8)
    public static FogGate MPGBeginningByrgenwerthWoods = 
        new FogGate("MPG at Start of Byrgenwerth, towards Forbidden Woods", 3200997, 3201999, Maps.Byrgenwerth);
    public static FogGate MPGBeginningByrgenwerthByrgenwerth =
        new FogGate("MPG at Start of Byrgenwerth, towards Byrgenwerth", 3200998, 3201998, Maps.Byrgenwerth);
    public static FogGate RomArenaEntrance = new FogGate("Rom, the Vacuous Spider Arena Entrance", 3200996, 3201801, [], [Requirements.RomDefeated], Maps.Byrgenwerth, WarpEventType.FogGateEventFlag, 13201800, [Bosses.RomVacuousSpider]);
    public static FogGate RomEntrance = new FogGate("Rom, the Vacuous Spider Entrance", 3200995, 3201800, Maps.Byrgenwerth);
    public static FogGate WarpToNightmareofMensis = new FogGate("Warp to Nightmare of Mensis", 3200994, 3201802, Maps.Byrgenwerth);
    public static FogGate WarpBackToYahargulAfterOneReborn = 
        new FogGate("Added Warp back to Yahar'gul, after One Reborne", 3200992, 3201805, Maps.Byrgenwerth);
    public static FogGate WarpBackToLesserAmygdala = 
        new FogGate("Added Warp back to Lesser Amygdala", 3200991, 3201804, Maps.Byrgenwerth);
    public static FogGate WarpToNightmareFrontier = new FogGate("Warp to Nightmare Frontier", 3200993, 3201803, Maps.Byrgenwerth);
    
    //m33_00_00_00 Nightmare Frontier (5)
    public static FogGate AmygdalaArenaEntrance = new FogGate("Amygdala Arena Entrance", 3300998, 3301802, Maps.NightmareFrontier, WarpEventType.FogGateEventFlag, 13301800, [Bosses.Amygdala1, Bosses.Amygdala2, Bosses.Amygdala3, Bosses.Amygdala4]);
    public static FogGate AmygdalaEntrance      = new FogGate("Amygdala Entrance", 3300995, 3301800, Maps.NightmareFrontier);
    public static FogGate AmygdalaArenaExit = new FogGate("Amygdala Arena Exit", 3300996, 3301803, Maps.NightmareFrontier, WarpEventType.FogGateEventFlag, 13301800, [Bosses.Amygdala1, Bosses.Amygdala2, Bosses.Amygdala3, Bosses.Amygdala4]);
    public static FogGate AmygdalaExit      = new FogGate("Amygdala Exit", 3300997, 3301801, Maps.NightmareFrontier);
    public static FogGate WarpFrontierBackToLectureBuilding =
        new FogGate("Added Warp from Nightmare Frontier to Lecture Building", 3300994, 3301804, Maps.NightmareFrontier);
    
    //m34_00_00_00 Hunter's Nightmare (7)
    public static FogGate LaurenceArenaEntrance = new FogGate("Laurence, the First Vicar Arena Entrance", 3400998, 3401851, [], [Requirements.EyePendant], Maps.HuntersNightmare, WarpEventType.FogGateEventFlag, 13401850, [Bosses.Laurence]);
    public static FogGate LaurenceEntrance      = new FogGate("Laurence, the First Vicar Entrance", 3400997, 3401850, Maps.HuntersNightmare);
    public static FogGate LudwigArenaEntrance   = new FogGate("Ludwig, the Holy Blade Arena Entrance", 3400996, 3401802, Maps.HuntersNightmare, WarpEventType.FogGateEventFlag, 13401800, [Bosses.Ludwig1, Bosses.Ludwig2]);
    public static FogGate LudwigEntrance        = new FogGate("Ludwig, the Holy Blade Entrance", 3400995, 3401800, Maps.HuntersNightmare);
    public static FogGate LudwigArenaExit   = new FogGate("Ludwig, the Holy Blade Arena Exit", 3400994, 3401803, Maps.HuntersNightmare, WarpEventType.FogGateEventFlag, 13401800, [Bosses.Ludwig1, Bosses.Ludwig2]);
    public static FogGate LudwigExit        = new FogGate("Ludwig, the Holy Blade Exit", 3400993, 3401801, Maps.HuntersNightmare);
    public static FogGate AddedWarpBackCathedralWard = new FogGate("Added Warp Back to Cathedral Ward", 3400992, 3401804, Maps.HuntersNightmare);
    
    //m35_00_00_00 Research Hall (6)
    public static FogGate MPGAfterLudwigLudwig = new FogGate("MPG after Ludwig, towards Ludwig", 3500997, 3501990, Maps.ResearchHall);
    public static FogGate MPGAfterLudwigResearchHall = new FogGate("MPG after Ludwig, towards Research Hall", 3500998, 3501991, [Requirements.EyePendant], [], Maps.ResearchHall);
    public static FogGate LadyMariaArenaEntrance = new FogGate("Lady Maria Arena Entrance", 3500996, 3501801, Maps.ResearchHall, WarpEventType.FogGateEventFlag, 13501800, [Bosses.LadyMaria1, Bosses.LadyMaria2]);
    public static FogGate LadyMariaEntrance = new FogGate("Lady Maria Entrance", 3500995, 3501800, Maps.ResearchHall);
    public static FogGate LivingFailiuresArenaEntrance = new FogGate("Living Failiures Arena Entrance", 3500994, 3501811, Maps.ResearchHall, WarpEventType.FogGateEventFlag, 13501850, [Bosses.LivingFailures]);
    public static FogGate LivingFailiuresEntrance = new FogGate("Living Failiures Entrance", 3500993, 3501810, [Requirements.EyePendant], [], Maps.ResearchHall);
    
    //m36_00_00_00 Fishing Hamlet (2)
    public static FogGate OrphanofKosArenaEntrance = new FogGate("Orphan of Kos Arena Entrance", 3600998, 3601801, Maps.FishingHamlet, WarpEventType.FogGateEventFlag, 13601800, [Bosses.OrphanOfKos]);
    public static FogGate OrphanofKosEntrance = new FogGate("Orphan of Kos Entrance", 3600997, 3601800, Maps.FishingHamlet);

    public static void SetupWalkNeighbours(int gatePresetIndex)
    {
        if(gatePresetIndex == 0) SetupWalkNeighboursAllGates();
        else if(gatePresetIndex == 1)
        {
            SetupWalkNeighboursAllGates();
            RemoveDlcWalkNeighbours();
        }
    }

    private static void RemoveDlcWalkNeighbours()
    {
        WarpToOldHuntersDLC.SetupWalkNeighbours([]);
        
        CathedralWardMPGToCathedralWard.SetupWalkNeighbours([
            VicarAmeliaEntrance,
            MPGBeforeOldYharnamLanternTowardsCathedralWard, 
            MPGBeforeSacrificalConnectionChurchCathedralWard, 
            MPGInfrontHemwickCharnelLaneCathedralWard]);
        /*VicarAmeliaEntrance.SetupWalkNeighbours([
            CathedralWardMPGToCathedralWard,
            MPGBeforeOldYharnamLanternTowardsCathedralWard,
            MPGBeforeSacrificalConnectionChurchCathedralWard,
            MPGInfrontHemwickCharnelLaneCathedralWard]);*/
        MPGBeforeOldYharnamLanternTowardsCathedralWard.SetupWalkNeighbours([]); //There's the contraption, which can only be activated from the other side.
        MPGBeforeSacrificalConnectionChurchCathedralWard.SetupWalkNeighbours([
            VicarAmeliaEntrance,
            MPGBeforeOldYharnamLanternTowardsCathedralWard,
            MPGInfrontHemwickCharnelLaneCathedralWard,
            CathedralWardMPGToCathedralWard]);
        MPGInfrontHemwickCharnelLaneCathedralWard.SetupWalkNeighbours([
            CathedralWardMPGToCathedralWard,
            VicarAmeliaEntrance,
            MPGBeforeOldYharnamLanternTowardsCathedralWard,
            MPGBeforeSacrificalConnectionChurchCathedralWard]);
    }
    
    private static void SetupWalkNeighboursAllGates()
    {
        //m22_00_00_00 Hemwick Charnel Lane (7)
        WitchOfHemwickArenaEntrance.SetupWalkNeighbours([WitchOfHemwickArenaExit]);
        WitchOfHemwickArenaExit.SetupWalkNeighbours([WitchOfHemwickArenaEntrance]);
        WitchOfHemwickEntrance.SetupWalkNeighbours([WarpToCastleCainhurst, MPGHemwickCharnelLaneHemwick]);
        WitchOfHemwickExit.SetupWalkNeighbours([]);
        WarpToCastleCainhurst.SetupWalkNeighbours([WitchOfHemwickEntrance,  MPGHemwickCharnelLaneHemwick]);
        MPGHemwickCharnelLaneCathedral.SetupWalkNeighbours([MPGInfrontHemwickCharnelLaneHemwick]);
        MPGHemwickCharnelLaneHemwick.SetupWalkNeighbours([WitchOfHemwickEntrance, WarpToCastleCainhurst]);
        
        //m23_00_00_01 Old Yharnam (8)
        BloodStarvedBeastArenaEntrance.SetupWalkNeighbours([]);
        BloodStarvedBeastEntrance.SetupWalkNeighbours([OldYharnamMPGToOldYharnam]);
        DarkbeastPaarlArenaEntrance.SetupWalkNeighbours([DarkbeastPaarlArenaExit]);
        DarkbeastPaarlEntrance.SetupWalkNeighbours([]);
        DarkbeastPaarlArenaExit.SetupWalkNeighbours([DarkbeastPaarlArenaEntrance]);
        DarkbeastPaarlExit.SetupWalkNeighbours([BloodStarvedBeastEntrance, OldYharnamMPGToOldYharnam]);
        OldYharnamMPGToStaircase.SetupWalkNeighbours([MPGBeforeOldYharnamLanternTowardsOldYharnam]);
        OldYharnamMPGToOldYharnam.SetupWalkNeighbours([BloodStarvedBeastEntrance]);
        
        //m24_00_00_01 Cathedral Ward (11)
        MPGBeforeOldYharnamLanternTowardsOldYharnam.SetupWalkNeighbours([OldYharnamMPGToStaircase]);
        MPGBeforeSacrificalConnectionChurchChurch.SetupWalkNeighbours([MPGYahargulEntranceCathedralWard, WarpToLectureBuildingLesserAmygdala]);
        CathedralWardMPGToGascoigne.SetupWalkNeighbours([GascoigneExitMPG]);
        VicarAmeliaArenaEntrance.SetupWalkNeighbours([]);
        
        WarpToOldHuntersDLC.SetupWalkNeighbours([
            VicarAmeliaEntrance,
            MPGBeforeOldYharnamLanternTowardsCathedralWard,
            MPGBeforeSacrificalConnectionChurchCathedralWard,
            MPGInfrontHemwickCharnelLaneCathedralWard,
            CathedralWardMPGToCathedralWard]);
        CathedralWardMPGToCathedralWard.SetupWalkNeighbours([
            VicarAmeliaEntrance,
            MPGBeforeOldYharnamLanternTowardsCathedralWard, 
            MPGBeforeSacrificalConnectionChurchCathedralWard, 
            MPGInfrontHemwickCharnelLaneCathedralWard,
            WarpToOldHuntersDLC]);
        VicarAmeliaEntrance.SetupWalkNeighbours([]); //Door can only be opened from other side
        MPGBeforeOldYharnamLanternTowardsCathedralWard.SetupWalkNeighbours([]); //Contraption
        MPGBeforeSacrificalConnectionChurchCathedralWard.SetupWalkNeighbours([
            VicarAmeliaEntrance,
            MPGBeforeOldYharnamLanternTowardsCathedralWard,
            MPGInfrontHemwickCharnelLaneCathedralWard,
            CathedralWardMPGToCathedralWard,
            WarpToOldHuntersDLC]);
        MPGInfrontHemwickCharnelLaneCathedralWard.SetupWalkNeighbours([
            CathedralWardMPGToCathedralWard,
            VicarAmeliaEntrance,
            MPGBeforeOldYharnamLanternTowardsCathedralWard,
            MPGBeforeSacrificalConnectionChurchCathedralWard,
            WarpToOldHuntersDLC]);
        MPGInfrontHemwickCharnelLaneHemwick.SetupWalkNeighbours([MPGHemwickCharnelLaneCathedral]);
        
        //m24_01_00_01 Central Yaharnam (8)
        GascoigneArenaEntrance.SetupWalkNeighbours([GascoigneArenaExitMPG]);
        GascoigneEntrance.SetupWalkNeighbours([ClericBeastEntrance, GateAfterIosefkasClinicToFirstLamp]);
        GascoigneArenaExitMPG.SetupWalkNeighbours([]);
        GascoigneExitMPG.SetupWalkNeighbours([CathedralWardMPGToGascoigne]);
        GateAfterIosefkasClinicToClinic.SetupWalkNeighbours([]);
        GateAfterIosefkasClinicToFirstLamp.SetupWalkNeighbours([ClericBeastEntrance, GascoigneEntrance]);
        ClericBeastArenaEntrance.SetupWalkNeighbours([]);
        ClericBeastEntrance.SetupWalkNeighbours([GascoigneEntrance, GateAfterIosefkasClinicToFirstLamp]);
        
        //m24_02_00_01 Upper Cathedral Ward (8)
        MPGUpperCathedralWardUpper.SetupWalkNeighbours([CelestialEmissaryEntrance]);
        MPGUpperCathedralCathedralWard.SetupWalkNeighbours([]); //No connection, as door can't be opened from other side.
        EbrietasaArenaEntrance.SetupWalkNeighbours([]);
        EbrietasaEntrance.SetupWalkNeighbours([]); //Can't go back, drop down from window
        CelestialEmissaryArenaEntrance.SetupWalkNeighbours([CelestialEmissaryArenaExit]);
        CelestialEmissaryEntrance.SetupWalkNeighbours([MPGUpperCathedralWardUpper]);
        CelestialEmissaryArenaExit.SetupWalkNeighbours([CelestialEmissaryArenaEntrance]);
        CelestialEmissaryExit.SetupWalkNeighbours([EbrietasaEntrance]);
        
        //m25_00_00_00 Forsaken Castle Cainhurst (3)
        WarpFromCastleCainhurst.SetupWalkNeighbours([MartyrLogariusEntrance]);
        MartyrLogariusArenaEntrance.SetupWalkNeighbours([]);
        MartyrLogariusEntrance.SetupWalkNeighbours([]); // No connections due to drop down
        
        //m26_00_00_00 Nightmare of Mensis (7)
        WarpBackToLectureBuilding.SetupWalkNeighbours([MicolashEntrance]);
        WetNurseArenaEntrance.SetupWalkNeighbours([]);
        WetNurseEntrance.SetupWalkNeighbours([MicolashEntrance]); //It isn't possible to return to Micolash, as bridge won't be there if not defeated, 
        MicolashArenaEntrance.SetupWalkNeighbours([MicolashArenaExitMetalGateEyeBridge, WetNurseEntrance]);
        MicolashEntrance.SetupWalkNeighbours([WarpBackToLectureBuilding]);
        MicolashExitMetalGateEyeBridge.SetupWalkNeighbours([]); //One way, this is reached by rolling of elevator, also metal door infont, so fog gate isn't reachable with Micolash alive
        MicolashArenaExitMetalGateEyeBridge.SetupWalkNeighbours([MicolashArenaEntrance, WetNurseEntrance]);
        
        //m27_00_00_01 Forbidden Woods (8)
        ShadowsOfYharnamArenaEntrance.SetupWalkNeighbours([ShadowsOfYharnamArenaExit]);
        ShadowsOfYharnamEntrance.SetupWalkNeighbours([MPGWoodsEntranceToWoods, MPGCaveToIosefkasClinicWoods]);
        ShadowsOfYharnamArenaExit.SetupWalkNeighbours([ShadowsOfYharnamArenaEntrance]);
        ShadowsOfYharnamExit.SetupWalkNeighbours([MPGBeginningByrgenwerthWoods]);
        MPGWoodsEntranceToWoods.SetupWalkNeighbours([ShadowsOfYharnamEntrance, MPGCaveToIosefkasClinicWoods]);
        MPGWoodsEntranceToYharnam.SetupWalkNeighbours([]); //Door can't be opened from woods side
        MPGCaveToIosefkasClinicWoods.SetupWalkNeighbours([MPGWoodsEntranceToWoods, ShadowsOfYharnamEntrance]);
        MPGCaveToIosefkasClinicCave.SetupWalkNeighbours([]); //Reference to Start Gate missing intentionally, helps prevent early loops
        
        //m28_00_00_01 Yahar'gul Unseen Village (10)
        OneRebornArenaEntrance.SetupWalkNeighbours([OneRebornArenaExit]);
        OneRebornEntrance.SetupWalkNeighbours([]); // No connections cause door
        OneRebornArenaExit.SetupWalkNeighbours([OneRebornArenaEntrance]);
        OneRebornExit.SetupWalkNeighbours([WarpToLectureBuildingAfterOneReborn]);
        MPGYahargulEntranceYahargul.SetupWalkNeighbours([OneRebornEntrance, MPGHypogeanGoalGoal]);
        MPGYahargulEntranceCathedralWard.SetupWalkNeighbours([]); //Door
        MPGHypogeanGoalPaarl.SetupWalkNeighbours([DarkbeastPaarlEntrance]);
        MPGHypogeanGoalGoal.SetupWalkNeighbours([OneRebornEntrance, MPGYahargulEntranceYahargul]);
        WarpToLectureBuildingAfterOneReborn.SetupWalkNeighbours([OneRebornExit]);
        WarpToLectureBuildingLesserAmygdala.SetupWalkNeighbours([MPGYahargulEntranceCathedralWard, MPGBeforeSacrificalConnectionChurchChurch]);
        
        //m32_00_00_01 Byrgenwerth (8)
        MPGBeginningByrgenwerthWoods.SetupWalkNeighbours([ShadowsOfYharnamExit]);
        MPGBeginningByrgenwerthByrgenwerth.SetupWalkNeighbours([RomEntrance]);
        RomArenaEntrance.SetupWalkNeighbours([MPGYahargulEntranceCathedralWard, WarpToLectureBuildingLesserAmygdala, MPGBeforeSacrificalConnectionChurchChurch]);
        RomEntrance.SetupWalkNeighbours([MPGBeginningByrgenwerthByrgenwerth]);
        WarpToNightmareofMensis.SetupWalkNeighbours([WarpBackToLesserAmygdala, WarpBackToYahargulAfterOneReborn, WarpToNightmareFrontier]);
        WarpBackToYahargulAfterOneReborn.SetupWalkNeighbours([WarpToNightmareofMensis, WarpBackToLesserAmygdala, WarpToNightmareFrontier]);
        WarpBackToLesserAmygdala.SetupWalkNeighbours([WarpToNightmareFrontier]);
        WarpToNightmareFrontier.SetupWalkNeighbours([WarpBackToLesserAmygdala]);
        
        //m33_00_00_00 Nightmare Frontier (5)
        AmygdalaArenaEntrance.SetupWalkNeighbours([AmygdalaArenaExit]);
        AmygdalaEntrance.SetupWalkNeighbours([WarpFrontierBackToLectureBuilding]);
        AmygdalaArenaExit.SetupWalkNeighbours([AmygdalaArenaEntrance]);
        AmygdalaExit.SetupWalkNeighbours([]);
        WarpFrontierBackToLectureBuilding.SetupWalkNeighbours([AmygdalaEntrance]);
        
        //m34_00_00_00 Hunter's Nightmare (7)
        LaurenceArenaEntrance.SetupWalkNeighbours([]);
        LaurenceEntrance.SetupWalkNeighbours([LudwigEntrance, AddedWarpBackCathedralWard]);
        LudwigArenaEntrance.SetupWalkNeighbours([LudwigArenaExit]);
        LudwigEntrance.SetupWalkNeighbours([LaurenceEntrance, AddedWarpBackCathedralWard]);
        LudwigArenaExit.SetupWalkNeighbours([LudwigArenaEntrance]);
        LudwigExit.SetupWalkNeighbours([MPGAfterLudwigLudwig]);
        AddedWarpBackCathedralWard.SetupWalkNeighbours([LaurenceEntrance, LudwigEntrance]);
        
        //m35_00_00_00 Research Hall (6)
        MPGAfterLudwigLudwig.SetupWalkNeighbours([LudwigExit]);
        MPGAfterLudwigResearchHall.SetupWalkNeighbours([LivingFailiuresEntrance]);
        LadyMariaArenaEntrance.SetupWalkNeighbours([OrphanofKosEntrance]);
        LadyMariaEntrance.SetupWalkNeighbours([]); //Can't go back because of door
        LivingFailiuresArenaEntrance.SetupWalkNeighbours([LadyMariaEntrance]);
        LivingFailiuresEntrance.SetupWalkNeighbours([MPGAfterLudwigResearchHall]); //TODO: Check if actually doable, rotating stairs
        
        OrphanofKosArenaEntrance.SetupWalkNeighbours([]);
        OrphanofKosEntrance.SetupWalkNeighbours([]); //Can't access Lady Maria without her beig dead, so no connection
        
    }
}