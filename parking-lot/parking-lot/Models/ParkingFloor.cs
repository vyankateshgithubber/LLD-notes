public class ParkingFloor
{
    public int floorNumber { get; set; }
    private Dictionary<string, ParkingSpot> parkingSpots;
    private readonly object lockObject = new object();

    public ParkingFloor(int floorNumber)
    {
        this.floorNumber = floorNumber;
        parkingSpots = new Dictionary<string, ParkingSpot>();
    }

    public void AddParkingSpot(ParkingSpot spot)
    {
        parkingSpots[spot.SpotId] = spot;
    }

    public ParkingSpot GetParkingSpot(Vehicle vehicle){
        lock (lockObject)
        {
            var availableSpot = parkingSpots.Values
                .where(spot => spot.IsAvailable && spot.CanFitVehicle(vehicle))
                .OrderBy(spot => spot.SpotId)
                .FirstOrDefault();
                .FirstOrDefault(spot => spot.CanFitVehicle(vehicle));
            return availableSpot;
        }
    }
    public void DisplayAvailableSpots()
    {
        Console.WriteLine($"Available parking spots on floor {floorNumber}:");
        var availableSpots = parkingSpots.Values
            .Where(spot => spot.IsAvailable)
            .GroupBy(spot => spot.Type)
            .Select(group => new { Type = group.Key, Count = group.Count() });
        foreach (var group in availableSpots)
        {
            Console.WriteLine($"Type: {group.Type}, Count: {group.Count}");
        }
      
    }
}