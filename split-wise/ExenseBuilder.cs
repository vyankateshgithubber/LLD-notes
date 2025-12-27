using System.Linq;

public class ExpenseBuilder
{
    private int id;
    private User? paidBy;
    private decimal totalAmount;
    private string? description;
    private List<Split> splits;

    private ISplitStrategy? splitStrategy;

    public ExpenseBuilder()
    {
        splits = new List<Split>();
    }

    public ExpenseBuilder SetId(int id)
    {
        this.id = id;
        return this;
    }

    public ExpenseBuilder SetPaidBy(User user)
    {
        this.paidBy = user;
        return this;
    }

    public ExpenseBuilder SetTotalAmount(decimal amount)
    {
        this.totalAmount = amount;
        return this;
    }

    public ExpenseBuilder SetDescription(string description)
    {
        this.description = description;
        return this;
    }

    public ExpenseBuilder AddSplit(User user, decimal amount)
    {
        splits.Add(new Split(user, amount));
        return this;
    }

    public ExpenseBuilder SetSplitStrategy(ISplitStrategy strategy)
    {
        this.splitStrategy = strategy;
        return this;
    }


    public Expense Build()
    {
        if (paidBy == null)
        {
            throw new InvalidOperationException("PaidBy must be set before building an expense.");
        }
        if (splitStrategy != null)
        {
            var users = splits.Select(s => s.user).ToList();
            splits = splitStrategy.GetSplits(totalAmount, users);
        }
        return new Expense(id, description ?? string.Empty, totalAmount, paidBy, splits);
    }
}