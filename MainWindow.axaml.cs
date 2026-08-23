using System;
using Avalonia.Controls;
using BB_Fog_Gate_Randomizer.AppEnvironment;
using BB_Fog_Gate_Randomizer.DarkScript3API;
using BB_Fog_Gate_Randomizer.Randomizer;
using BB_Fog_Gate_Randomizer.Randomizer.Fog;
using BB_Fog_Gate_Randomizer.Randomizer.Scaling;
using BB_Fog_Gate_Randomizer.Randomizer.Util;
using BB_Fog_Gate_Randomizer.Testing;
using BB_Fog_Gate_Randomizer.Util;

namespace BB_Fog_Gate_Randomizer;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        //FogGates.SetupWalkNeighbours();
        Console.WriteLine("All Gates: " + GatePresets.AllFogGates.Count);
        
        //RandomizerBenchmark.StartBenchmark();
        
        FolderStructure.EnsureFolderStructure();
    }
}