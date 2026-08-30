using System.IO;

namespace BB_Fog_Gate_Randomizer.Util;

public class ModBuilder
{
    public static void CopyModdedMapFilesToModFolder()
    {
        string sourceDir = "./Assets/Mod/dvdroot_ps4/map";
        string destinationDir = "./Fog Gate Randomizer/Fog Gate Randomizer/dvdroot_ps4/map";
        FileUtil.CopyDirectory(sourceDir, destinationDir);
    }

    public static void DeleteCreatedModFiles()
    {
        Directory.Delete("./Fog Gate Randomizer/Fog Gate Randomizer/", true);
    }
}