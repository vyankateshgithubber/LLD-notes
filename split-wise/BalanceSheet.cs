public class BalanceSheet
{
    public User owner { get; private set; }
    public Dictionary<User, decimal> balances { get; private set; }
    private readonly object balanceLock = new object();

    public BalanceSheet(User owner)
    {
        this.owner = owner;
        balances = new Dictionary<User, decimal>();
    }

    public void UpdateBalance(User otherUser, decimal amount)
    {
        lock (balanceLock)
        {
            if (balances.ContainsKey(otherUser))
            {
                balances[otherUser] += amount;
            }
            else
            {
                balances[otherUser] = amount;
            }
        }
    }

    public void PrintBalances()
    {
        lock (balanceLock)
        {
            foreach (var entry in balances)
            {
                if (entry.Value != 0)
                {
                    string status = entry.Value > 0 ? "owes you" : "you owe";
                    Console.WriteLine($"{entry.Key.Name} {status} {Math.Abs(entry.Value):C}");
                }
            }
        }
    }
}