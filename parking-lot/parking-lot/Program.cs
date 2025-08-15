using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Initializing Parking Lot System...");
            
            var parkingLot = ParkingLot.Instance;

            // 1. Initialize the parking lot with floors and spots
            var floor1 = new ParkingFloor(1);
            floor1.AddParkingSpot(new ParkingSpot("F1-S1", VehicleSize.Compact));
            floor1.AddParkingSpot(new ParkingSpot("F1-M1", VehicleSize.Regular));
            floor1.AddParkingSpot(new ParkingSpot("F1-L1", VehicleSize.Large));

            parkingLot.AddFloor(floor1);

            // 2. Create some vehicles
            var car1 = new Car("CAR-001");
            var car2 = new Car("CAR-002");
            var truck = new Truck("TRUCK-001");

            // 3. Try to park vehicles
            Console.WriteLine("\nTrying to park vehicles...");
            var ticket1 = parkingLot.ParkVehicle(car1);
            var ticket2 = parkingLot.ParkVehicle(car2);
            var ticket3 = parkingLot.ParkVehicle(truck);

            // 4. Display parking status
            Console.WriteLine("\nParking Status:");
            if (ticket1 != null)
                Console.WriteLine($"Car1 parked at spot: {ticket1.ParkingSpot.SpotId}");
            if (ticket2 != null)
                Console.WriteLine($"Car2 parked at spot: {ticket2.ParkingSpot.SpotId}");
            if (ticket3 != null)
                Console.WriteLine($"Truck parked at spot: {ticket3.ParkingSpot.SpotId}");

            // 5. Try to unpark a vehicle
            Console.WriteLine("\nUnparking Car1...");
            var fee = parkingLot.UnparkVehicle(car1.LicensePlate);
            Console.WriteLine($"Parking fee: ${fee}");

            Console.WriteLine("\nParking Lot Demo Completed!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}