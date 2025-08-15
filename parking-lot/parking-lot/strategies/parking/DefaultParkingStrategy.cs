public class DefaultParkingStrategy : IParkingStrategy
{
    public ParkingSpot FindSpot(List<ParkingFloor> floors, Vehicle vehicle)
    {
        // Example logic to find a parking spot
        foreach (var floor in floors)
        {
            var spot = floor.GetParkingSpot(vehicle);
            if (spot != null)
            {
                return spot;
            }
        }
        return null; // No available spot found
    }
}