public class ParkingTicket{
    private string tickerNumber;
    private Vehicle vehicle;
    private ParkingSpot parkingSpot;
    private DateTime entryTime;
    private DateTime exitTime;
    public ParkingTicket(Vehicle vehicle, ParkingSpot parkingSpot){
        this.tickerNumber = Guid.NewGuid().ToString();
        this.vehicle = vehicle;
        this.parkingSpot = parkingSpot;
        this.entryTime = DateTime.Now;
        this.exitTime = DateTime.MinValue; // Default value indicating the ticket is still active
    }
    public string TickerNumber {
        get { return tickerNumber; }
    }
    public Vehicle Vehicle {
        get { return vehicle; }
    }
    public ParkingSpot ParkingSpot {
        get { return parkingSpot; }
    }
    public DateTime EntryTime {
        get { return entryTime; }       
    }
    public DateTime ExitTime {
        get { return exitTime; }
    }
    public void MarkAsExited() {
        this.exitTime = DateTime.Now; // Set the exit time to the current time
    }
}