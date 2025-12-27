public class Transaction
{
    public int Id { get; private set; }
    public User To { get; private set; }
    public User From { get; private set; }
    public decimal Amount { get; private set; }
    public string Description { get; private set; }
    public DateTime Date { get; private set; }
    public Transaction(int id, User to, User from, decimal amount, string description)
    {
        Id = id;
        To = to;
        From = from;
        Amount = amount;
        Description = description;
        Date = DateTime.Now;
    }

    public Transaction(User from, User to, decimal amount)
    {
        Id = 0;
        From = from;
        To = to;
        Amount = amount;
        Description = string.Empty;
        Date = DateTime.Now;
    }

}