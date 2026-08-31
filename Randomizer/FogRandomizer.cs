using System;
using System.Collections.Generic;
using System.Linq;
using BB_Fog_Gate_Randomizer.Emevd;
using BB_Fog_Gate_Randomizer.Randomizer.Fog;

namespace BB_Fog_Gate_Randomizer.Randomizer;

public class FogRandomizer
{
    private int           _seed;
    private List<FogGate> _allGates;
    private FogGate       _startGate;
    private Random        _random;
    private bool          _produceLog;

    private List<FogGate> _unusedGates;

    public FogRandomizer(int seed, List<FogGate> gates, FogGate startGate, bool produceLog = true)
    {
        _seed = seed;
        _allGates = gates;
        _startGate = startGate;
        _random = new Random(seed);
        _produceLog = produceLog;
    }

    public int Randomize()
    {
         Generate(null);
         
         //FogGates.GateAfterIosefkasClinicToClinic.Link(FogGates.WarpBackToLesserAmygdala);
         
         return _unusedGates.Count;
    }

    private void Generate(List<FogGate>? noRequirementGates)
    { 
        PlayerState playerState = new PlayerState();
        
        _unusedGates = new List<FogGate>(_allGates);
        Queue<FogGate> queue = new Queue<FogGate>();
        List<FogGate> discovered = new List<FogGate>();
       
        queue.Enqueue(_startGate);
        _unusedGates.Remove(_startGate);
        discovered.Add(_startGate);
       
        while (queue.Count > 0)
        {    
           FogGate current = queue.Dequeue();

           FogGate? randomDestination;
           randomDestination = GetCompletelyUnusedFogGate(_unusedGates, discovered);
           if(randomDestination == null) randomDestination = GetRandomGate(_unusedGates);
           
           if (randomDestination == null)
           {
               Console.WriteLine("Random Gate was null");
               break;
           }
           
           current.Link(randomDestination);
           
           _unusedGates.Remove(randomDestination);
           _unusedGates.Remove(current);
           
           discovered.Add(randomDestination);
           
           playerState.Collect(randomDestination);
           
           foreach (var neighbour in randomDestination.WalkNeighbours)
           {
               //Skip this neighbour, if it isn't supposed to be randomized
               //Crude fix, neighbours should correspond, to preset gate preset choosen
               if (!_allGates.Contains(neighbour)) continue;
               //Best Case, Gate is accessible already
               if (neighbour.IsAccessible(playerState) || (noRequirementGates?.Any(gate => gate ==  neighbour) ?? false))
               {
                   if (!discovered.Contains(neighbour))
                   {
                       playerState.Collect(neighbour);
                       
                       queue.Enqueue(neighbour);
                       _unusedGates.Remove(neighbour);
                       discovered.Add(neighbour);
                   }
               }
               else
               {
                   FogRandomizer lookAheadRando = new FogRandomizer(_seed, _allGates, _startGate, false);
                   if (noRequirementGates == null) noRequirementGates = new List<FogGate>();
                   noRequirementGates.Add(neighbour);
                   lookAheadRando.Generate(noRequirementGates);
                   
                    if (PlayerSimulation.IsValid(_startGate))
                    {
                        Console.WriteLine("Valid tree");
                        if (!discovered.Contains(neighbour))
                        {
                            playerState.Collect(neighbour);
                            queue.Enqueue(neighbour);
                            discovered.Add(neighbour);
                            _unusedGates.Remove(neighbour);
                        }
                    }
               }
           }
        }

        if (_produceLog)
        {
            Console.WriteLine("Unused Gates: " +  _unusedGates.Count + " Discovered Gates: " +  discovered.Count);
            foreach (var gate in _unusedGates)
            {
                Console.WriteLine(gate.Name + " (" + gate.WalkNeighbours.Count + ")");
            }
        }
    }

    private FogGate? GetCompletelyUnusedFogGate(List<FogGate> gates, List<FogGate> unusedGates)
    {
        return GetRandomGate(gates.Except(unusedGates).ToList());
    }

    private FogGate? GetRandomGate(List<FogGate> gates)
    {
        int random = _random.Next(3);
        if (random < 2)
        {
            FogGate? corridorCandidate = GetRandomCorridor(gates);
            if(corridorCandidate != null) return corridorCandidate;
        }
        
        FogGate? crossingCandidate = GetRandomCross(gates);
        if(crossingCandidate != null) return crossingCandidate;
        
        FogGate? deadEndCandidate = GetRandomDeadEnd(gates);
        if(deadEndCandidate != null)
        {
            return deadEndCandidate;
        }

        if (gates.Count > 0)
        {
            FogGate lastResortCandidate = gates[_random.Next(0, gates.Count)];
            return lastResortCandidate;
        }
        
       
        Console.WriteLine("No more gates");
        return null;
    }
    
    private FogGate? GetRandomCross(List<FogGate> gates)
    {
        List<FogGate> candidates = gates.Where(gate => gate.WalkNeighbours.Count > 1).ToList();
        if(candidates.Count == 0) return null;
        return candidates[_random.Next(candidates.Count)];
    }

    private FogGate? GetRandomCorridor(List<FogGate> gates)
    {
        List<FogGate> candidates = gates.Where(gate => gate.WalkNeighbours.Count == 1).ToList();
        if(candidates.Count == 0) return null;
        return candidates[_random.Next(candidates.Count)];
    }
    
    private FogGate? GetRandomDeadEnd(List<FogGate> gates)
    {
        List<FogGate> candidates = gates.Where(gate => gate.WalkNeighbours.Count == 0).ToList();
        if(candidates.Count == 0) return null;
        return candidates[_random.Next(candidates.Count)];
    }

    public void WriteToEmevd()
    {
        EmevdHelper.WriteWarpsToEmevd(_startGate);
    }

    public FogGate GetStartGate()
    {
        return _startGate;
    }
    public int GetSeed()
    {
        return _seed;
    }

    public List<FogGate> GetGates()
    {
        return _allGates;
    }
}