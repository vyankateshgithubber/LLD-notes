public interface IPricingStrategy
{
    decimal CalculatePrice(List<Seat> seats);
}