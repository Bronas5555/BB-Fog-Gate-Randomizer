using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using BB_Fog_Gate_Randomizer.Util;

namespace BB_Fog_Gate_Randomizer.Randomizer.Scaling;

public class Bosses
{

        public static readonly ParamBoss Gascoigne1 =
                new ParamBoss(271000, [new NumberSpan(271000, 271060)], "Father Gascoigne Human", 1440, 2);
        public static readonly ParamBoss Gascoigne2 =
                new ParamBoss(272000, [new NumberSpan(272000, 272024)], "Father Gascoigne Beast", 1440, 2);

        public static readonly ParamBoss ClericBeast1 = new ParamBoss(500000,
                [new NumberSpan(3314, 3319), new NumberSpan(500100, 500800)], "Cleric Beast", 2700, 1); //Parishioner
        public static readonly ParamBoss ClericBeast2 = new ParamBoss(500241,
                [new NumberSpan(3314, 3319), new NumberSpan(500100, 500800)], "Cleric Beast 2", 2700, 1); //Parishioner

        public static readonly ParamBoss BloodStarvedBeast1 =
                new ParamBoss(209000, [new NumberSpan(209000, 209200)], "Blood Starved Beast 1", 2000, 4); //Bloodthirsty Beast Ruins
        public static readonly ParamBoss BloodStarvedBeast2 =
                new ParamBoss(209010, [new NumberSpan(209000, 209200)], "Blood Starved Beast 2", 750, 4); //Bloodthirsty Beast Ruins

        public static readonly ParamBoss WitchofHemwick1 =
                new ParamBoss(210020, [new NumberSpan(210000, 210066)], "Witch of Hemwick 1", 1200, 3); //Eye Collector
        public static readonly ParamBoss WitchofHemwick2 =
                new ParamBoss(210025, [new NumberSpan(210000, 210066)], "Witch of hemwick 2", 1200, 3); //Eye Collector for Old Castles

        public static readonly ParamBoss VicarAmelia = new ParamBoss(502000,
                [new NumberSpan(3332, 3338), new NumberSpan(502000, 514310)], "Vicar Amelia", 2500, 6); //Saint Beast Catherdal A

        public static readonly ParamBoss MartyLogarius =
                new ParamBoss(232000, [new NumberSpan(230000, 230095)], "Martyr Logarius", 1600, 10); //King's Death Old Castle

        public static readonly ParamBoss ShadowOfYharnam1 = new ParamBoss(212700, [new NumberSpan(212000, 212555)],
                "Shadow of Yharnam (Sword)", 1425, 11); //Dark Brigade

        public static readonly ParamBoss ShadowOfYharnam2 = new ParamBoss(212710, [new NumberSpan(212000, 212555)],
                "Shadow of Yharnam (Candle)", 900, 11); 

        public static readonly ParamBoss ShadowOfYharnam3 = new ParamBoss(212720, [new NumberSpan(212000, 212555)],
                "Shadow of Yharnam (Hammer)", 800, 11);

        public static readonly ParamBoss TheOneReborne1 =
                new ParamBoss(507000, [new NumberSpan(507000, 507670)], "The One Reborne 1", 1800, 14); //The Failed evil god
        public static readonly ParamBoss TheOneReborne2 = new ParamBoss(507100, [new NumberSpan(507000, 507670)],
                "The One Reborne 2 (People)", 1800, 13);
        public static readonly ParamBoss TheOneReborne3 =
                new ParamBoss(507200, [new NumberSpan(507000, 507670)], "The One Reborne 3", 1800, 14); //14, ''

        public static readonly ParamBoss DarkbeastPaarl =
                new ParamBoss(508000, [new NumberSpan(508000, 508730)], "Darkbeast Paarl", 1800, 14); //torm Beast (Bone) First Sacrifice

        public static readonly ParamBoss RomVacuousSpider = new ParamBoss(510000,
                [new NumberSpan(3351, 3352), new NumberSpan(140000, 140090), new NumberSpan(510000, 510090)],
                "Rom, the Vacuous Spider", 1000, 15); //Idiot Spider University

