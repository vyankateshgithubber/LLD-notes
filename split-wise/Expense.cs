public class Expense
{
    public int Id { get; private set; }
    public string Description { get; private set; }
    public decimal TotalAmount { get; private set; }
    public User PaidBy { get; private set; }
    public List<Split> Splits { get; private set; }

    public Expense(int id, string description, decimal totalAmount, User paidBy, List<Split> splits)
    {
        Id = id;
        Description = description;
        TotalAmount = totalAmount;
        PaidBy = paidBy;
        Splits = splits;
    }
}

