using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

public class SplitWiseService
{
    private static SplitWiseService? _instance;
    private static readonly object _lock = new object();
    private Dictionary<string, User> users;
    private Dictionary<string,Group> groups;
    private SplitWiseService()
    {
        users = new Dictionary<string, User>();
        groups = new Dictionary<string, Group>();
    }
    public static SplitWiseService GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new SplitWiseService();
                }
            }
        }
        return _instance!;
    }
    public void AddUser(User user)
    {
        if (!users.ContainsKey(user.Email))
        {
            users[user.Email] = user;
        }
    }
    public User? GetUserByEmail(string email)
    {
        if (users.ContainsKey(email))
        {
            return users[email];
        }
        return null;
    }
    public void AddGroup(Group group)
    {
        if (!groups.ContainsKey(group.Name))
        {
            groups[group.Name] = group;
        }
    }
    public Group? GetGroupByName(string name)
    {
        if (groups.ContainsKey(name))
        {
            return groups[name];

        }
        return null;
    }

    public void CreateExpense(Expense expense)
    {
        List<Split> splits = expense.Splits;
        foreach (var split in splits)
        {
            if (split.user.Id != expense.PaidBy.Id)
            {
                expense.PaidBy.BalanceSheet.UpdateBalance(split.user, split.amount);
                split.user.BalanceSheet.UpdateBalance(expense.PaidBy, -split.amount);
            }
        }
    }
    public void SetteleUpExpense(string payerId, string payeeId, decimal amount)
    {
        lock(_lock)
        {
            var payer = users.Values.FirstOrDefault(u => u.Id.ToString() == payerId);
            var payee = users.Values.FirstOrDefault(u => u.Id.ToString() == payeeId);
            if (payer != null && payee != null)
            {
                payer.BalanceSheet.UpdateBalance(payee, -amount);
                payee.BalanceSheet.UpdateBalance(payer, amount);
            }
        }   
    }
    public void ShowBalances(string userEmail)
    {
        var user = GetUserByEmail(userEmail);
        if (user != null)
        {
            user.BalanceSheet.PrintBalances();
        }
    }

    public List<Transaction> SimplifyDebts(string GroupId)
    {
        if (!groups.ContainsKey(GroupId))
        {
            return new List<Transaction>();
        }
        var group = groups[GroupId];
        Dictionary<User, decimal> netBalances = new Dictionary<User, decimal>();
        foreach (var member in group.Members)
        {
            decimal netBalance = 0;
            foreach (var entry in member.BalanceSheet.balances)
            {
                if (group.Members.Contains(entry.Key))
                {
                  netBalance += entry.Value;
                }
            }
            netBalances[member] = netBalance;
        }
        var creditors = netBalances.Where(kv => kv.Value > 0)
                                      .Select(kv => new KeyValuePair<User, decimal>(kv.Key, kv.Value))
                                      .OrderByDescending(kv => kv.Value).ToList();

        var debtors = netBalances.Where(kv => kv.Value < 0).OrderBy(kv => kv.Value)
                                      .ToList();
        List<Transaction> transactions = new List<Transaction>();
        int i = 0, j = 0;
        while (i < debtors.Count && j < creditors.Count)
        {
            var debtor = debtors[i];
            var creditor = creditors[j];
            decimal settleAmount = Math.Min(-debtor.Value, creditor.Value);
            transactions.Add(new Transaction(debtor.Key, creditor.Key, settleAmount));
            netBalances[debtor.Key] += settleAmount;
            netBalances[creditor.Key] -= settleAmount;
            if (netBalances[debtor.Key] == 0)
            {
                i++;
            }
            if (netBalances[creditor.Key] == 0)
            {
                j++;
            }
        }
        return transactions;
        // Implement debt simplification logic here
    }
}