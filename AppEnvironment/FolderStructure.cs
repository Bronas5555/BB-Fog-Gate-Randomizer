using System.IO;

namespace BB_Fog_Gate_Randomizer.AppEnvironment;

public class FolderStructure
{
    public static void EnsureFolderStructure()
    {
        if(!Directory.Exists("./binarys")) 
            Directory.CreateDirectory("./binarys");
    }
}