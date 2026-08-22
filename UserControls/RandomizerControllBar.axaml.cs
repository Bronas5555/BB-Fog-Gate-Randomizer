using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using BB_Fog_Gate_Randomizer.DarkScript3API;
using BB_Fog_Gate_Randomizer.Emevd;
using BB_Fog_Gate_Randomizer.Presets;
using BB_Fog_Gate_Randomizer.Randomizer;
using BB_Fog_Gate_Randomizer.Randomizer.Fog;
using BB_Fog_Gate_Randomizer.Randomizer.Scaling;
using BB_Fog_Gate_Randomizer.Randomizer.Util;
using BB_Fog_Gate_Randomizer.Util;
using BB_Fog_Gate_Randomizer.Windows;

namespace BB_Fog_Gate_Randomizer.UserControls;

public partial class RandomizerControllBar : UserControl
{
    public static RandomizerControllBar Instance;
    private List<RandomizerSaveSettings> _saveSettings;
    public RandomizerControllBar()
    {
        InitializeComponent();

        Instance = this;
        _saveSettings = new List<RandomizerSaveSettings>();
        
        RandomizeButton.Click += RandomizeButton_Click;
        GenerateNewSeedButton.Click += GenerateNewSeedButton_Click;
        OpenModFolderButton.Click += OpenModFolderButton_Click;
        SpoilerLogsButton.Click += SpoilerLogsButton_Click;
        HideSeedButton.Click += HideSeedButton_Click;
        TrackerButton.Click += TrackerButton_Click;
        SavePresetButton.Click += SavePresetButton_Click;
        LoadPresetButton.Click += LoadPresetButton_Click;
        DeletePresetButton.Click += DeletePresetButton_Click;
        PresetFolderButton.Click += PresetFolderButton_Click;
            
        ReloadPresets();
    }

    private void PresetFolderButton_Click(object? sender, RoutedEventArgs e)
    {
        PresetManager.OpenPresetFolder();
    }

    private void DeletePresetButton_Click(object? sender, RoutedEventArgs e)
    {
        if (_saveSettings.Count == 0 || PresetComboBox.SelectedIndex == -1) return;
        PresetManager.DeletePreset(_saveSettings[PresetComboBox.SelectedIndex]);
        PresetComboBox.SelectedIndex = -1;
        PresetNameTextBox.Text = "";
        ReloadPresets();
    }

    private void LoadPresetButton_Click(object? sender, RoutedEventArgs e)
    {
        if (_saveSettings.Count == 0 || PresetComboBox.SelectedIndex == -1) return;
        PresetNameTextBox.Text = _saveSettings[PresetComboBox.SelectedIndex].PresetName;
        PresetManager.LoadPreset(_saveSettings[PresetComboBox.SelectedIndex]);
    }

    private void ReloadPresets()
    {
        _saveSettings = PresetManager.GetPresets();

        PresetComboBox.Items.Clear();
        foreach (var settings in _saveSettings)
        {
            PresetComboBox.Items.Add(settings.PresetName);
        }
    }

    private void SavePresetButton_Click(object? sender, RoutedEventArgs e)
    {
        if (!PresetManager.SaveCurrentSettingsToPreset(PresetNameTextBox.Text))
        {
            Console.WriteLine("Saving preset failed");
        }
        ReloadPresets();
    }

    private void TrackerButton_Click(object? sender, RoutedEventArgs e)
    {
        if (Tracker.Instance != null)
        {
            Tracker.Instance.Show();
        }
        else
        {
            Tracker trackerWindow = new Tracker();
            trackerWindow.Show();
        }
    }

    private void HideSeedButton_Click(object? sender, RoutedEventArgs e)
    {
        if (SeedTextBox.RevealPassword)
        {
            SeedTextBox.RevealPassword = false;
            HideSeedButtonLabel.Text = "H";
        }
        else
        {
            SeedTextBox.RevealPassword = true;
            HideSeedButtonLabel.Text = "S";
        }
    }

    private void SpoilerLogsButton_Click(object? sender, RoutedEventArgs e)
    {
        FileUtil.OpenDirectoryInFileManager("./Spoiler Logs");
    }

    private void OpenModFolderButton_Click(object? sender, RoutedEventArgs e)
    {
        FileUtil.OpenDirectoryInFileManager("./Fog Gate Randomizer");
    }

