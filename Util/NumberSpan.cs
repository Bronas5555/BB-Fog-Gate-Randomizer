namespace BB_Fog_Gate_Randomizer.Util;

public class NumberSpan
{
    public int MinValue { get; set; }
    public int MaxValue { get; set; }
    
    public NumberSpan(int minValue, int maxValue)
    {
        MinValue = minValue;
        MaxValue = maxValue;
    }

    public bool isInsideIncludeBounds(int value)
    {
        if (value >= MinValue && value <= MaxValue) return true;
        return false;
    }
}