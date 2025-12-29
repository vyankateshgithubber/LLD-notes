public interface Payment
    {
        bool ProcessPayment(double amount);
    }

     public class CashPayment : Payment
    {
        public bool ProcessPayment(double amount)
        {
            // Process cash payment
            return true;
        }
    }