    private void RandomizeButton_Click(object? sender, RoutedEventArgs e)
    {
        if (!ValidateSeedInput())
        {
            UiUtil.ShowErrorAsync(TopLevel.GetTopLevel(this) as Window, "Invalid Seed");
            return;
        }

        RandomizerProgressWindow progressWindow = new RandomizerProgressWindow();
        progressWindow.ShowDialog(TopLevel.GetTopLevel(this) as Window);
        try
        {
            _ = RandomizeAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        
    }

    private void GenerateNewSeedButton_Click(object? sender, RoutedEventArgs e)
    {
        Random rnd = new Random();
        SeedTextBox.Text = rnd.Next(int.MinValue, int.MaxValue).ToString();
    }

    private async Task RandomizeAsync()
    {
        RandomizerProgressWindow.AllowContinue(false);
        RandomizerProgressWindow.Clear();
        
        //Making Sure al EMEVD Event Files are decompiled
        RandomizerProgressWindow.AddLogLine("Decompiling Game Files");
        await DarkScript3.BatchDecompileAsync("./Assets/Mod/dvdroot_ps4/event", "./WorkingDirectory");
        
        RandomizerProgressWindow.AddLogLine("Randomizing World");

        List<FogGate> gates;
        switch (RandomizerSettings.Instance.GatesComboBox.SelectedIndex)
        {
            case 0: gates = GatePresets.AllFogGates; break;
            case 1: gates = GatePresets.AllFogGatesNoDlc; break;
            case 2: gates = GatePresets.BossGatesOnly; break;
            case 3: gates = GatePresets.BossGatesOnlyNoDlc; break;
            default: throw new ArgumentOutOfRangeException();
        }
        FogGates.SetupWalkNeighbours(RandomizerSettings.Instance.GatesComboBox.SelectedIndex);
        
        FogRandomizer? randomizer = new FogRandomizer(
            int.Parse(SeedTextBox.Text),
            gates,
            FogGates.GateAfterIosefkasClinicToClinic); //TODO: Implement different gate presets' start gates
        
        randomizer = RandomizeEnsureCompletability(randomizer);
        
        if(randomizer == null)
        {
            Console.WriteLine("Randomizer failed");
            return;
        }
        //randomizer.Randomize();
        
        RandomizerProgressWindow.AddLogLine("Writing Events");
        randomizer.WriteToEmevd();
        
        EmevdHelper.WriteWinCondition(RandomizerSettings.Instance.WinConditionBox.SelectedIndex);

        if (RandomizerSettings.Instance.ScaleCheckBox.IsChecked.Value)
        {
            RandomizerProgressWindow.AddLogLine("Scaling Bosses");
            GameScaler scaler = new GameScaler(randomizer.GetStartGate());
            scaler.ScaleBosses();
        }
        
        RandomizerProgressWindow.AddLogLine("Recompiling Game Files");
        await DarkScript3.BatchRecompileAsync("./WorkingDirectory", "./Fog Gate Randomizer/Fog Gate Randomizer/dvdroot_ps4/event");
        
        RandomizerProgressWindow.AddLogLine("Copying Map Files");
        //Copys modified Map Files to mod output folder
        ModBuilder.CopyModdedMapFilesToModFolder();
        
        RandomizerProgressWindow.AddLogLine("Creating Spoiler Log");
        try
        {
            string spoilerLog = SpoilerLogBuilder.CreateSpoilerLogString(randomizer);
            Console.WriteLine(spoilerLog);
            SpoilerLogBuilder.SaveSpoilerLog(spoilerLog);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        
        RandomizerProgressWindow.AddLogLine("Finished");
        RandomizerProgressWindow.AllowContinue(true);
        
        Console.WriteLine(PlayerSimulation.IsValid(FogGates.GateAfterIosefkasClinicToClinic));
    }

    private FogRandomizer? RandomizeEnsureCompletability(FogRandomizer startRandomizer)
    {
        FogRandomizer currentRando =  startRandomizer;
        int j = 0;
        for (int i = 0; i < 1024; i++)
        {
            Console.WriteLine("[Randomizer] Randomizing Try: " + i);
            if (currentRando.Randomize() == 0)
            {
                j = i;
                break;
            }
            Random rnd = new Random(currentRando.GetSeed());
            currentRando = new FogRandomizer(
                rnd.Next(int.MinValue, int.MaxValue), 
                currentRando.GetGates(),
                currentRando.GetStartGate());
            Console.WriteLine("[Randomizer] New Try with Seed: " + currentRando.GetSeed());
            if(i == 1023)
            {
                Console.WriteLine("Failure");
                return null;
            }
        }
        Console.WriteLine("Randomized Completable with " + j + " trys");

        return currentRando;
    }
    
    private bool ValidateSeedInput()
    {
        string? text = SeedTextBox.Text;
        return !string.IsNullOrEmpty(text) && text.All(c => char.IsDigit(c) || c == '-');
    }
}