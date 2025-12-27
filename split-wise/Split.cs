public class Split
{
    public User user { get; private set; }
    public decimal amount { get; private set; }
    public Split(User user, decimal amount)
    {
        this.user = user;
        this.amount = amount;
    }
    
}