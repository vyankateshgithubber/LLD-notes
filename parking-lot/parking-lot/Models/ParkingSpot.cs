public class ParkingSpot{
    private readonly string spotId;
    private readonly VehicleSize spotSize;
    private Vehicle currentVehicle;
    private bool isAvailable;
    private readonly object lockObject = new object();
    public ParkingSpot(string id, VehicleSize size) {
        spotId = id;
        spotSize = size;
        isAvailable = true;
        currentVehicle = null;
    }
    public string SpotId {
        get { return spotId; }
    }
    public VehicleSize SpotSize {
        get { return spotSize; }
    }
    public bool IsAvailable {
        get { return isAvailable; } 
    }
    public Vehicle CurrentVehicle {
        get { return currentVehicle; }
    }
    public void ParkVehicle(Vehicle vehicle) {
        lock (lockObject) {
            if (isAvailable && vehicle.Size == spotSize) {
                currentVehicle = vehicle;
                isAvailable = false;
            } else {
                throw new InvalidOperationException("Parking spot is not available or vehicle size does not match.");
            }
        }
    }
    public void unParkVehicle() {
        lock (lockObject) {
            if (!isAvailable) {
                currentVehicle = null;
                isAvailable = true;
            } else {
                throw new InvalidOperationException("Parking spot is already available.");
            }
        }
    }
    public CanFitVehicle CanFitVehicle(Vehicle vehicle) {
        return isAvailable && vehicle.Size == spotSize;
    }
}