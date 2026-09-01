using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BB_Fog_Gate_Randomizer.Windows;

namespace BB_Fog_Gate_Randomizer.DarkScript3API;

public class DarkScript3
{
    private static readonly string DarkScriptExe = "./binarys/DarkScript3.exe";
    private static string _winePath = "/usr/bin/wine";
    private static string? _winePrefixPath = null;
    public static async Task BatchDecompileAsync(string sourceFolder, string outputFolder)
    {
        if(OperatingSystem.IsWindows()) await BatchDecompileWindows(sourceFolder, outputFolder);
        else if(OperatingSystem.IsLinux()) await BatchDecompileLinux(sourceFolder, outputFolder);
        else Console.WriteLine("Unsupported Operating System");
    }

    private static async Task BatchDecompileLinux(string sourceFolder, string outputFolder)
    {
        ProcessStartInfo psi = LinuxSetupProcessStartInfoWithoutEnviromentVariables();
        
        string args = $"{DarkScriptExe} " +
                      $"/cmd " +
                      $"-game bb " +
                      $"-indir \"{Path.GetFullPath(sourceFolder)}\" " +
                      $"-outdir \"{Path.GetFullPath(outputFolder)}\" " +
                      $"-decompile " +
                      $"-force " +
                      $"-incremental";
        psi.Arguments = args;

        Process darkScript3Process = new Process();
        darkScript3Process.StartInfo = psi;

        darkScript3Process.Start();
        
        await darkScript3Process.WaitForExitAsync();
        
        Console.WriteLine(psi.FileName + " " + psi.Arguments);
    }

    private static async Task BatchDecompileWindows(string sourceFolder, string outputFolder)
    {
        string args = $"/cmd -game bb -indir {sourceFolder} -outdir {outputFolder} -decompile -force -incremental";
        Process darkScript3Process = Process.Start(DarkScriptExe, args);
        await darkScript3Process.WaitForExitAsync();
    }

    public static async Task BatchRecompileAsync(string sourceFolder, string outputFolder)
    {
        if(OperatingSystem.IsWindows()) await BatchRecompileWindows(sourceFolder, outputFolder);
        else if(OperatingSystem.IsLinux()) await BatchRecompileLinux(sourceFolder, outputFolder);
        else Console.WriteLine("Unsupported Operating System");
    }

    private static async Task BatchRecompileLinux(string sourceFolder, string outputFolder)
    {
        ProcessStartInfo psi = LinuxSetupProcessStartInfoWithoutEnviromentVariables();
        
        psi.Environment.Add("WINEPREFIX", "/home/jonas/.bbfoggaterandoprefix/");
        
        string args = $"{DarkScriptExe} " +
                      $"/cmd " +
                      $"-game bb " +
                      $"-indir \"{sourceFolder}\" " +
                      $"-outdir \"{outputFolder}\" " +
                      $"-compile " +
                      $"-force " +
                      $"-incremental";
        psi.Arguments = args;
        
        Process darkScript3Process = Process.Start(psi);
        
        await darkScript3Process.WaitForExitAsync();
        
        Console.WriteLine(psi.FileName + " " + psi.Arguments);
    }

    private static async Task BatchRecompileWindows(string sourceFolder, string outputFolder)
    {
        string args = $"/cmd -game bb -indir {sourceFolder} .outdir {outputFolder} -compile -force -incremental";
        
        Process darkScript3Process = Process.Start(DarkScriptExe, args);
        await darkScript3Process.WaitForExitAsync();
    }

    private static ProcessStartInfo LinuxSetupProcessStartInfoWithoutEnviromentVariables()
    {
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = _winePath,
        };
        
        //Removing Enviroment Variables injected by Rider
        foreach (var key in psi.Environment.Keys
                     .Where(k => k.StartsWith("DOTNET_", StringComparison.OrdinalIgnoreCase))
                     .ToList())
        {
            psi.Environment.Remove(key);
        }
        foreach (var key in psi.Environment.Keys
                     .Where(k => k.StartsWith("COMPlus_", StringComparison.OrdinalIgnoreCase))
                     .ToList())
        {
            psi.Environment.Remove(key);
        }
        
        //TODO: Let user choose wineprefix
        psi.Environment.Add("WINEPREFIX", _winePrefixPath);

        return psi;
    }
    public static void SetWinePrefixPath(string path)
    {
        _winePrefixPath = path;

        File.WriteAllText("./config.txt", path);
        
    }

    public static void LoadWinePrefixPath()
    {
        if (File.Exists("./config.txt"))
        {
            _winePrefixPath = File.ReadAllText("./config.txt");
            Console.WriteLine("Loaded Wine Prefix Path: " + _winePrefixPath);
        }
    }
}