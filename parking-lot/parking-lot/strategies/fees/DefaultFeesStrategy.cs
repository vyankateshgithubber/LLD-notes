public class DefaultFeesStrategy : IFeesStrategy
{
    public double CalculateFee(ParkingTicket ticket)
    {
        // Example fee calculation logic
        TimeSpan parkedDuration = DateTime.Now - ticket.ParkedAt;
        double feePerHour = 10.0; // Example fee rate
        double totalFee = Math.Ceiling(parkedDuration.TotalHours) * feePerHour;
        return totalFee;
    }
}