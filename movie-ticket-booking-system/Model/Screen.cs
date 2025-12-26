public class Screen
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    private List<Seat> seats;

    public Screen(int id, string name)
    {
        Id = id;
        Name = name;
        seats = new List<Seat>();
    }
    public void AddSeat(Seat seat)
    {
        seats.Add(seat);
    }

    public List<Seat> GetSeats()
    {
        return seats;
    }
}