using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using BB_Fog_Gate_Randomizer.Randomizer;
using BB_Fog_Gate_Randomizer.Randomizer.Fog;

namespace BB_Fog_Gate_Randomizer.Testing;

public class RandomizerBenchmark
{
    private static readonly int TestCount = 50000;
    public static void StartBenchmark()
    {
        Random rnd = new Random();

        List<int> results = new List<int>();
        
        for (int i = 0; i < TestCount; i++)
        {
            FogRandomizer rando = new FogRandomizer(
                rnd.Next(int.MinValue, int.MaxValue),
                GatePresets.AllFogGates,
                FogGates.GateAfterIosefkasClinicToClinic,
                false);
            results.Add(rando.Randomize());
        }

        var counts = results
            .GroupBy(n => n)
            .OrderByDescending(g => g.Count());
        
        foreach (var group in counts)
        {
            Console.WriteLine($"{group.Key} exists {group.Count()} times ({((float)group.Count() / TestCount) * 100})");
        }
    }
}