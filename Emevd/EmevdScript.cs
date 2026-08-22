using System.Collections.Generic;
using System.IO;
using System.Linq;
using BB_Fog_Gate_Randomizer.Randomizer;
using BB_Fog_Gate_Randomizer.Randomizer.Fog;

namespace BB_Fog_Gate_Randomizer.Emevd;

public class EmevdScript
{
    public  MapName      Map;
    
    private List<string> _script;
    private string       _path;

    public EmevdScript(MapName map)
    {
        Map = map;
        _path = Path.Join("./WorkingDirectory", BuildEventScriptNameFromMapNameJs(Map));
        _script = File.ReadAllText(_path).Split("\n").ToList();
    }

    public void AddEvent(string eventString, int eventId)
    {
        _script.Add(eventString);
        
        RegisterEvent(eventId);
    }

    private void RegisterEvent(int eventId)
    {
        string registerLine = $"    InitializeEvent(0, {eventId}, 0);\n";
        _script.Insert(11, registerLine);
    }

    private string BuildEventScriptNameFromMapNameJs(MapName mapName)
    {
        return mapName.Identifier + ".emevd.dcx.js";
    }

    public void WriteToDisk()
    {
        string script = "";
        foreach (var line in _script)
        {
            script += line;
        }
        File.WriteAllText(_path, script);
    }
}