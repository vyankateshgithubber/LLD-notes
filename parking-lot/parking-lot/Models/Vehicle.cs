public abstract class Vehicle {
    public string LicensePlate { get; protected set; }
    public VehicleSize Size { get; protected set; }

    protected Vehicle(string licensePlate, VehicleSize size)
    {
        LicensePlate = licensePlate;
        Size = size;
    }
}