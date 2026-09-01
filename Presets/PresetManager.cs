using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Avalonia.Controls;
using BB_Fog_Gate_Randomizer.UserControls;
using BB_Fog_Gate_Randomizer.Util;

namespace BB_Fog_Gate_Randomizer.Presets;

public class PresetManager
{
    private static string _presetPath = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BB Fog Gate Randomizer");

    public static void OpenPresetFolder()
    {
        FileUtil.OpenDirectoryInFileManager(_presetPath);
    }
    public static void DeletePreset(RandomizerSaveSettings preset)
    {
        File.Delete(Path.Join(_presetPath, preset.PresetName + ".json"));
    }
    public static void LoadPreset(RandomizerSaveSettings preset)
    {
        Console.WriteLine($"Loading Preset {preset.PresetName}");
        
        RandomizerSettings.Instance.GatesComboBox.SelectedIndex = preset.GatePresetIndex;
        RandomizerSettings.Instance.AllowBossFightEscapeCheckBox.IsChecked = preset.AllowBossFightEscape;
        RandomizerSettings.Instance.ScaleCheckBox.IsChecked = preset.ScaleBosses;
        RandomizerSettings.Instance.ScalingDifficultyBox.SelectedIndex = preset.ScalingDifficulty;
        RandomizerSettings.Instance.WinConditionBox.SelectedIndex =  preset.WinCondition;
        RandomizerControllBar.Instance.SeedTextBox.Text = preset.Seed.ToString();
        RandomizerControllBar.Instance.SeedTextBox.RevealPassword = preset.ShowSeed;
    }
    public static List<RandomizerSaveSettings> GetPresets()
    {
        if(!File.Exists(_presetPath)) return new List<RandomizerSaveSettings>();
        string[] presetPaths = Directory.GetFiles(_presetPath, "*.json", SearchOption.TopDirectoryOnly);
        List<RandomizerSaveSettings> result = new List<RandomizerSaveSettings>();

        foreach (string presetPath in presetPaths)
        {
            RandomizerSaveSettings? settings = JsonSerializer.Deserialize<RandomizerSaveSettings>(File.ReadAllText(presetPath));
            if (settings == null)
            {
                Console.WriteLine("Error Deserializing Json Preset " +  presetPath);
                continue;
            }
            result.Add(settings);
        }

        return result;
    }
    
    public static bool SaveCurrentSettingsToPreset(string? presetName)
    {
        if (presetName == null || 
            presetName.Any( x => Path.GetInvalidFileNameChars().Contains(x)) ||
            presetName == string.Empty)
        {
            Console.WriteLine("Preset name is null");
            UiUtil.ShowMessageBoxAsync(TopLevel.GetTopLevel(RandomizerControllBar.Instance) as Window, "Preset name is invalid");
            return false;
        }
        
        EnsureSavePathExists();
        
        RandomizerSaveSettings? currentSettings = GetSaveSettingsFromCurrent(presetName);
        if (currentSettings == null) return false;
        
        JsonSerializerOptions options = new JsonSerializerOptions{ WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(currentSettings, options);
        File.WriteAllText(Path.Join(_presetPath, presetName + ".json"), jsonString);

        Console.WriteLine($"Saved preset at {Path.Join(_presetPath, presetName + ".json")}");
        
        return true;
    }

    private static RandomizerSaveSettings? GetSaveSettingsFromCurrent(string presetName)
    {
        int seed;
        if (int.TryParse(RandomizerControllBar.Instance.SeedTextBox.Text, out seed))
        {
            return new RandomizerSaveSettings(
                presetName,
                RandomizerSettings.Instance.GatesComboBox.SelectedIndex,
                RandomizerSettings.Instance.AllowBossFightEscapeCheckBox.IsChecked.Value,
                RandomizerSettings.Instance.ScaleCheckBox.IsChecked.Value,
                RandomizerSettings.Instance.ScalingDifficultyBox.SelectedIndex,
                RandomizerSettings.Instance.WinConditionBox.SelectedIndex,
                seed,
                RandomizerControllBar.Instance.SeedTextBox.RevealPassword
            );
        }
        UiUtil.ShowMessageBoxAsync(TopLevel.GetTopLevel(RandomizerControllBar.Instance) as Window, "Seed is invalid");
        return null;
    }

    private static void EnsureSavePathExists()
    {
        if (!Directory.Exists(_presetPath))
        {
            Directory.CreateDirectory(_presetPath);
        }
    }
}