public class NormalPrice : IPricingStrategy
{
    private const decimal RegularSeatPrice = 10.0m;
    private const decimal PremiumSeatPrice = 15.0m;
    private const decimal VIPSeatPrice = 20.0m;

    public decimal CalculatePrice(List<Seat> seats)
    {
        decimal totalPrice = 0.0m;

        foreach (var seat in seats)
        {
            switch (seat.Type)
            {
                case SeatType.Regular:
                    totalPrice += RegularSeatPrice;
                    break;
                case SeatType.Premium:
                    totalPrice += PremiumSeatPrice;
                    break;
                case SeatType.VIP:
                    totalPrice += VIPSeatPrice;
                    break;
            }
        }

        return totalPrice;
    }
}