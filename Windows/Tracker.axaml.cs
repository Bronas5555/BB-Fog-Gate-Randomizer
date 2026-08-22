using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using BB_Fog_Gate_Randomizer.Randomizer.Fog;

namespace BB_Fog_Gate_Randomizer.Windows;

public partial class Tracker : Window
{
    public static Tracker? Instance;

    private FogGate _startGate = new FogGate("", -1, -1, Maps.Empty);
    private FogGate? _currentGate;
    
    private int _warpDelay;
    private bool _isLoading = false;
    
    public Tracker()
    {
        InitializeComponent();
        Instance = this;
        
        _startGate.SetupWalkNeighbours([FogGates.GateAfterIosefkasClinicToClinic]);
        _currentGate = _startGate;

        _warpDelay = 7;
        
        Display(_startGate, true);
        
        KeyDown += TrackerWindow_KeyDown;
        Closing += TrackerWindow_Closing;
        
        ReturnToStartButton.Click += ReturnToStartButton_Click;
        WarpDelayBox.TextChanging += WarpDelayBox_TextChanged;
    }

    private void WarpDelayBox_TextChanged(object? sender, TextChangingEventArgs e)
    {
        string? text = WarpDelayBox.Text;
        if(text == null) return;
        if (int.TryParse(text, out var i))
        {
            _warpDelay = i;
        }
    }

    private void ReturnToStartButton_Click(object? sender, RoutedEventArgs e)
    {
        _currentGate = _startGate;
        Display(_startGate, true);
    }

    private void TrackerWindow_Closing(object? sender, CancelEventArgs e)
    {
        e.Cancel = true;
        Hide();
    }
    
    private void TrackerWindow_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyModifiers != KeyModifiers.Shift) return;
        if(_isLoading) return;
        
        try
        {
            switch (e.Key)
            {
                case Key.D0: Display(_currentGate?.LinkedFogGate, true); break;
                case Key.D1: Display(_currentGate?.WalkNeighbours[0].LinkedFogGate ?? null); break;
                case Key.D2: Display(_currentGate?.WalkNeighbours[1].LinkedFogGate ?? null); break;
                case Key.D3: Display(_currentGate?.WalkNeighbours[2].LinkedFogGate ?? null); break;
                case Key.D4: Display(_currentGate?.WalkNeighbours[3].LinkedFogGate ?? null); break;
                case Key.D5: Display(_currentGate?.WalkNeighbours[4].LinkedFogGate ?? null); break;
                case Key.D6: Display(_currentGate?.WalkNeighbours[5].LinkedFogGate ?? null); break;
                case Key.D7: Display(_currentGate?.WalkNeighbours[6].LinkedFogGate ?? null); break;
                case Key.D8: Display(_currentGate?.WalkNeighbours[7].LinkedFogGate ?? null); break;
                
            }
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }

    private void Display(FogGate? gate, bool overWriteWait = false)
    {
        _ = DisplayAsync(gate, overWriteWait);
    }

    private async Task DisplayAsync(FogGate? gate, bool overWriteWait = false)
    {
        if(gate == null) return;
        
        WalkableGatesBlock.Text = "";
        CurrentGateBlock.Text = "";
        _currentGate = gate;

        _isLoading = true;
        if(!overWriteWait)
            await Task.Delay(_warpDelay * 1000);
        _isLoading = false;
        
        CurrentGateBlock.Text = "0. " + gate.MapName.Name + ": " + gate.Name;

        int i = 1;
        foreach (var neighbour in gate.WalkNeighbours)
        {
            WalkableGatesBlock.Text += i + ". " + neighbour.MapName.Name + ": " + neighbour.Name + "\n";
            i++;
        }
    }
}