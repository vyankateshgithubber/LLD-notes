public class CreditCardPayment : IPaymentStretegy
{
    private string cardNumber;
    private string cardHolderName;
    private string expiryDate;
    private string cvv;

    public CreditCardPayment(string cardNumber, string cardHolderName, string expiryDate, string cvv)
    {
        this.cardNumber = cardNumber;
        this.cardHolderName = cardHolderName;
        this.expiryDate = expiryDate;
        this.cvv = cvv;
    }

    public Payment ProcessPayment(decimal amount)
    {
        // Logic to process credit card payment
        Console.WriteLine($"Processing credit card payment of {amount} for card holder {cardHolderName}");
        return new Payment
        {
            Amount = amount,
            PaymentMethod = "Credit Card",
            Status = "Success",
            TransactionId = Guid.NewGuid().ToString()
        };
    }
}