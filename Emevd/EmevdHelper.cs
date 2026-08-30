using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BB_Fog_Gate_Randomizer.Randomizer;
using BB_Fog_Gate_Randomizer.Randomizer.Fog;
using BB_Fog_Gate_Randomizer.UserControls;

namespace BB_Fog_Gate_Randomizer.Emevd;

public class EmevdHelper
{
    private static List<EmevdScript> _scripts;
    public static void WriteWarpsToEmevd(FogGate startGate)
    {
        _scripts = new List<EmevdScript>();
        
        Queue<FogGate> queue = new Queue<FogGate>();
        HashSet<FogGate> processedGates = new HashSet<FogGate>();
        
        queue.Enqueue(startGate);

        while (queue.Count > 0)
        {
            FogGate gate = queue.Dequeue();
            if(processedGates.Contains(gate)) continue;

            if (_scripts.All(script => script.Map != gate.MapName))
            {
                Console.WriteLine("Loading script: " + gate.MapName.Name + "_" + gate.MapName.Identifier + " for gate " + gate.Name);
                _scripts.Add(new EmevdScript(gate.MapName));
            }
                
            
            EmevdScript? emevdScript = _scripts.FirstOrDefault(script => script.Map == gate.MapName);
            if (emevdScript == null)
                throw new Exception("Couldn't find script: " + gate.MapName.Identifier + ". This shouldn't be possible.");

            (string eventString, int eventId)? warpEvent = GetEvent(gate);
            if (warpEvent == null) continue;
            
            emevdScript.AddEvent(warpEvent.Value.eventString, warpEvent.Value.eventId);
            
            //Other Side (Warp Back)
            if (gate.LinkedFogGate == null)
            {
                throw new InvalidOperationException("Gate is not linked, while other links to this. Huh?????");
            }
            if (_scripts.All(script => script.Map != gate.LinkedFogGate.MapName))
                _scripts.Add(new EmevdScript(gate.LinkedFogGate.MapName));
            
            EmevdScript? emevdScript2 = _scripts.FirstOrDefault(script => script.Map == gate.LinkedFogGate.MapName);
            if(emevdScript2 == null)
                throw new Exception("Couldn't find script: " + gate.MapName.Identifier + ". This shouldn't be possible.");
            
            (string eventString, int eventId)? linkedWarpEvent = GetEvent(gate.LinkedFogGate);
            if (linkedWarpEvent == null) continue;
            emevdScript2.AddEvent(linkedWarpEvent.Value.eventString, linkedWarpEvent.Value.eventId);
            
            processedGates.Add(gate);
            processedGates.Add(gate.LinkedFogGate);

            foreach (var neighbour in gate.LinkedFogGate.WalkNeighbours)
            {
                queue.Enqueue(neighbour);
            }
        }
        WriteEmevdToDisk();
    }

    private static void WriteEmevdToDisk()
    {
        foreach (var script in _scripts)
        {
            script.WriteToDisk();
        }
    }
    
    private static (string eventString, int eventId) BasicFogGateWarpEvent(MapName destinationMap, int interactionEntityId, int spawnPointEntityId)
    {
        int eventId = int.Parse("7" + interactionEntityId.ToString().Substring(1));
        return ($"$Event({eventId}, Default, function() {{\n" +
               $"   WaitFor(ActionButtonInArea(2410041, {interactionEntityId}));\n" +
               $"   WarpPlayer({destinationMap.AreaId}, {destinationMap.BlockId}, {spawnPointEntityId});\n" +
               $"}});\n", eventId);
    }
    
    private static (string eventString, int eventId) BasicWarpEvent(MapName destinationMap, int interactionEntityId, int spawnPointEntityId)
    {
        int eventId = int.Parse("7" + interactionEntityId.ToString().Substring(1));
        return ($"$Event({eventId}, Default, function() {{\n" +
                $"   WaitFor(ActionButtonInArea(2410041, {interactionEntityId}));\n" + //TODO: Find Id for Inspect / Interact instead of Traverse
                $"   WarpPlayer({destinationMap.AreaId}, {destinationMap.BlockId}, {spawnPointEntityId});\n" +
                $"}});\n", eventId);
    }
    
