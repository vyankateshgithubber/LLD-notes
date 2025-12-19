using System;

public class Vehicle
{
    public string Name { get; set; }
    public int PosX { get; set; }
    public int PosY { get; set; }

    public Vehicle(string name, int x, int y)
    {
        Name = name;
        PosX = x;
        PosY = y;
    }

    public override string ToString()
    {
        return $"{Name} @ ({PosX},{PosY})";
    }
}