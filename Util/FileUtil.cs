using System;
using System.Diagnostics;
using System.IO;

namespace BB_Fog_Gate_Randomizer.Util;

public class FileUtil
{
    public static void CopyDirectory(string sourceDir, string destinationDir)
    {
        Directory.CreateDirectory(destinationDir);

        foreach (string file in Directory.GetFiles(sourceDir))
        {
            string fileName = Path.GetFileName(file);
            string destinationFile = Path.Combine(destinationDir, fileName);

            File.Copy(file, destinationFile, overwrite: true);
        }

        foreach (string directory in Directory.GetDirectories(sourceDir))
        {
            string directoryName = Path.GetFileName(directory);
            string destinationSubDir = Path.Combine(destinationDir, directoryName);

            CopyDirectory(directory, destinationSubDir);
        }
    }
    public static void OpenDirectoryInFileManager(string directory)
    {
        if(OperatingSystem.IsWindows()) OpenDirectoryInFileManagerWindows(directory);
        else if(OperatingSystem.IsLinux()) OpenDirectoryInFileManagerLinux(directory);
        else throw new Exception("Unsupported operating system");
        
    }

    private static void OpenDirectoryInFileManagerWindows(string directory)
    {
        string fullPath = Path.GetFullPath(directory);

        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = "explorer.exe",
            UseShellExecute = true
        };
        psi.ArgumentList.Add(fullPath);
        Process.Start(psi);
    }
    private static void OpenDirectoryInFileManagerLinux(string directory)
    {
        if(!Directory.Exists(directory))
            throw new DirectoryNotFoundException(directory);

        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = directory,
            UseShellExecute = true
        };
        Process.Start(psi);
    }
}