    private static (string eventString, int eventId) EventFlagFogGateWarpEvent(MapName destinationMap, int interactionEntityId, int spawnPointEntityId, int eventFlagId)
    {
        if(eventFlagId == 0) Console.WriteLine($"BAD: EventFlag is 0 for warp to {destinationMap.Name} Interaction: {interactionEntityId} spawnPoint: {spawnPointEntityId}");
        int eventId = int.Parse("7" + interactionEntityId.ToString().Substring(1));
        return ($"$Event({eventId}, Default, function() {{\n" +
                $"   WaitFor(EventFlag({eventFlagId}));\n" +
                $"   WaitFor(ActionButtonInArea(2410041, {interactionEntityId}));\n" +
                $"   WarpPlayer({destinationMap.AreaId}, {destinationMap.BlockId}, {spawnPointEntityId});\n" +
                $"}});\n", eventId);
    }
    
    private static (string eventString, int eventId) CastleCainhurtsWarpEvent(
        MapName destinationMap,
        int interactionEntityId, 
        int spawnPointEntityId)
    {
        int eventId = int.Parse("7" + interactionEntityId.ToString().Substring(1));
        return ($"$Event({eventId}, Default, function() {{\n" + 
                $"   WaitFor(PlayerHasItem(ItemType.Goods, 4003) && !CharacterDead(2201310) && ActionButtonInArea(2200010, {interactionEntityId}));\n" +
                $"   WaitFixedTimeFrames(1);" +
                $"   PlayCutsceneToPlayer(22000040, CutscenePlayMode.Skippable, 10000);" +
                $"   WaitFixedTimeFrames(1);" + 
                $"   WarpPlayer({destinationMap.AreaId}, {destinationMap.BlockId}, {spawnPointEntityId});\n" +
                $"}});\n", eventId);
    }

    private static (string eventString, int eventId) TonsilStoneWarpEvent(
        MapName destinationMap,
        int interactionEntityId,
        int spawnPointEntityId)
    {
        int eventId = int.Parse("7" + interactionEntityId.ToString().Substring(1));
        return ($"$Event({eventId}, Default, function() {{\n" + 
                $"   WaitFor(CharacterHasEventMessage(2800745, 10) && PlayerHasItem(ItemType.Goods, 4310));" +
                $"   SetCharacterImmortality(10000, Enabled);" +
                $"   WaitFixedTimeFrames(30);" +
                $"   if (!PlayerGender(Gender.Female)) {{" +
                $"      PlayCutsceneToPlayer(28000040, CutscenePlayMode.Unskippable, 10000);" +
                $"   }} else {{" +
                $"      PlayCutsceneToPlayer(28001040, CutscenePlayMode.Unskippable, 10000);" +
                $"   }}" +
                $"   WaitFixedTimeFrames(1);" +
                $"   WarpPlayer({destinationMap.AreaId}, {destinationMap.BlockId}, {spawnPointEntityId});\n" +
                $"}});\n", eventId);
    }
    
    private static (string eventString, int eventId) DLCWarpEvent(
        MapName destinationMap,
        int interactionEntityId,
        int spawnPointEntityId)
    {
        int eventId = int.Parse("7" + interactionEntityId.ToString().Substring(1));
        return ($"$Event({eventId}, Default, function() {{\n" + 
                $"   WaitFor(CharacterHasEventMessage(2400899, 710) && PlayerHasItem(ItemType.Goods, 4311));" +
                $"   SetCharacterImmortality(10000, Enabled);" +
                $"   WaitFixedTimeFrames(30);" +
                $"   PlayCutsceneToPlayer(24000000, CutscenePlayMode.Skippable, 10000);" +
                $"   WaitFixedTimeFrames(1);" +
                $"   WarpPlayer({destinationMap.AreaId}, {destinationMap.BlockId}, {spawnPointEntityId});\n" +
                $"}});\n", eventId);
    }