        public static readonly ParamBoss Amygdala1 =
                new ParamBoss(512000, [new NumberSpan(512000, 514320)], "Amygdala 1", 2200, 16); //Evil God Fallen Angel ver hometown
        public static readonly ParamBoss Amygdala2 =
                new ParamBoss(512005, [new NumberSpan(512000, 514320)], "Amygdala 2", 2200, 16);
        public static readonly ParamBoss Amygdala3 =
                new ParamBoss(512010, [new NumberSpan(512000, 514320)], "Amygdala 3", 2200, 16);
        public static readonly ParamBoss Amygdala4 =
                new ParamBoss(512011, [new NumberSpan(512000, 514320)], "Amygdala 4", 2200, 16);

        public static readonly ParamBoss WetNurse1 = new ParamBoss(550000,
                [new NumberSpan(3342, 3342), new NumberSpan(550000, 552141)], "Wet Nurse 1", 1800, 17); //Lesser Demon
        public static readonly ParamBoss WetNurse2 = new ParamBoss(550009,
                [new NumberSpan(3342, 3342), new NumberSpan(550000, 552141)], "Wet Nurse 2", 1800, 17);

        public static readonly ParamBoss CelestialEmissary1 =
                new ParamBoss(250070, [new NumberSpan(250000, 257100)], "Celestial Emissionary 1", 56, 16); //Messenger from the Moon
        public static readonly ParamBoss CelestialEmissary2 =
                new ParamBoss(250080, [new NumberSpan(250000, 257100)], "Celestial Emissionary 2", 400, 16);
        public static readonly ParamBoss CelestialEmissary3 =
                new ParamBoss(250081, [new NumberSpan(250000, 257100)], "Celestial Emissionary 3", 56, 16);
        public static readonly ParamBoss CelestialEmissary4 =
                new ParamBoss(250082, [new NumberSpan(250000, 257100)], "Celestial Emissionary 4", 56, 16);
        

        public static readonly ParamBoss Ebrietas = new ParamBoss(251000,
                [new NumberSpan(3343, 3343), new NumberSpan(251000, 251193)], "Ebrietas", 1800, 17); //Child of the Moon Cathedral

        public static readonly ParamBoss Laurence =
                new ParamBoss(450000, [new NumberSpan(450100, 450996)], "Laurence", 2700, 18); //Parishioner Omega

        public static readonly ParamBoss LivingFailures = new ParamBoss(403050,
                [new NumberSpan(6360, 6361), new NumberSpan(403100, 403420)], "Living Failures", 2700, 19); //Patient B

        public static readonly ParamBoss LadyMaria1 =
                new ParamBoss(452000, [new NumberSpan(452000, 452725)], "Lady Maria 1", 1800, 19); //Female Hunter
        public static readonly ParamBoss LadyMaria2 =
                new ParamBoss(452001, [new NumberSpan(452000, 452725)], "Lady Maria 2", 1800, 19); //Female Hunter

        public static readonly ParamBoss Ludwig1 = new ParamBoss(451000,
                [new NumberSpan(3360, 3363), new NumberSpan(451100, 451610)], "Ludwig, the Accursed", 2400, 18); //Ludwig
        public static readonly ParamBoss Ludwig2 = new ParamBoss(451001,
                [new NumberSpan(3360, 3363), new NumberSpan(451100, 451610)], "Ludwig, the Holy Blade", 2400, 18); //Ludwig

        public static readonly ParamBoss OrphanOfKos =
                new ParamBoss(454000, [new NumberSpan(453000, 454500)], "Orphan of Kos", 2200, 20); //Final Boss
        
        //Mandatory Enemies
        public static readonly ParamBoss OrphanageKeyBrainSucker1 = new ParamBoss(106020, [new NumberSpan(-1, -1)],
                "Brain Sucker 1 (Drops Orphanage Key)", 105, 15);
        public static readonly ParamBoss OrphanageKeyBrainSucker2 = new ParamBoss(106021, [new NumberSpan(-1, -1)],
                "Brain Sucker 2 (Drops Orphanage Key)", 130, 15);


}