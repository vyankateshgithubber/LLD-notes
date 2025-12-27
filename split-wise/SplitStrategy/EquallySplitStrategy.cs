public class EquallySplitStrategy : ISplitStrategy
{
    public List<Split> GetSplits(decimal totalAmount, List<User> users)
    {
        var splits = new List<Split>();
        var splitAmount = totalAmount / users.Count;
        foreach (var user in users)
        {
            splits.Add(new Split(user, splitAmount));
        }
        return splits;
    }
}