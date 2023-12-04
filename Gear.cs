namespace AdventOfCode2023;

public class Gear
{
    private int Value1 { get; set; } = 0;
    private int Value2 { get; set; } = 0;

    public void AddValue(int value)
    {
        if (Value1 == 0)
            Value1 = value;
        else if (Value2 == 0)
        {
            Value2 = value;
            GearRatio = Value1 * Value2;
        }
        else
        {
            GearRatio = 0;
        }
    }

    public long GearRatio = 0;
}