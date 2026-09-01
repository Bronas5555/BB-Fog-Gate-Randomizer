using System.IO;
using Avalonia.Controls;
using BB_Fog_Gate_Randomizer.UserControls;
using BB_Fog_Gate_Randomizer.Util;

namespace BB_Fog_Gate_Randomizer.AppEnvironment;

public class FolderStructure
{
    public static void EnsureFolderStructure()
    {
        if(!Directory.Exists("./binarys")) 
            Directory.CreateDirectory("./binarys");
        if (!File.Exists("./binarys/DarkScript3.exe"))
        {
            UiUtil.ShowMessageBoxAsync(
                TopLevel.GetTopLevel(RandomizerControllBar.Instance) as Window, 
                "DarkScript3.exe not found in the binarys Directory. The Randomizer needs this File to function. Download and extract it and all its accompanying Files to the binarys Directory in the Randomizer Application Directory.");
        }
    }
}