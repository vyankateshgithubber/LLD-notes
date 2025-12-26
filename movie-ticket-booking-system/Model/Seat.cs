public class Seat
{
    public int Id { get; private set; }
    public string SeatNumber { get; private set; }
    public SeatType Type { get; private set; }
    public SeatStatus Status { get; private set; }

    public Seat(int id, string seatNumber, SeatType type)
    {
        Id = id;
        SeatNumber = seatNumber;
        Type = type;
        Status = SeatStatus.Available;
    }

    public void UpdateStatus(SeatStatus newStatus)
    {
        Status = newStatus;
    }
}