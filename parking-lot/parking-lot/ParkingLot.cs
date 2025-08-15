using System.Collections.Concurrent;
using System.Collections.Generic;

public class ParkingLot 
{
    private static ParkingLot instance;
    private static readonly object lockObject = new object();
    
    private readonly List<ParkingFloor> Floors;
    private readonly ConcurrentDictionary<string, ParkingTicket> parkedVehicles;

    private IFeesStrategy feesStrategy;
    private IParkingStrategy parkingStrategy;
    private readonly object mainob = new object();

    private ParkingLot()
    {
        Floors = new List<ParkingFloor>();
        parkedVehicles = new ConcurrentDictionary<string, ParkingTicket>();
        feesStrategy = new DefaultFeesStrategy();
        parkingStrategy = new DefaultParkingStrategy();
    }

    public static ParkingLot Instance
    {
        get
        {
            if(instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new ParkingLot();
                    }
                }
            }
            return instance;
        }
    }

    public void AddFloor(ParkingFloor floor)
    {
        Floors.Add(floor);
    }
    
    public ParkingTicket ParkVehicle(Vehicle vehicle)
    {
        lock (mainob)
        {
            var spot = parkingStrategy.FindSpot(Floors, vehicle);
            if (spot != null)
            {
                spot.ParkVehicle(vehicle);
                var ticket = new ParkingTicket(vehicle, spot);
            
                parkedVehicles.TryAdd(vehicle.LicensePlate, ticket);
                return ticket;
            }
        }
        return null;
    }

    public double UnparkVehicle(string licensePlate)
    {
        if (parkedVehicles.TryRemove(licensePlate, out var ticket))
        {
            var vehicle = ticket.Vehicle;
            ticket.ParkingSpot.unParkVehicle();
            ticket.MarkAsExited();
            double fees = feesStrategy.CalculateFee(ticket);
            return fees;
        }
        return 0.0; // Vehicle not found
    }
}