    private static (string eventString, int eventId)? GetEvent(FogGate gate)
    {
        if (gate.LinkedFogGate == null)
        {
            Console.WriteLine("Unlinked Fog Gate: " + gate.Name);
            return null;
        }
        
        switch (gate.WarpEventType)
        {
            case WarpEventType.FogGate:
            {
                return BasicFogGateWarpEvent(
                    gate.LinkedFogGate.MapName, 
                    gate.InteractionObjectEntityId,
                    gate.LinkedFogGate.SpawnPointEntityId);
            } break;
            case WarpEventType.FogGateEventFlag:
            {
                //If Boss Fight escapes are on, return normal event, regardeless of Event Flag
                if (RandomizerSettings.Instance.AllowBossFightEscapeCheckBox.IsChecked.Value)
                {
                    return BasicFogGateWarpEvent(
                        gate.LinkedFogGate.MapName, 
                        gate.InteractionObjectEntityId,
                        gate.LinkedFogGate.SpawnPointEntityId);
                }
                return EventFlagFogGateWarpEvent(
                    gate.LinkedFogGate.MapName, 
                    gate.InteractionObjectEntityId,
                    gate.LinkedFogGate.SpawnPointEntityId,
                    gate.RequiredEventFlag);
            } break;
            case WarpEventType.Warp:
            {
                return BasicWarpEvent(
                    gate.LinkedFogGate.MapName, 
                    gate.InteractionObjectEntityId,
                    gate.LinkedFogGate.SpawnPointEntityId);
            } break;
            case WarpEventType.CastleCainhurtsWarp:
            {
                return CastleCainhurtsWarpEvent(
                    gate.LinkedFogGate.MapName,
                    gate.InteractionObjectEntityId,
                    gate.LinkedFogGate.SpawnPointEntityId);
            } break;
            case WarpEventType.TonsilStoneWarp:
            {
                return TonsilStoneWarpEvent(
                    gate.LinkedFogGate.MapName,
                    gate.InteractionObjectEntityId,
                    gate.LinkedFogGate.SpawnPointEntityId);
            } break;
            case WarpEventType.DLCWarp:
            {
                return DLCWarpEvent(
                    gate.LinkedFogGate.MapName,
                    gate.InteractionObjectEntityId,
                    gate.LinkedFogGate.SpawnPointEntityId);
            } break;
            default:
            {
                return BasicWarpEvent(
                    gate.LinkedFogGate.MapName, 
                    gate.InteractionObjectEntityId,
                    gate.LinkedFogGate.SpawnPointEntityId);
            } break;
        }
    }

    public static void WriteWinCondition(int winConditionIndex)
    {
        EmevdScript huntersDreamScript = new EmevdScript(Maps.HuntersDream);

        switch (winConditionIndex)
        {
            case 0:
            {
                (string, int) ev = WetNurseKilledEvent();
                huntersDreamScript.AddEvent(ev.Item1, ev.Item2);
                break;
            }
            case 1:
            {
                (string, int) ev = AllBossesKilledEvent();
                huntersDreamScript.AddEvent(ev.Item1, ev.Item2);
                break;
            }
            case 3:
            {
                (string, int) ev = AllRequiredBossesKilledEvent();
                huntersDreamScript.AddEvent(ev.Item1, ev.Item2);
                break;
            }
            default: throw new NotImplementedException("Unknown win condition index: " + winConditionIndex);
        }
        huntersDreamScript.WriteToDisk();
    }

    private static (string eventString, int eventId) WetNurseKilledEvent()
    {
        return ($"$Event(92107200, Default, function() {{\n" +
                $"    WaitFor(EventFlag(12601800));\n" +
                $"    DeactivateObject(2101801, Disabled);\n" +
                $"}});\n", 
            92107200);
    }
    private static (string eventString, int eventId) AllBossesKilledEvent()
    {
        return ($"$Event(92107200, Default, function() {{\n" +
                $"    WaitFor(EventFlag(12201800) && EventFlag(12301800) && EventFlag(12411800) && EventFlag(12801800) && EventFlag(12421700) && EventFlag(12421800) && EventFlag(12501800) && EventFlag(12411700) && EventFlag(12401800) && EventFlag(12301800) && EventFlag(12701800) && EventFlag(13201800) && EventFlag(12301700) && EventFlag(13301800) && EventFlag(12601800) && EventFlag(12601850) && EventFlag(13401850) && EventFlag(9471) && EventFlag(13501850) && EventFlag(13501800) && EventFlag(13601800));\n" +
                $"    DeactivateObject(2101801, Disabled);\n" +
                $"}});\n", 
            92107200);
    }
    private static (string eventString, int eventId) AllRequiredBossesKilledEvent()
    {
        return ($"$Event(92107200, Default, function() {{\n" +
                $"    WaitFor(EventFlag(12411800) && EventFlag(12401800) && EventFlag(12701800) && EventFlag(13201800) && EventFlag(12601800) && EventFlag(12601850));\n" +
                $"    DeactivateObject(2101801, Disabled);\n" +
                $"}});\n", 
            92107200);
    }
}