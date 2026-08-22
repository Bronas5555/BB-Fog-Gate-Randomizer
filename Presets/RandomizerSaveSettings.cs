namespace BB_Fog_Gate_Randomizer.Presets;

public class RandomizerSaveSettings
{
    public string PresetName { get; set; }
    public int GatePresetIndex { get; set; }
    public bool AllowBossFightEscape { get; set; }
    public bool ScaleBosses { get; set; }
    public int ScalingDifficulty { get; set; }
    public int WinCondition { get; set; }
    
    public int Seed { get; set; }
    public bool ShowSeed { get; set; }

    public RandomizerSaveSettings(string presetName, int gatePresetIndex, bool allowBossFightEscape, bool scaleBosses, int scalingDifficulty, int winCondition, int seed, bool showSeed)
    {
        PresetName = presetName;
        GatePresetIndex = gatePresetIndex;
        AllowBossFightEscape = allowBossFightEscape;
        ScaleBosses = scaleBosses;
        ScalingDifficulty = scalingDifficulty;
        WinCondition = winCondition;
        Seed = seed;
        ShowSeed = showSeed;
    }
    
}