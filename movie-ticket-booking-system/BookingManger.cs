public class BookManger
{
    private IPricingStrategy _pricingStrategy;
    private IPaymentStretegy _paymentStrategy;
    private SeatLockerManger _seatLockerManager;

    public BookManger(IPricingStrategy pricingStrategy, IPaymentStretegy paymentStrategy, SeatLockerManger seatLockerManager)
    {
        _pricingStrategy = pricingStrategy;
        _paymentStrategy = paymentStrategy;
        _seatLockerManager = seatLockerManager;
    }

    public Booking CreateBooking(User user, Show show, List<Seat> seats)
    {
        // Lock seats
        _seatLockerManager.LockSeats(show, seats, user);
        // Calculate price
        decimal totalPrice = _pricingStrategy.CalculatePrice(seats);
        // Process payment
        Payment payment = _paymentStrategy.ProcessPayment(totalPrice);
        // Create booking
        Booking booking = new BookingBuilder()
            .SetId(GenerateBookingId())
            .SetUser(user)
            .SetShow(show)
            .SetSeats(seats)
            .SetPayment(payment)
            .Build();
        return booking;
    }
    
}