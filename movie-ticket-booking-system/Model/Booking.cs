using System.Net.NetworkInformation;

public class Booking
{
    public int BookingId { get; set; }
    public User User { get; set; }
    public Show Show { get; set; }
    public List<Seat> Seats { get; set; }
    public Payment Payment { get; set; }
    public DateTime BookingTime { get; set; }

    public Booking(int bookingId, User user, Show show, List<Seat> seats, Payment payment)
    {
        BookingId = bookingId;
        User = user;
        Show = show;
        Seats = seats;
        Payment = payment;
        BookingTime = DateTime.Now;
    }
}

public class BookingBuilder
{
    private int id;
    private User user;
    private Show show;
    private List<Seat> seats = new List<Seat>();
    private Payment payment;

    public BookingBuilder SetId(int id)
    {
        this.id = id;
        return this;
    }
    public BookingBuilder SetUser(User user)
    {
        this.user = user;
        return this;
    }
    public BookingBuilder SetShow(Show show)
    {
        this.show = show;
        return this;
    }
    public BookingBuilder SetSeats(List<Seat> seats)
    {
        this.seats = seats;
        return this;
    }
    public BookingBuilder SetPayment(Payment payment)
    {
        this.payment = payment;
        return this;
    }
    public Booking Build()
    {
        return new Booking(id, user, show, seats, payment);
    }
    
}