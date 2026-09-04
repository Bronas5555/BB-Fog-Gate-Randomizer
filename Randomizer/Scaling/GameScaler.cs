using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BB_Fog_Gate_Randomizer.Randomizer.Fog;
using BB_Fog_Gate_Randomizer.Randomizer.Util;
using BB_Fog_Gate_Randomizer.UserControls;
using HarfBuzzSharp;
using SoulsFormats;

namespace BB_Fog_Gate_Randomizer.Randomizer.Scaling;

public class GameScaler
{
    private PARAM npcParams;
    private PARAM npcAttackParams;
    private BND4 _parambnd;
    private Dictionary<string, PARAM> _parms;
    
    private int maxDepth = 0;

    private FogGate _startGate;

    private HashSet<FogGate> _visitedGates;
    private HashSet<ParamBoss> _scaledBosses;

    private float _difficultyModifier = 1f;

    public GameScaler(FogGate startGate)
    {
        SetupParams();
        maxDepth = TreeUtil.GetDepth(startGate);
        _startGate = startGate;
        _visitedGates = new HashSet<FogGate>();
        _scaledBosses = new HashSet<ParamBoss>();
    }

    public void ScaleBosses()
    {
        switch (RandomizerSettings.Instance.ScalingDifficultyBox.SelectedIndex)
        {
            case 0: _difficultyModifier = 0.5f; break;
            case 1: _difficultyModifier = 1f; break;
            case 2: _difficultyModifier = 2f; break;
            default: throw new NotImplementedException("Unimplemented Difficulty");
        }
        ScaleBosses(_startGate);
        SaveParam();
    }
    
    private void ScaleBosses(FogGate gate, int depth = 1)
    {
        if (!_visitedGates.Add(gate))
            return;
        
        if (gate.ParamBosses != null) ScaleGatesBosses(gate.ParamBosses, depth);

        if (gate.LinkedFogGate != null)
        {
            if (gate.LinkedFogGate.ParamBosses != null) ScaleGatesBosses(gate.LinkedFogGate.ParamBosses, depth);

            foreach (var neighbour in gate.LinkedFogGate.WalkNeighbours)
            {
                ScaleBosses(neighbour, depth + 1);
            }
        }
    }

    private void ScaleGatesBosses(List<ParamBoss> bosses, int depth)
    {
        foreach (ParamBoss boss in bosses)
        {
            if (_scaledBosses.Contains(boss)) continue;

            int newHp = GetScaledBossHp(boss, depth);
            
            WriteBossHp(boss, newHp);
            
            try
            {
                ScaleBossAttacks(boss, depth);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            _scaledBosses.Add(boss);
        }
    }

    private void ScaleBossAttacks(ParamBoss boss, int depth)
    {
        //Looping over all Rows in npcAttackParams
        foreach (var row in npcAttackParams.Rows)
        {
            //For each row, loop over the bosses id Ranges
            foreach (var numberSpam in boss.NpcAttackIds)
            {
                //Check if current row is for the current Boss
                if (numberSpam.isInsideIncludeBounds(row.ID))
                {
                    //Getting the Attacks default damage values
                    ushort atkPhys = (ushort)row["atkPhys"].Value;
                    ushort atkMag = (ushort)row["atkMag"].Value;
                    ushort atkFire = (ushort)row["atkFire"].Value;
                    ushort atkThun = (ushort)row["atkThun"].Value;
                    
                    //How far along in tree we are (0 - 1)
                    float percentage = (float)depth / maxDepth;
                    float treeTier = percentage * 25f; //Max predefined tier is 25

                    float multiplier = treeTier / boss.ScalingTier * 0.5f;
                    multiplier *= _difficultyModifier;

                    //Scaling Damage Value
                    int atkPhysScaled = (int)Math.Round(atkPhys * multiplier);
                    int atkMagScaled =  (int)Math.Round(atkMag * multiplier);
                    int atkFireScaled =  (int)Math.Round(atkFire * multiplier);
                    int atkThunScaled =  (int)Math.Round(atkThun * multiplier);
                    
                    //Setting Values in the Param Row
                    row["atkPhys"].Value = (ushort)atkPhysScaled;
                    row["atkMag"].Value = (ushort)atkMagScaled;
                    row["atkFire"].Value = (ushort)atkFireScaled;
                    row["atkThun"].Value = (ushort)atkThunScaled;
                    
                    Console.WriteLine($"Scaled Attack {row.Name}: " +
                                      $"{atkPhys}, {atkMag}, {atkFire}, {atkThun} --> " +
                                      $"{atkPhysScaled}, {atkMagScaled}, {atkFireScaled}, {atkThunScaled} ({multiplier})");
                }
            }
        }
    }

    private int GetScaledBossHp(ParamBoss boss, int depth)
    {
        //How far along in tree we are (0 - 1)
        float percentage = (float)depth / maxDepth;
        float treeTier = percentage * 25f;

        float multiplier = treeTier / boss.ScalingTier;
        
        int newHp = (int)(Math.Round(boss.Hp * multiplier) / 2f);
        newHp = Math.Max(1, newHp);
        Console.WriteLine($"Writing Boss Hp: {boss.Name} ({depth}): {boss.Hp} | {newHp} ({treeTier}, {multiplier})");
        return (int)Math.Round(newHp * _difficultyModifier);
    }
    
    private void SetupParams()
    {
        //Loading paramdefs
        List<PARAMDEF> paramdefs = new List<PARAMDEF>();
        foreach (string path in Directory.GetFiles("./Assets/ParamDefs/", "*.xml"))
        {
            PARAMDEF paramdef = PARAMDEF.XmlDeserialize(path);
            paramdefs.Add(paramdef);
        }

        //Applying Defs to PARAMS
        _parms = new Dictionary<string, PARAM>();
        _parambnd = BND4.Read("./Assets/Mod/dvdroot_ps4/param/gameparam/gameparam.parambnd.dcx");

        foreach (BinderFile file in _parambnd.Files)
        {
            string name = file.Name.EndsWith(".param", StringComparison.OrdinalIgnoreCase)
                ? file.Name.Substring(0, file.Name.Length - ".param".Length)
                : file.Name;
            PARAM param = PARAM.Read(file.Bytes);


            if (param.ApplyParamdefCarefully(paramdefs))
            {
                _parms[name] = param;
                Console.WriteLine(name);
            }
        }
        
        npcParams = _parms["N:\\SPRJ\\data\\INTERROOT_ps4\\param\\GameParam\\64bit\\NpcParam"];
        npcAttackParams = _parms["N:\\SPRJ\\data\\INTERROOT_ps4\\param\\GameParam\\64bit\\AtkParam_Npc"];
        
    }

    private void SaveParam()
    {
        foreach (BinderFile file in _parambnd.Files)
        {
            string name = Path.GetFileNameWithoutExtension(file.Name);
            if (_parms.ContainsKey(name))
                file.Bytes = _parms[name].Write();
        }

        _parambnd.Write("./Fog Gate Randomizer/Fog Gate Randomizer/dvdroot_ps4/param/gameparam/gameparam.parambnd.dcx");
    }
    private void WriteBossHp(ParamBoss boss, int newHp)
    {
        npcParams[boss.NpcId]["hp"].Value = (uint)newHp;
    }
}