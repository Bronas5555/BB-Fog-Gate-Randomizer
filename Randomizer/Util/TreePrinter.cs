using System;
using System.Collections.Generic;
using System.Linq;
using BB_Fog_Gate_Randomizer.Randomizer.Fog;

namespace BB_Fog_Gate_Randomizer.Randomizer.Util;

public class TreePrinter
{
    private static HashSet<FogGate> printedGates;
    public static void PrintTree(FogGate startGate)
    {
        printedGates = new HashSet<FogGate>();
        Print(startGate);
    }
    
    private static void Print(FogGate gate, string indent = "", bool isLast = true)
    {
        bool visited = printedGates.Contains(gate);

        if (gate.Requirements.Count > 0)
        {
            Console.WriteLine($"{indent}{(isLast ? "└── " : "├── ")}[Go] {gate.MapName.Name}: {gate.Name} " + " (Requires: " + gate.Requirements[0] + ") "+ (visited ? "(Loop)" : ""));
        }
        else
        {
            Console.WriteLine($"{indent}{(isLast ? "└── " : "├── ")}[Go] {gate.MapName.Name}: {gate.Name} " + (visited ? "(Loop)" : ""));
        }
        

        if (visited) return;
        
        printedGates.Add(gate);

        if (gate.LinkedFogGate == null)
            return;
        
        if (gate.LinkedFogGate.Rewards.Count > 0)
        {
            Console.WriteLine($"{indent}{(isLast ? "    " : "│   ")}└── [Warp] {gate.LinkedFogGate.MapName.Name}: {gate.LinkedFogGate.Name} (Reward: {gate.LinkedFogGate.Rewards[0]})");
        }
        else
        {
            Console.WriteLine($"{indent}{(isLast ? "    " : "│   ")}└── [Warp] {gate.LinkedFogGate.MapName.Name}: {gate.LinkedFogGate.Name}");
        }
        

        printedGates.Add(gate.LinkedFogGate);

        var children = gate.LinkedFogGate.WalkNeighbours;

        for (int i = 0; i < children.Count; i++)
        {
            bool childIsLast = i == children.Count - 1;

            Print(
                children[i],
                indent + (isLast ? "    " : "│   ") + "    ",
                childIsLast);
        }
    }
    
    public static void InteractiveWorldExploration(FogGate startGate)
    {
        Console.WriteLine("\n----------------------------------------------------------------------------------------------------------");
        Console.WriteLine("[Teleport] " + startGate.Name + " -> " + startGate.LinkedFogGate.Name);

        int i = 0;
        foreach (var neighbour in startGate.LinkedFogGate.WalkNeighbours)
        {
            Console.WriteLine("[" + i + "] " + neighbour.Name);
            i++;
        }

        try
        {
            int index = int.Parse(Console.ReadKey().KeyChar.ToString());

            InteractiveWorldExploration(startGate.LinkedFogGate.WalkNeighbours[index]);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            InteractiveWorldExploration(startGate);
        }
    }
    
}