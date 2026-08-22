using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;

namespace BB_Fog_Gate_Randomizer.Util;

public class UiUtil
{
    public static async Task ShowErrorAsync(Window owner, string message)
    {
        var dialog = new Window
        {
            Title = "Error",
            Width = 400,
            Height = 200,
            WindowStartupLocation = WindowStartupLocation.CenterOwner,
            Content = new Grid
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                RowDefinitions = new RowDefinitions("*, Auto"),
                Margin = new Thickness(20),
                Children =
                {
                    new TextBlock
                    {
                        Text = message,
                        TextWrapping = TextWrapping.Wrap,
                        VerticalAlignment = VerticalAlignment.Top,
                        HorizontalAlignment = HorizontalAlignment.Center
                    },
                    new Button
                    {
                        Content = "OK",
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Bottom
                    }
                }
            }
        };
        if (dialog.Content is Grid panel &&
            panel.Children[1] is Button button)
        {
            Console.WriteLine("Ok");
            button.Click += (_, _) => dialog.Close();
        }

        await dialog.ShowDialog(owner);
    }
}