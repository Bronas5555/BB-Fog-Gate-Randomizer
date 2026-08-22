using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace BB_Fog_Gate_Randomizer.Windows;

public partial class RandomizerProgressWindow : Window
{
    private static RandomizerProgressWindow? _instance;
    public RandomizerProgressWindow()
    {
        InitializeComponent();
        _instance = this;
        BackButton.Click += (s, a) => Close();
    }

    public static void AddLogLine(string logLine)
    {
        if (_instance == null)
        {
            Console.WriteLine("No Window Instance");
            return;
        }
        Avalonia.Threading.Dispatcher.UIThread.Post(() =>
        {
            _instance.LogTextBox.Text += logLine + Environment.NewLine;
        });
    }

    public static void AllowContinue(bool allow)
    {
        if (_instance == null) return;
        if(allow) _instance.BackButton.IsEnabled = true;
        else _instance.BackButton.IsEnabled = false;
    }

    public static void Clear()
    {
        if (_instance == null) return;
        _instance.LogTextBox.Text = "";
    }
}