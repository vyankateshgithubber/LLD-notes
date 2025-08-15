// See https://aka.ms/new-console-template for more information



public class Vehicle{
    public string LicensePlate { get; set; }
    public VehicleType Type { get; set; }

    public Vehicle(string licensePlate, VehicleType type)
    {
        LicensePlate = licensePlate;
        Type = type;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        
    }
}
