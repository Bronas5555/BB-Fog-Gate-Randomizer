using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace BB_Fog_Gate_Randomizer.UserControls;

public partial class RandomizerSettings : UserControl
{
    public static RandomizerSettings Instance;
    public RandomizerSettings()
    {
        InitializeComponent();
        Instance = this;
    }
}