public interface IPaymentStretegy
{
    Payment ProcessPayment(decimal amount);
}