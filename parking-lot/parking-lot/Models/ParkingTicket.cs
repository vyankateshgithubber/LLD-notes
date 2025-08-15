using System;

public class ParkingTicket
{
    public string TicketNumber { get; private set; }
    public Vehicle Vehicle { get; private set; }
    public ParkingSpot ParkingSpot { get; private set; }
    public DateTime ParkedAt { get; private set; }
    public DateTime? ExitedAt { get; private set; }

    public ParkingTicket(Vehicle vehicle, ParkingSpot parkingSpot)
    {
        TicketNumber = Guid.NewGuid().ToString();
        Vehicle = vehicle;
        ParkingSpot = parkingSpot;
        ParkedAt = DateTime.Now;
    }

    public void MarkAsExited()
    {
        ExitedAt = DateTime.Now;
    }
}