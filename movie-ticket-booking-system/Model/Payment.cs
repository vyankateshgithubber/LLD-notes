public class Payement
{
    public int Id { get; private set; }
    public decimal Amount { get; private set; }
    public PaymentStatus Status { get; private set; }

    public Payment(int id, decimal amount)
    {
        Id = id;
        Amount = amount;
        Status = PaymentStatus.Pending;
    }

    public void CompletePayment()
    {
        Status = PaymentStatus.Completed;
    }

    public void FailPayment()
    {
        Status = PaymentStatus.Failed;
    }
}