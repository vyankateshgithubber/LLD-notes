public abstract class Vehicle{
    protected readonly string LicensePlate ;
    protected readonly VehicleSize Size;
    

    protected Vehicle(string licensePlate, VehicleSize size)
    {
        LicensePlate = licensePlate;
        Size = size;
    }
    public string GetLicensePlate()
    {
        return LicensePlate;
    }
    public VehicleSize GetSize()
    {
        return Size;
    }
}

public class Bike : Vehicle
{
    public Bike(string licensePlate) : base(licensePlate, VehicleSize.Small)
    {
    }
}
public class Car : Vehicle
{
    public Car(string licensePlate) : base(licensePlate, VehicleSize.Medium)
    {
    }
}
public class Bus : Vehicle
{
    public Bus(string licensePlate) : base(licensePlate, VehicleSize.Large)
    {
    }
}