using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BB_Fog_Gate_Randomizer.Randomizer.Fog;

namespace BB_Fog_Gate_Randomizer.Randomizer.Util;

public class SpoilerLogBuilder
{
    private static HashSet<FogGate> printedGates;
    
    public static string CreateSpoilerLogString(FogRandomizer randomizer)
    {
        printedGates = new HashSet<FogGate>();
        var sb = new StringBuilder();

        sb.AppendLine($"Seed: {randomizer.GetSeed()}");
        
        Print(randomizer.GetStartGate(), sb);

        return sb.ToString();
    }

    private static void Print(
        FogGate gate,
        StringBuilder sb,
        string indent = "",
        bool isLast = true)
    {
        bool visited = printedGates.Contains(gate);

        string connector = isLast ? "└── " : "├── ";

        if (gate.Requirements.Count > 0)
        {
            sb.AppendLine(
                $"{indent}{connector}[Go] {gate.MapName.Name}: {gate.Name} " +
                $"(Requires: {BuildRequirementsString(gate)}) " +
                $"{(visited ? "(Loop)" : "")}");
        }
        else
        {
            sb.AppendLine(
                $"{indent}{connector}[Go] {gate.MapName.Name}: {gate.Name} " +
                $"{(visited ? "(Loop)" : "")}");
        }

        if (visited)
            return;

        printedGates.Add(gate);

        if (gate.LinkedFogGate == null)
            return;

        string warpIndent = indent + (isLast ? "    " : "│   ");

        if (gate.LinkedFogGate.Rewards.Count > 0)
        {
            sb.AppendLine(
                $"{warpIndent}└── [Warp] " +
                $"{gate.LinkedFogGate.MapName.Name}: {gate.LinkedFogGate.Name} " +
                $"(Reward: {BuildRewardsString(gate.LinkedFogGate)})");
        }
        else
        {
            sb.AppendLine(
                $"{warpIndent}└── [Warp] " +
                $"{gate.LinkedFogGate.MapName.Name}: {gate.LinkedFogGate.Name}");
        }

        printedGates.Add(gate.LinkedFogGate);

        var children = gate.LinkedFogGate.WalkNeighbours;

        for (int i = 0; i < children.Count; i++)
        {
            bool childIsLast = i == children.Count - 1;

            Print(
                children[i],
                sb,
                indent + (isLast ? "    " : "│   ") + "    ",
                childIsLast);
        }
    }

    private static string BuildRequirementsString(FogGate gate)
    {
        string result = "";
        foreach (var requirement in gate.Requirements)
        {
            if (gate.Requirements.IndexOf(requirement) == gate.Requirements.Count - 1)
            {
                result += requirement.ToString();
            }
            else
            {
                result += requirement.ToString() + ", ";
            }
            
        }
        return result;
    }
    private static string BuildRewardsString(FogGate gate)
    {
        string result = "";
        foreach (var reward in gate.Rewards)
        {
            if (gate.Rewards.IndexOf(reward) == gate.Rewards.Count - 1)
            {
                result += reward.ToString();
            }
            else
            {
                result += reward.ToString() + ", ";
            }
            
        }
        return result;
    }

    public static void SaveSpoilerLog(string spoilerLog)
    {
        if (!Directory.Exists("./Spoiler Logs/"))
        {
            Directory.CreateDirectory("./Spoiler Logs/");
        }
        File.WriteAllText("./Spoiler Logs/spoiler_" + DateTime.Now.ToString("yy-MM-dd HH-mm-ss") + ".log", spoilerLog);
    }
}